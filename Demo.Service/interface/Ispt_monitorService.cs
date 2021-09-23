using Demo.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Interface
{
    public interface Ispt_monitorService
    {
        List<Employee> GetAll();
    }
}
