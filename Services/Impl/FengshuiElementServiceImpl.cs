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
    public class FengshuiElementServiceImpl : FengshuiElementService
    {
        private readonly FengshuiElementRepository _fengshuiElementRepository;

        public FengshuiElementServiceImpl()
        {
            _fengshuiElementRepository = new FengshuiElementRepositoryImpl();
        }

        public List<FengShuiElement> GetAllFengShuiElements()
        {
            // Retrieve all Feng Shui elements from the repository
            return _fengshuiElementRepository.GetAllFengShuiElements();
        }

        public FengShuiElement GetFengShuiElementById(int id)
        {
            // Retrieve a Feng Shui element by ID, possibly with validation
            return _fengshuiElementRepository.GetFengShuiElementById(id);
        }

        public bool AddFengShuiElement(FengShuiElement fengShuiElement)
        {
            // Optionally, add some business validation here
            if (fengShuiElement == null || string.IsNullOrWhiteSpace(fengShuiElement.ElementName))
            {
                return false; // Validation failed
            }

            // Add the Feng Shui element using the repository
            return _fengshuiElementRepository.AddFengShuiElement(fengShuiElement);
        }

        public bool UpdateFengShuiElement(FengShuiElement fengShuiElement)
        {
            // Optionally, add some business validation here
            if (fengShuiElement == null || fengShuiElement.ElementId <= 0)
            {
                return false; // Validation failed
            }

            // Update the Feng Shui element using the repository
            return _fengshuiElementRepository.UpdateFengShuiElement(fengShuiElement);
        }

        public bool DeleteFengShuiElement(int id)
        {
            // Optionally, perform checks before deletion
            if (id <= 0)
            {
                return false; // Invalid ID
            }

            // Delete the Feng Shui element using the repository
            return _fengshuiElementRepository.DeleteFengShuiElement(id);
        }
    }
}
