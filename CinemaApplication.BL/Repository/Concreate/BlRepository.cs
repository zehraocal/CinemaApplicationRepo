using AutoMapper;
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
        protected IMapper _mappingProfile;

        public BlRepository(IMapper mappingProfile)
        {
            _context = DbContextService.GetDbContext();
            _mappingProfile = mappingProfile;
        }

        public DbSet<T> Table { get { return GetTable(); } }

        public DbSet<T> GetTable()
        {
            return _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return Table.ToList();
        }

        public T GetSingle(Func<T, bool> method)
        {
            return Table.FirstOrDefault(method);
        }

        public List<T> GetWhere(Func<T, bool> method)
        {
            return Table.Where(method).ToList();
        }

        public virtual bool Add<TAddVM>(TAddVM model) where TAddVM : class
        {
            _context.Set<T>().Add(_mappingProfile.Map<T>(model));
            return Save();
        }

        public virtual bool Update<TUpdateVM>(TUpdateVM model) where TUpdateVM : BaseEntity
        {
            _context.Entry<T>(_mappingProfile.Map<T>(model)).State = EntityState.Modified;
            return Save();
        }

        public virtual bool Remove(long id)
        {
            var asd = _mappingProfile.Map<T>(_context.Set<T>());

            return Remove(asd));
        }

        public bool Remove<TDeleteVM>(TDeleteVM model) where TDeleteVM : BaseEntity
        {
            _context.Set<T>().Remove(_mappingProfile.Map<T>(model));
            return Save();
        }       

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

    }


}

