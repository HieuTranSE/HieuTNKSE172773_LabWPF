using BusinessObjects.Context;
using BusinessObjects.Models;
using DAOs;
using DAOs.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Impl
{
    public class KoiFishRepositoryImpl : KoiFishRepository
    {
        public bool AddKoiFish(KoiFish koiFish)
        {
            return KoiFishDAOImpl.Instance.AddKoiFish(koiFish);
        }

        public bool DeleteKoiFish(int id)
        {
            return KoiFishDAOImpl.Instance.DeleteKoiFish(id);
        }

        public List<KoiFish> GetAllKoiFish()
        {
            return KoiFishDAOImpl.Instance.GetAllKoiFish();
        }

        public KoiFish GetKoiFishById(int id)
        {
            return KoiFishDAOImpl.Instance.GetKoiFishById(id);
        }

        public bool UpdateKoiFish(KoiFish koiFish)
        {
            return KoiFishDAOImpl.Instance.UpdateKoiFish(koiFish);
        }
    }
}
