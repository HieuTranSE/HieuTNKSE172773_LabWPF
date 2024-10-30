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
    public class KoiFishServiceImpl : KoiFishService
    {
        private readonly KoiFishRepository _koiFishRepository;

        public KoiFishServiceImpl()
        {
            _koiFishRepository = new KoiFishRepositoryImpl();
        }

        public List<KoiFish> GetAllKoiFish()
        {
            return _koiFishRepository.GetAllKoiFish();
        }

        public KoiFish GetKoiFishById(int id)
        {
            return _koiFishRepository.GetKoiFishById(id);
        }

        public bool AddKoiFish(KoiFish koiFish)
        {
            return _koiFishRepository.AddKoiFish(koiFish);
        }

        public bool UpdateKoiFish(KoiFish koiFish)
        {
            return _koiFishRepository.UpdateKoiFish(koiFish);
        }

        public bool DeleteKoiFish(int id)
        {
            return _koiFishRepository.DeleteKoiFish(id);
        }
    }
}
