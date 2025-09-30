using Microsoft.AspNetCore.Mvc;
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
            ViewBag.categoryCount = _context.Categories.Count();//kategori sayısı   
            ViewBag.productMaxPrice = _context.Products.Max(x => x.ProductPrice);//en yüksek fiyat
            ViewBag.productMinPrice = _context.Products.Min(x => x.ProductPrice);//en düşük fiyat

            ViewBag.productMaxPriceProductName = _context.Products.Where(x => x.ProductPrice == (_context.Products.Max(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();//en yüksek fiyatlı ürünün adı

            ViewBag.productMinPriceProductName = _context.Products.Where(x => x.ProductPrice == (_context.Products.Min(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();//en düşük fiyatlı ürünün adı


            ViewBag.totalSumProductStock = _context.Products.Sum(x => x.ProductStock);//toplam stok sayısı
            ViewBag.averageProductStock = _context.Products.Average(x => x.ProductStock);//ortalama stok sayısı
            ViewBag.averageProductPrice = _context.Products.Average(x => x.ProductPrice);// ortalama ürün fiyatı


            ViewBag.biggerPriceThen1000ProductCount = _context.Products.Where(x => x.ProductPrice > 1000).Count();//fiyatı 1000 den büyük ürün sayısı
            ViewBag.getIDIs4ProductName=_context.Products.Where(x=>x.ProductId==4).Select(y=>y.ProductName).FirstOrDefault();//id si 4 olan ürünün adı
            ViewBag.stockCountBigger50AndSmaller100ProductCount = _context.Products.Where(x => x.ProductStock > 50 && x.ProductStock < 100).Count();//stok sayısı 50 den büyük 100 den küçük ürün sayısı


            return View();
        }
    }
}
