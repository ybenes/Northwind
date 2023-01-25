﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Data.Abstract;
using Core.Domain;

namespace Core.Data.Concrete.EntityFramework
{
    public class EfRepositoryBase<Entity, TContext> : IRepository<Entity>
        where Entity : class,IBaseDomain, new()
        where TContext : DbContext, new()
    {
        public void Delete(Entity entity)
        {
            using (TContext ctx = new TContext())
            {
                ctx.Set<Entity>().Remove(entity); 
                ctx.SaveChanges();
            }
        }
       
        public Entity Get(Expression<Func<Entity, bool>> filter, params string[] includelist)
        {
            using (TContext ctx = new TContext())
            {
                IQueryable<Entity> query = ctx.Set<Entity>();
                if (includelist.Length > 0)
                {
                    foreach (string item in includelist)
                    {
                        query = query.Include(item);
                    }
                }
                return query.SingleOrDefault(filter);
            }
        }

        public List<Entity> GetAll(Expression<Func<Entity, bool>> filter, params string[] includelist)
        {
            using (TContext ctx = new TContext())
            {
                IQueryable<Entity> query = ctx.Set<Entity>();
                if (includelist.Length > 0)
                {
                    foreach (string item in includelist)
                    {
                        query = query.Include(item);
                    }
                }
                return filter == null ? query.ToList() : query.Where(filter).ToList();
            }
        }

    
        public void Insert(Entity entity)
        {
            using (TContext ctx = new TContext())
            {
                ctx.Set<Entity>().Add(entity);
                ctx.SaveChanges();
            }
        }
        public void Update(Entity entity)
        {
            using (TContext ctx = new TContext())
            {

                Entity ent = ctx.Set<Entity>().Attach(entity).Entity;
                ctx.Entry(entity).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }


    }
}
