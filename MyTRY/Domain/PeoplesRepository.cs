using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcSql.Domain;

namespace MyTRY.Domain
{
    public class PeoplesRepository
    {
        private readonly AppDbContext context;

        public PeoplesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<People> GetPeopels()
        {
            return context.Peoples.OrderBy(x => x.FIO);
        }

        public People GetPeopleById(Guid id)
        {
            return context.Peoples.Single(x => x.Id == id);
        }

        public Guid SavePeople(People entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

            return entity.Id;
        }

        public void DeletePeople(People entity)
        {
            context.Peoples.Remove(entity);
            context.SaveChanges();
        }

        //public People GetPeopleByName(string FIO)
        //{
        //    return context.Peoples.Single(x => x.FIO == FIO);
        //}
        //public People ShowPeople(People entity)
        //{

        //    context.Entry(entity).State = EntityState.Unchanged;

        //    return entity;
        //}
    }

}
