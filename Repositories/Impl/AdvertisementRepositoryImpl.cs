using BusinessObjects.Context;
using BusinessObjects.Models;
using DAOs.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Impl
{
    public class AdvertisementRepositoryImpl : AdvertisementRepository
    {
        public bool AddAdvertisement(Advertisement advertisement)
        {
            return AdvertisementDAOImpl.Instance.AddAdvertisement(advertisement);
        }

        public bool DeleteAdvertisement(int id)
        {
            return AdvertisementDAOImpl.Instance.DeleteAdvertisement(id);
        }

        public Advertisement GetAdvertisementById(int id)
        {
            return AdvertisementDAOImpl.Instance.GetAdvertisementById(id);
        }

        public List<Advertisement> GetAllAdvertisements()
        {
            return AdvertisementDAOImpl.Instance.GetAllAdvertisements();
        }

        public bool UpdateAdvertisement(Advertisement advertisement)
        {
            return AdvertisementDAOImpl.Instance.UpdateAdvertisement(advertisement);
        }

    }
}
