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
    public class EFCrewRepository : ICrewRepository
    {
		private CrewWhitelistEntities context = new CrewWhitelistEntities();

        #region crew

        public List<Crew> FindAll(int? skip = null, int? take = null, List<SortingInfo> sortings = null, FilterInfo filters = null)
        {
            IQueryable<Crew> list = context.Crews;

            if (filters != null && (filters.Filters != null && filters.Filters.Count > 0))
            {
                filters.FormatFieldToUnderscore();
                GridHelper.ProcessFilters<Crew>(filters, ref list);
            }

            if (sortings != null && sortings.Count > 0)
            {
                foreach (var s in sortings)
                {
                    s.FormatSortOnToUnderscore();
                    list = list.OrderBy<Crew>(s.SortOn + " " + s.SortOrder);
                }
            }
            else
            {
                list = list.OrderBy<Crew>("barcode asc"); //default, wajib ada atau EF error
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
            List<Crew> result = takeList.ToList();
            return result;
        }

        public Crew FindByPk(long id)
        {
            return context.Crews.Find(id);
        }

        public int Count(FilterInfo filters = null)
        {
            IQueryable<Crew> items = context.Crews;

            if (filters != null && (filters.Filters != null && filters.Filters.Count > 0))
            {
                GridHelper.ProcessFilters<Crew>(filters, ref items);
            }

            return items.Count();
        }

        public void Save(Crew dbItem)
        {
            if (context.Crews.FirstOrDefault(x => x.barcode == dbItem.barcode) == null) //create
            {
                context.Crews.Add(dbItem);
            }
            else //edit
            {
                var entry = context.Entry(dbItem);
                entry.State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void Delete(Crew dbItem)
        {
            context.Crews.Remove(dbItem);
            context.SaveChanges();
        }

        #endregion
	}
}