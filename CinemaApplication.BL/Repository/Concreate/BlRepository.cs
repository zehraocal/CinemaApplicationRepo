using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.DAL.Contexts;
using CinemaApplication.Entity.Entities;
using CinemaApplication.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaApplication.BL.Repository.Concreate
{
    public class BlRepository<T> : IBlRepository<T> where T : BaseEntity, new()
    {
        CinemaApplicationContext _context;

        public BlRepository()
        {
            _context = DbContextService.GetDbContext();
        }

        public DbSet<T> Table
        {
            get
            {
                return GetTable();
            }
        }

        public DbSet<T> GetTable()
        {
            //return _context.Set<T>();
            return GetTable<T>();
        }

        public List<T> GetAll()
        {
            //return Table.ToList();
            return GetAll<T>();
        }

        public T GetSingle(Func<T, bool> metot)
        {
            //return Table.FirstOrDefault(metot);
            return GetSingle<T>(metot);
        }

        public List<T> GetWhere(Func<T, bool> metot)
        {
            //return Table.Where(metot).ToList();
            return GetWhere<T>(metot);
        }

        public bool Remove(T model)
        {
            //Table.Remove(model);
            //return Save();
            return Remove<T>(model);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(T model)
        {
            //_context.Entry<T>(model).State = EntityState.Modified;
            //return Save();
            return Update<T>(model);
        }

        public DbSet<A> GetTable<A>() where A : BaseEntity
        {
            return _context.Set<A>();
        }

        public List<A> GetAll<A>() where A : BaseEntity
        {
            return GetTable<A>().ToList();
        }

        public List<A> GetWhere<A>(Func<A, bool> metot) where A : BaseEntity
        {
            return GetTable<A>().Where(metot).ToList();
        }

        public A GetSingle<A>(Func<A, bool> metot) where A : BaseEntity
        {
            return GetTable<A>().FirstOrDefault(metot);
        }

        public virtual bool Add<TAddVM>(TAddVM model) where TAddVM : class
        {
            //TODO: Map islemi burda yapıalcak gelen paramatere entity destination olacak şekilde maplenenecek ve entity Add'e parametre olarak verilecek.
            var asd = new T();
            _context.Set<T>().Add(asd);
            return Save();
        }

        public bool Remove<A>(A model) where A : BaseEntity
        {
            _context.Set<A>().Remove(model);
            return Save();
        }

        public bool Update<A>(A model) where A : BaseEntity
        {
            _context.Entry<A>(model).State = EntityState.Modified;
            return Save();
        }
    }
}
