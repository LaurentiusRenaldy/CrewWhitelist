﻿using Business.Abstract;
using Business.Entities;
using Business.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Linq;
using System.Text.RegularExpressions;

namespace Business.Concrete
{
    public class EFActionRepository : IActionRepository
    {
        private Entities.UserManagement context = new Entities.UserManagement();

        public void Create(Business.Entities.Action action) {
            context.Actions.Add(action);
            context.SaveChanges();
        }

        public void Delete(string actionName, bool fk) 
        { 
            Business.Entities.Action a = context.Actions.Where(x => x.ActionName == actionName).FirstOrDefault();

            if (!fk) {
                a.Modules.Clear();
                a.ModulesInRoles.Clear();
            }

            context.Actions.Remove(a);
            context.SaveChanges();
        }

        public List<Business.Entities.Action> Find(int skip = 0, int? take = null, List<SortingInfo> sortings = null, FilterInfo filters = null, string filterLogic = null)
        {
            IQueryable<Business.Entities.Action> actions = context.Actions;

            if (filters != null && (filters.Filters != null && filters.Filters.Count > 0))
            {
                filters.FormatFieldToUnderscore();
                GridHelper.ProcessFilters<Business.Entities.Action>(filters, ref actions);
            }

            if (sortings != null && sortings.Count > 0)
            {
                foreach (var s in sortings)
                {
                    s.FormatSortOnToUnderscore();
                    actions = actions.OrderBy<Business.Entities.Action>(s.SortOn + " " + s.SortOrder);
                }
            }
            else
            {
                actions = actions.OrderBy("id desc");
            }

            var takeActions = actions;
            if (take != null)
            {
                takeActions = actions.Skip(skip).Take((int)take);
            }
      
            List<Business.Entities.Action> actionList = takeActions.ToList();

            return actionList;
        }

        public List<Module> GetModulesInAction(string actionName) {
           List<Module> result =  context.Actions.Where(x => x.ActionName == actionName).First().Modules.ToList();
           for (int i = 0; i < result.Count; ++i) {
               result[i].Actions.Clear();
               result[i].ModulesInRoles.Clear();
           }
           return result;
        }

        public int Count(List<FilterInfo> filters, string filterLogic) {
            throw (new NotImplementedException());
        }

        public Business.Entities.Action FindByPk(Guid id)
        {
            return context.Actions.Find(id);
        }

        public string MapSort(string sortOn)
        {
            string mapSortOn = sortOn;
            mapSortOn = Regex.Replace(sortOn, @"(\p{Ll})(\p{Lu})", "$1_$2");

            return mapSortOn;
        }
    }
}
