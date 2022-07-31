using System;
using BakeryTestSolution.Data.Interfaces;
using BakeryTestSolution.Data.Models;

namespace BakeryTestSolution.Data.Implementations
{
    public class PriceService : IPriceService
    {
        private readonly ICategoryRepository _categoryRepository;

        public PriceService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public decimal getActualPrice(Bun bun)
        {
            var now = DateTime.Now;
            if ((now - bun.TimeManufacture).TotalHours > bun.Category.ExpirationDateHours.TotalHours) return 0;
            switch (bun.Category.Name)
            {
                case "Круасан" 
                    or "Багет" 
                    or "Батон":
                {
                    var quantityHours = (now - bun.TimeManufacture).Hours;
                    var price = bun.Category.Price;
                    return price - price * 2 / 100 * quantityHours;
                }
                case "Крендель":
                {
                    var price = bun.Category.Price;
                    if (bun.Category.ControlPeriodHours < now - bun.TimeManufacture) return price / 2;

                    return price;
                }
                case "Сметанник":
                {
                    var quantityHours = (now - bun.TimeManufacture).Hours;
                    var price = bun.Category.Price;
                    return price - price * 4 / 100 * quantityHours;
                }
            }

            throw new InvalidOperationException();
        }

        public decimal getNextPrice(Bun bun)
        {
            var now = DateTime.Now;
            var price = bun.Category.Price;
            switch (bun.Category.Name)
            {
                case "Круасан":
                {
                    var quantityHours = (now - bun.TimeManufacture).Hours + 1;
                    
                    if (quantityHours >= bun.Category.ExpirationDateHours.TotalHours)
                        return 0;
                    return price - price * 2 / 100 * quantityHours;
                }
                case "Багет":
                {
                    var quantityHours = (now - bun.TimeManufacture).Hours + 1;
                    if (quantityHours >= bun.Category.ExpirationDateHours.TotalHours)
                        return 0;
                    return price - price * 2 / 100 * quantityHours;
                }
                case "Батон":
                {
                    var quantityHours = (now - bun.TimeManufacture).Hours + 1;
                    if (quantityHours >= bun.Category.ExpirationDateHours.TotalHours)
                        return 0;
                    return price - price * 2 / 100 * quantityHours;
                }
                case "Крендель":
                {
                    if (bun.Category.ControlPeriodHours < now - bun.TimeManufacture) return 0;

                    return price / 2;
                }
                case "Сметанник":
                {
                    var quantityHours = (now - bun.TimeManufacture).Hours + 1;
                    if (quantityHours >= bun.Category.ExpirationDateHours.TotalHours)
                        return 0;
                    return price - price * 4 / 100 * quantityHours;
                }
            }

            throw new InvalidOperationException();
        }

        public DateTime getNextChangePrice(Bun bun)
        {
            var now = DateTime.Now;
            switch (bun.Category.Name)
            {
                case "Круасан" 
                    or "Багет" 
                    or "Батон" 
                    or "Сметанник":
                {
                    var timeLife = now - bun.TimeManufacture;
                    var t = 60 - timeLife.Minutes;
                    var res = now + TimeSpan.FromMinutes(t);
                    return res;
                }
                case "Крендель":
                {
                    if (bun.TimeManufacture + bun.Category.ControlPeriodHours > now)
                        return bun.TimeManufacture + bun.Category.ControlPeriodHours;
                    return bun.TimeManufacture + bun.Category.ExpirationDateHours;
                }
            }

            throw new InvalidOperationException();
        }
    }
}