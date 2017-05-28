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
    public class AssetLocationManager:IAssetLocationManager
    {
        private AssetLocationRepository _assetLocationRepository;

        public AssetLocationManager()
        {
            _assetLocationRepository = new AssetLocationRepository();
        }

        public AssetLocationManager(AssetLocationRepository assetLocationRepository)
        {
            _assetLocationRepository = assetLocationRepository;
        }
        public bool Add(AssetLocation entity)
        {
            return _assetLocationRepository.Add(entity);
        }

        public bool Update(AssetLocation entity)
        {
            return _assetLocationRepository.Update(entity);
        }

        public bool Remove(long id)
        {
            return _assetLocationRepository.Remove(GetById(id));
        }

        public AssetLocation GetById(long id)
        {
            return _assetLocationRepository.GetById(id);
        }

        public ICollection<AssetLocation> GetAll()
        {
            return _assetLocationRepository.GetAll();
        }
    }
}
