using MyProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Persistance.Context
{
    public interface IMyProjectDbContext
    {
        #region Tables
        public DbSet<CargoEntity> Cargoes { get; }       

        #endregion Tables

        #region Views



        #endregion Views

        DatabaseFacade Database { get; }

        EntityEntry Entry(object entity);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
