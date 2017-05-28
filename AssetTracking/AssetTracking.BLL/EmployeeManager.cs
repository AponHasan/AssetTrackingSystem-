using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.DAL;
using AssetTracking.Models.Interfaces.IModelManager;
using AssetTracking.Models.Models;

namespace AssetTracking.BLL
{
    public class EmployeeManager : IEmployeeManager
    {
        private EmployeeRepository _employeeRepository;

        public EmployeeManager()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public EmployeeManager(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public bool Add(Employee entity)
        {
            return _employeeRepository.Add(entity);
        }

        public bool Update(Employee entity)
        {
            return _employeeRepository.Update(entity);
        }

        public bool Remove(long id)
        {
            return _employeeRepository.Remove(GetById(id));
        }

        public Employee GetById(long id)
        {
            return _employeeRepository.GetById(id);
        }

        public ICollection<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }
    }
}
