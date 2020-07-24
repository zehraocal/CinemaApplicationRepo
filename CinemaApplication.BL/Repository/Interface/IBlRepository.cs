using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.BL.Repository.Interface
{
    //Ortak operasyonlar repository mantığı ile burada türetilir.
    public interface IBlRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
        List<T> GetAll();
        List<TListVM> GetAllWithType<TListVM>() where TListVM : class;
        T GetSingle(Func<T, bool> method);
        TVM GetSingleWithType<TVM>(Func<TVM, bool> method) where TVM : class;
        List<T> GetWhere(Func<T, bool> method);
        List<TListVM> GetWhereWithType<TListVM>(Func<TListVM, bool> method) where TListVM : class;
        bool Add<TAddVM>(TAddVM model) where TAddVM : class;
        bool Remove(long id);
        bool Update<TUpdateVM>(TUpdateVM model) where TUpdateVM : UpdateVMBase;
        bool Save();

    }
}
