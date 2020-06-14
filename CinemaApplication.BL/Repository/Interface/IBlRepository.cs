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
        DbSet<T> Table { get; }
        List<T> GetAll();
        List<T> GetWhere(Func<T, bool> metot);
        T GetSingle(Func<T, bool> metot);
        bool Add(T model);
        bool Remove(T model);
        bool Update(T model);
        bool Save();
    }
}
