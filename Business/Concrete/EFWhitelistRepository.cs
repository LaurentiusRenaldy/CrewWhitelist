using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net;
using Business.Infrastructure;
using Business.Linq;
using Business.Entities;
using Business.Abstract;

namespace Business.Concrete
{
    public class EFWhitelistRepository : IWhitelistRepository
    {
		private CrewWhitelistEntities context = new CrewWhitelistEntities();

        #region whitelist

        public List<Whitelist> FindAll(int? skip = null, int? take = null, List<SortingInfo> sortings = null, FilterInfo filters = null)
        {
            IQueryable<Whitelist> list = context.Whitelists;

            if (filters != null && (filters.Filters != null && filters.Filters.Count > 0))
            {
                filters.FormatFieldToUnderscore();
                GridHelper.ProcessFilters<Whitelist>(filters, ref list);
            }

            if (sortings != null && sortings.Count > 0)
            {
                foreach (var s in sortings)
                {
                    s.FormatSortOnToUnderscore();
                    list = list.OrderBy<Whitelist>(s.SortOn + " " + s.SortOrder);
                }
            }
            else
            {
                list = list.OrderBy<Whitelist>("id desc"); //default, wajib ada atau EF error
            }

            //take & skip
            var takeList = list;
            if (skip != null)
            {
                takeList = takeList.Skip(skip.Value);
            }
            if (take != null)
            {
                takeList = takeList.Take(take.Value);
            }

            //return result
            //var sql = takeList.ToString();
            List<Whitelist> result = takeList.ToList();
            return result;
        }

        public Whitelist FindByPk(int id)
        {
            return context.Whitelists.Find(id);
        }

        public int Count(FilterInfo filters = null)
        {
            IQueryable<Whitelist> items = context.Whitelists;

            if (filters != null && (filters.Filters != null && filters.Filters.Count > 0))
            {
                GridHelper.ProcessFilters<Whitelist>(filters, ref items);
            }

            return items.Count();
        }

        public void Save(Whitelist dbItem)
        {
            if (dbItem.id == 0) //create
            {
                context.Whitelists.Add(dbItem);
            }
            else //edit
            {
                var entry = context.Entry(dbItem);
                entry.State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void Delete(Whitelist dbItem)
        {
            context.Whitelists.Remove(dbItem);
            context.SaveChanges();
        }

        #endregion
	}
}