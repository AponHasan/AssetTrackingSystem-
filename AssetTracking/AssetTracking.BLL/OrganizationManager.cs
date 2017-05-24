using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.DAL;
using AssetTracking.Models.Interfaces;
using AssetTracking.Models.Interfaces.IModelManager;
using AssetTracking.Models.Models;

namespace AssetTracking.BLL
{
    public class OrganizationManager : IOrganizationManager
    {
        private IOrganizationRepository _organizationRepository;

        public OrganizationManager()
        {
            _organizationRepository = new OrganizationRepository();
        }

        public OrganizationManager(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }


        public bool Add(Organization entity)
        {
            return _organizationRepository.Add(entity);
        }

        public bool Update(Organization entity)
        {
            return _organizationRepository.Update(entity);
        }

        public bool Remove(long id)
        {
            return _organizationRepository.Remove(GetById(id));
        }

        public Organization GetById(long id)
        {
            return _organizationRepository.GetById(id);
        }

        public ICollection<Organization> GetAll()
        {
            return _organizationRepository.GetAll();
        }
    }
}
