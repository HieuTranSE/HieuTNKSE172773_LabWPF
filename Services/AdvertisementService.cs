using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface AdvertisementService
    {
        List<Advertisement> GetAllAdvertisements();                // Lấy tất cả quảng cáo
        Advertisement GetAdvertisementById(int id);               // Lấy quảng cáo theo ID
        bool AddAdvertisement(Advertisement advertisement);        // Thêm quảng cáo mới
        bool UpdateAdvertisement(Advertisement advertisement);     // Cập nhật quảng cáo
        bool DeleteAdvertisement(int id);
    }
}
