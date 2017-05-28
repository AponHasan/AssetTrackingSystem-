using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.DAL;
using AssetTracking.Models.Interfaces.IModelManager;
using AssetTracking.Models.Interfaces.IModelRepository;
using AssetTracking.Models.Models;

namespace AssetTracking.BLL
{
    public class DesignationManager : IDesignationManager
    {
        private IDesignationRepository _designationRepository;
        public DesignationManager()
        {
            _designationRepository = new DesignationRepository();
        }
        public DesignationManager(IDesignationRepository designationRepository)
        {
            _designationRepository = designationRepository;
        }
        public bool Add(Designation entity)
        {
           return _designationRepository.Add(entity);
        }

        public bool Update(Designation entity)
        {
            return _designationRepository.Update(entity);           
        }

        public bool Remove(long id)
        {
            return _designationRepository.Remove(GetById(id));
        }

        public Designation GetById(long id)
        {
            return _designationRepository.GetById(id);
        }

        public ICollection<Designation> GetAll()
        {
            return _designationRepository.GetAll();
        }
    }
}
