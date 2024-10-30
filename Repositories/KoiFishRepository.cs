using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface KoiFishRepository
    {
        List<KoiFish> GetAllKoiFish();
        KoiFish GetKoiFishById(int id);
        bool AddKoiFish(KoiFish koiFish);
        bool UpdateKoiFish(KoiFish koiFish);
        bool DeleteKoiFish(int id);
    }
}
