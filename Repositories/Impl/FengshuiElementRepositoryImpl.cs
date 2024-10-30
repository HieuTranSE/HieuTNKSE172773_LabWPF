using BusinessObjects.Models;
using DAOs.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Impl
{
    public class FengshuiElementRepositoryImpl : FengshuiElementRepository
    {
        public bool AddFengShuiElement(FengShuiElement fengShuiElement)
        {
            return FengshuiElementDAOImpl.Instance.AddFengShuiElement(fengShuiElement);
        }

        public bool DeleteFengShuiElement(int id)
        {
            return FengshuiElementDAOImpl.Instance.DeleteFengShuiElement(id);
        }

        public List<FengShuiElement> GetAllFengShuiElements()
        {
            return FengshuiElementDAOImpl.Instance.GetAllFengShuiElements();
        }

        public FengShuiElement GetFengShuiElementById(int id)
        {
            return FengshuiElementDAOImpl.Instance.GetFengShuiElementById(id);
        }

        public bool UpdateFengShuiElement(FengShuiElement fengShuiElement)
        {
            return FengshuiElementDAOImpl.Instance.UpdateFengShuiElement(fengShuiElement);
        }
    }
}
