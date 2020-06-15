using CinemaApplication.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.BL.Repository.Interface
{
    //Ortak operasyonlar repository mantığı ile burada türetilir.
    public interface IBlRepository <T> where T : BaseEntity
    {
        DbSet<T> GetTable();
        DbSet<A> GetTable<A>() where A : BaseEntity;
        DbSet<T> Table { get; }
        List<T> GetAll();
        List<A> GetAll<A>() where A : BaseEntity;
        List<T> GetWhere(Func<T, bool> metot);
        List<A> GetWhere<A>(Func<A, bool> metot) where A : BaseEntity;
        T GetSingle(Func<T, bool> metot);
        A GetSingle<A>(Func<A, bool> metot) where A : BaseEntity;
        bool Add<A>(A model) where A : class;
        bool Remove(T model);
        bool Remove<A>(A model) where A : BaseEntity;
        bool Update(T model);
        bool Update<A>(A model) where A : BaseEntity;
        bool Save();
    }
}
