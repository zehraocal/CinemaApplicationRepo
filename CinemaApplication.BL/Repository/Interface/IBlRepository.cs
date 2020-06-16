using CinemaApplication.Entity.Entities;
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
        DbSet<T> GetTable();
        List<T> GetAll();
        T GetSingle(Func<T, bool> method);
        List<T> GetWhere(Func<T, bool> method);
        bool Add<TAddVM>(TAddVM model) where TAddVM : class;
        bool Remove(long id);
        bool Update<TUpdateVM>(TUpdateVM model) where TUpdateVM : BaseEntity;
        bool Save();

    }
}
