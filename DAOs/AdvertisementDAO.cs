using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public interface AdvertisementDAO
    {
        List<Advertisement> GetAllAdvertisements();
        Advertisement GetAdvertisementById(int id);
        bool AddAdvertisement(Advertisement advertisement);
        bool UpdateAdvertisement(Advertisement advertisement);
        bool DeleteAdvertisement(int id);
    }
}
