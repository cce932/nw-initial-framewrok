using Demo.EntityFramework;
using Demo.EntityFramework.Infrastructure;
using Demo.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository
{
    public class spt_monitorRepository : GenericRepository<int, Employee>, Ispt_monitorRepository
    {
        public spt_monitorRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
