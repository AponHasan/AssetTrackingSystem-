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
    public class DepartmentManager:IDepartmentManager
    {
        public DepartmentRepository _departmentRepository;

        public DepartmentManager()
        {
            _departmentRepository = new DepartmentRepository();
        }

        public DepartmentManager(DepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public bool Add(Department entity)
        {
            return _departmentRepository.Add(entity);
        }

        public bool Update(Department entity)
        {
            return _departmentRepository.Update(entity);
        }

        public bool Remove(long id)
        {
            return _departmentRepository.Remove(GetById(id));
        }

        public Department GetById(long id)
        {
            return _departmentRepository.GetById(id);
        }

        public ICollection<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }
    }
}
