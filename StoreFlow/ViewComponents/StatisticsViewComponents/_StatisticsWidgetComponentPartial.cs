﻿using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents.StatisticsViewComponents
{
    public class _StatisticsWidgetComponentPartial : ViewComponent
    {
        private readonly StoreContext _context;
        public _StatisticsWidgetComponentPartial(StoreContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.categoryCount = _context.Categories.Count();
            ViewBag.productMaxPrice = Math.Round(_context.Products.Max(x => x.ProductPrice), 2);
            ViewBag.productMinPrice = Math.Round(_context.Products.Min(x => x.ProductPrice), 2);

            ViewBag.productMaxPriceProductName = _context.Products
                .Where(x => x.ProductPrice == (_context.Products.Max(y => y.ProductPrice)))
                .Select(z => z.ProductName)
                .FirstOrDefault();

            ViewBag.productMinPriceProductName = _context.Products
                .Where(x => x.ProductPrice == (_context.Products.Min(y => y.ProductPrice)))
                .Select(z => z.ProductName)
                .FirstOrDefault();

            ViewBag.totalSumProductStock = _context.Products.Sum(x => x.ProductStock);
            ViewBag.averageProductStock = Math.Round(_context.Products.Average(x => x.ProductStock), 2);
            ViewBag.averageProductPrice = Math.Round(_context.Products.Average(x => x.ProductPrice), 2);

            ViewBag.biggerPriceThen1000ProductCount = _context.Products.Where(x => x.ProductPrice > 1000).Count();
            ViewBag.getIDIs4ProductName = _context.Products.Where(x => x.ProductId == 4).Select(y => y.ProductName).FirstOrDefault();
            ViewBag.stockCountBigger50AndSmaller100ProductCount = _context.Products.Where(x => x.ProductStock > 50 && x.ProductStock < 100).Count();

            return View();
        }

    }
}
