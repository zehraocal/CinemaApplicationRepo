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
    public class BlRepository<T> : IBlRepository<T> where T : BaseEntity
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
            return _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return Table.ToList();
        }

        public T GetSingle(Func<T, bool> metot)
        {
            return Table.FirstOrDefault(metot);
        }

        public List<T> GetWhere(Func<T, bool> metot)
        {
            return Table.Where(metot).ToList();
        }

        public virtual bool Add(T model)
        {
            Table.Add(model);
            return Save();
        }

        public bool Remove(T model)
        {
            Table.Remove(model);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(T model)
        {
            _context.Entry<T>(model).State = EntityState.Modified;
            return Save();
        }
    }
}
