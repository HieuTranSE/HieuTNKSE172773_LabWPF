using BusinessObjects.Context;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs.Impl
{
    public class KoiFishDAOImpl : KoiFishDAO
    {
        private readonly KoiManagementSystemContext _context;

        private static KoiFishDAOImpl _instance = null;

        public static KoiFishDAOImpl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new KoiFishDAOImpl();
                }
                return _instance;
            }
        }

        public KoiFishDAOImpl()
        {
            _context = new KoiManagementSystemContext();
        }

        public List<KoiFish> GetAllKoiFish()
        {
            return _context.KoiFishes.ToList();
        }

        public KoiFish GetKoiFishById(int id)
        {
            return _context.KoiFishes.FirstOrDefault(x => x.KoiFishId == id);
        }

        public bool AddKoiFish(KoiFish koiFish)
        {
            bool isSuccess = false;
            try
            {
                _context.KoiFishes.Add(koiFish);
                _context.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                // Log exception if needed
            }
            return isSuccess;
        }

        public bool UpdateKoiFish(KoiFish koiFish)
        {
            bool isSuccess = false;
            try
            {
                _context.KoiFishes.Update(koiFish);
                _context.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                // Log exception if needed
            }
            return isSuccess;
        }

        public bool DeleteKoiFish(int id)
        {
            bool isSuccess = false;
            try
            {
                var koiFish = GetKoiFishById(id);
                if (koiFish != null)
                {
                    _context.KoiFishes.Remove(koiFish);
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
