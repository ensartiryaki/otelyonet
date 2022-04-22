using Microsoft.AspNetCore.Mvc;
using otelyonet.Data;
using otelyonet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace otelyonet.Controllers
{
    public class OlRezervasyonController : Controller
    {
        private readonly OtelYonetDBContext _context;

        public OlRezervasyonController(OtelYonetDBContext context)
        {
            _context = context;
        }


        public IActionResult Index(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            return View();
        }
       
         // POST: Rezervasyons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("RezervasyonID,MüşteriID,OdaID,ÖdemeTipiID,BasTarih,BitTarih,YetişkinSayısı,ÇocukSayısı,BebekSayısı,RezervOdaFiyatı,RezervasyonTarihi")] Rezervasyon rezervasyon,int? id)
        {
            rezervasyon.MüşteriID = 2;
            rezervasyon.ÖdemeTipiID = 2;

            Random rastgele= new Random();
            int atlama= rastgele.Next(1, _context.OdaÖzellikleri.Where(a => a.OdaTipiID == id).Count()); // rasgele sayı üretecek. 1 ile oda tipindeki oda sayısı arasında bir sayı üretir.
            rezervasyon.OdaID = _context.OdaÖzellikleri.Where(a => a.OdaTipiID == id).Skip(atlama).Take(1).First().OdaID; //rasgele sayı kadar skip öteleme yapar. ve sonraki ilk kaydın odaidsini bulur ve atar.

            rezervasyon.RezervOdaFiyatı = _context.Odalar.FirstOrDefault(a => a.OdaID == rezervasyon.OdaID).OdaFiyatı;
            rezervasyon.RezervasyonTarihi = DateTime.Today;



            rezervasyon.BasTarih = Convert.ToDateTime(Request.Form["BasTarih"].ToString().Replace("<span class=", "").Replace("day>", "").Replace("month>", "").Replace("year>", "").Replace("</span>", ""));
            rezervasyon.BitTarih = Convert.ToDateTime(Request.Form["BitTarih"].ToString().Replace("<span class=", "").Replace("day>", "").Replace("month>", "").Replace("year>", "").Replace("</span>", ""));

            
           

            


            //if (ModelState.IsValid)
            //{
                _context.Add(rezervasyon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            
            
            
            //return View(rezervasyon);
        }




    }
}
