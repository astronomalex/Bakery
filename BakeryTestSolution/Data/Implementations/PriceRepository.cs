using System;
using BakeryTestSolution.Data.Interfaces;
using BakeryTestSolution.Data.Models;

namespace BakeryTestSolution.Data.Implementations
{
    public class PriceRepository : IPriceRepository
    {
        public decimal getPrice(Bun bun)
        {
            switch (bun.Category.Name)
            {
                case "Круасан":
                {
                    return 150;
                }
                case "Багет":
                {
                    return 100;
                }
                case "Крендель":
                {
                    return 90;
                }
                case "Батон":
                {
                    return 120;
                }
                case "Сметанник":
                {
                    return 70;
                }
            }

            throw new InvalidOperationException();
        }

        public decimal getActualPrice(Bun bun)
        {
            var now = DateTime.Now;
            switch (bun.Category.Name)
            {
                case "Круасан" 
                    or "Багет" 
                    or "Батон":
                {
                    var quantityHours = (now - bun.TimeManufacture).Hours;
                    var price = getPrice(bun);
                    return price - price * 2 / 100 * quantityHours;
                }
                case "Крендель":
                {
                    var price = getPrice(bun);
                    if (Pretzel.ControlPeriod < now - bun.TimeManufacture) return price / 2;

                    return price;
                }
                case "Сметанник":
                {
                    var quantityHours = (now - bun.TimeManufacture).Hours;
                    var price = getPrice(bun);
                    return price - price * 4 / 100 * quantityHours;
                }
            }

            throw new InvalidOperationException();
        }

        public decimal getNextPrice(Bun bun)
        {
            var now = DateTime.Now;
            switch (bun.Category.Name)
            {
                case "Круасан":
                {
                    var quantityHours = (now - bun.TimeManufacture).Hours + 1;
                    var price = getPrice(bun);
                    if (quantityHours >= Croissant.ExpirationDateHours.TotalHours)
                        return 0;
                    return price - price * 2 / 100 * quantityHours;
                }
                case "Багет":
                {
                    var quantityHours = (now - bun.TimeManufacture).Hours + 1;
                    var price = getPrice(bun);
                    if (quantityHours >= Baguette.ExpirationDateHours.TotalHours)
                        return 0;
                    return price - price * 2 / 100 * quantityHours;
                }
                case "Батон":
                {
                    var quantityHours = (now - bun.TimeManufacture).Hours + 1;
                    var price = getPrice(bun);
                    if (quantityHours >= Loaf.ExpirationDateHours.TotalHours)
                        return 0;
                    return price - price * 2 / 100 * quantityHours;
                }
                case "Крендель":
                {
                    var price = getPrice(bun);
                    if (Pretzel.ControlPeriod < now - bun.TimeManufacture) return 0;

                    return price / 2;
                }
                case "Сметанник":
                {
                    var quantityHours = (now - bun.TimeManufacture).Hours + 1;
                    var price = getPrice(bun);
                    if (quantityHours >= SourCreamBun.ExpirationDateHours.TotalHours)
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
                    if (bun.TimeManufacture + Pretzel.ControlPeriod > now)
                        return bun.TimeManufacture + Pretzel.ControlPeriod;
                    return bun.TimeManufacture + Pretzel.ExpirationDateHours;
                }
            }

            throw new InvalidOperationException();
        }
    }
}