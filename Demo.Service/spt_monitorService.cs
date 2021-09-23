using Demo.EntityFramework;
using Demo.EntityFramework.Infrastructure;
using Demo.Repository;
using Demo.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using Demo.Repository.Interface;

namespace Demo.Service
{
    public class spt_monitorService : Ispt_monitorService
    {
        private readonly Ispt_monitorRepository spt_monitorRepository;

        private readonly IUnitOfWork _unitOfWork;
        public spt_monitorService(Ispt_monitorRepository spt_monitorRepository, IUnitOfWork unitOfWork)
        {
            this.spt_monitorRepository = spt_monitorRepository;
            _unitOfWork = unitOfWork;
        }

        public List<Employee> GetAll()
        {
            var result = spt_monitorRepository.GetAll().ToList();
            return result;
        }
    }
}
