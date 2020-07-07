using AutoMapper;
using AutoMapper.QueryableExtensions;
using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.DAL.Contexts;
using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;
using CinemaApplication.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
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

        public DbSet<T> Table { get { return _context.Set<T>(); } }

        public List<T> GetAll()
        {
            return Table.ToList();
        }

        public virtual List<TListVM> GetAllWithType<TListVM>() where TListVM : class
        {
            return Table.ProjectTo<TListVM>(_mappingProfile.ConfigurationProvider).ToList();
        }

        public T GetSingle(Func<T, bool> method)
        {
            return Table.FirstOrDefault(method);
        }

        public List<T> GetWhere(Func<T, bool> method)
        {
            return Table.Where(method).ToList();
        }

        public List<TListVM> GetWhereWithType<TListVM>(Func<TListVM, bool> method) where TListVM : class
        {
            return Table.ProjectTo<TListVM>(_mappingProfile.ConfigurationProvider).Where(method).ToList();
        }

        public virtual bool Add<TAddVM>(TAddVM model) where TAddVM : class
        {
            Table.Add(_mappingProfile.Map<T>(model));
            return Save();
        }

        public virtual bool Update<TUpdateVM>(TUpdateVM model) where TUpdateVM : UpdateVMBase
        {
            var entity = Table.Find(model.Id);
            _mappingProfile.Map(model, entity);
            _context.Entry<T>(entity).State = EntityState.Modified;
            return Save();
        }

        public virtual bool Remove(long id)
        {
            return Remove(Table.Find(id));
        }

        protected bool Remove<TDeleteVM>(TDeleteVM model)
        {
            Table.Remove(_mappingProfile.Map<T>(model));
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }

}

