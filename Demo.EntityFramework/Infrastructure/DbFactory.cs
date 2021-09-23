using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.EntityFramework.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ntust_infoEntities _dbContext;

        public DbContext Init()
        {
            return _dbContext ?? (_dbContext = new ntust_infoEntities());
        }

        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }
}
