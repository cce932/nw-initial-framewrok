using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.EntityFramework.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private DbContext _dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public DbContext DbContext => _dbContext ?? (_dbContext = _dbFactory.Init());

        public int Commit()
        {
            return DbContext.SaveChanges();
        }
        public Task<int> CommitAsync()
        {
            return DbContext.SaveChangesAsync();
        }

        public bool LazyLoadingEnabled
        {
            get { return DbContext.Configuration.LazyLoadingEnabled; }
            set { DbContext.Configuration.LazyLoadingEnabled = value; }
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
