using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public interface FengshuiElementDAO
    {
        List<FengShuiElement> GetAllFengShuiElements();           
        FengShuiElement GetFengShuiElementById(int id);           
        bool AddFengShuiElement(FengShuiElement fengShuiElement); 
        bool UpdateFengShuiElement(FengShuiElement fengShuiElement); 
        bool DeleteFengShuiElement(int id);
    }
}
