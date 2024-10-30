using BusinessObjects.Context;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs.Impl
{
    public class FengshuiElementDAOImpl : FengshuiElementDAO
    {
        private readonly KoiManagementSystemContext _context;

        private static FengshuiElementDAOImpl _instance = null;

        public static FengshuiElementDAOImpl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FengshuiElementDAOImpl();
                }
                return _instance;
            }
        }

        public FengshuiElementDAOImpl()
        {
            _context = new KoiManagementSystemContext();
        }

        public bool AddFengShuiElement(FengShuiElement fengShuiElement)
        {
            try
            {
                _context.FengShuiElements.Add(fengShuiElement);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteFengShuiElement(int id)
        {
            try
            {
                var fengShuiElement = GetFengShuiElementById(id);
                if (fengShuiElement != null)
                {
                    _context.FengShuiElements.Remove(fengShuiElement);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<FengShuiElement> GetAllFengShuiElements()
        {
            try
            {
                return _context.FengShuiElements.ToList();
            }
            catch (Exception)
            {
                return new List<FengShuiElement>();
            }
        }

        public FengShuiElement GetFengShuiElementById(int id)
        {
            try
            {
                return _context.FengShuiElements.FirstOrDefault(e => e.ElementId == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateFengShuiElement(FengShuiElement fengShuiElement)
        {
            try
            {
                _context.FengShuiElements.Update(fengShuiElement);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
