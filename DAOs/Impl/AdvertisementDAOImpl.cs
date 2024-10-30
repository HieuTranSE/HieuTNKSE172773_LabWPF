using BusinessObjects.Context;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs.Impl
{
    public class AdvertisementDAOImpl : AdvertisementDAO
    {
        private readonly KoiManagementSystemContext _context;

        private static AdvertisementDAOImpl _instance = null;

        public static AdvertisementDAOImpl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AdvertisementDAOImpl();
                }
                return _instance;
            }
        }

        public AdvertisementDAOImpl()
        {
            _context = new KoiManagementSystemContext();
        }

        public List<Advertisement> GetAllAdvertisements()
        {
            return _context.Advertisements.ToList();
        }

        public Advertisement GetAdvertisementById(int id)
        {
            return _context.Advertisements.FirstOrDefault(x => x.AdvertisementId == id);
        }

        public bool AddAdvertisement(Advertisement advertisement)
        {
            bool isSuccess = false;
            try
            {
                _context.Advertisements.Add(advertisement);
                _context.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                // Log exception if needed
            }
            return isSuccess;
        }

        public bool UpdateAdvertisement(Advertisement advertisement)
        {
            bool isSuccess = false;
            try
            {
                _context.Advertisements.Update(advertisement);
                _context.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                // Log exception if needed
            }
            return isSuccess;
        }

        public bool DeleteAdvertisement(int id)
        {
            bool isSuccess = false;
            try
            {
                var advertisement = GetAdvertisementById(id);
                if (advertisement != null)
                {
                    _context.Advertisements.Remove(advertisement);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                // Log exception if needed
            }
            return isSuccess;
        }
    }
}
