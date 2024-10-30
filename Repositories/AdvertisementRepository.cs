using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface AdvertisementRepository
    {
        List<Advertisement> GetAllAdvertisements();                // Lấy tất cả quảng cáo
        Advertisement GetAdvertisementById(int id);               // Lấy quảng cáo theo ID
        bool AddAdvertisement(Advertisement advertisement);       // Thêm quảng cáo mới
        bool UpdateAdvertisement(Advertisement ads);             // Cập nhật quảng cáo
        bool DeleteAdvertisement(int id);
    }
}
