using BusinessObjects.Models;
using Repositories;
using Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class AdvertisementServiceImpl : AdvertisementService
    {
        private readonly AdvertisementRepository _advertisementRepository;

        public AdvertisementServiceImpl()
        {
            _advertisementRepository = new AdvertisementRepositoryImpl();
        }

        public List<Advertisement> GetAllAdvertisements()
        {
            return _advertisementRepository.GetAllAdvertisements();
        }

        public Advertisement GetAdvertisementById(int id)
        {
            return _advertisementRepository.GetAdvertisementById(id);
        }

        public bool AddAdvertisement(Advertisement advertisement)
        {
            return _advertisementRepository.AddAdvertisement(advertisement);
        }

        public bool UpdateAdvertisement(Advertisement ads)
        {
            return _advertisementRepository.UpdateAdvertisement(ads);
        }

        public bool DeleteAdvertisement(int id)
        {
            return _advertisementRepository.DeleteAdvertisement(id);
        }

    }
}
