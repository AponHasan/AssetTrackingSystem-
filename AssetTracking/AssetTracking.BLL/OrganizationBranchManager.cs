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
    public class OrganizationBranchManager:IOrganizationBranchManager
    {
        private OrganizationBranchRepository _organizationBranchRepository;

        public OrganizationBranchManager()
        {
            _organizationBranchRepository = new OrganizationBranchRepository();
        }

        public OrganizationBranchManager(OrganizationBranchRepository organizationBranchRepository)
        {
            _organizationBranchRepository = organizationBranchRepository;
        }


        public bool Add(OrganizationBranch entity)
        {
            return _organizationBranchRepository.Add(entity);
        }

        public bool Update(OrganizationBranch entity)
        {
            return _organizationBranchRepository.Update(entity);
        }

        public bool Remove(long id)
        {
            return _organizationBranchRepository.Remove(GetById(id));
        }

        public OrganizationBranch GetById(long id)
        {
            return _organizationBranchRepository.GetById(id);
        }

        public ICollection<OrganizationBranch> GetAll()
        {
            return _organizationBranchRepository.GetAll();
        }
    }
}
