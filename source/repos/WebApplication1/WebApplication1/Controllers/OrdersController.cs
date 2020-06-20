using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Responses;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly ClientDbContext _context;
        public OrdersController(ClientDbContext context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult GetOrders(string lastName) {
            if (lastName == null)
            {
                var orders = _context.Zamówienia.ToList();
                return Ok(orders);
            }
            else
            { 
            var orders = _context.Zamówienia
                .Where(z => z.Klient.Nazwisko == lastName)
                .ToList();
            return Ok(orders);
            }
        }
        [HttpPost]
        public IActionResult CreateOrder(CreateDtoRequest request)
        {
            if (request.Wyroby.Count == 0)
                return BadRequest("Zamowienie musi miec min. jeden wyrob");

            foreach (var i in request.Wyroby)
            {
                if (!_context.WyrobCukierniczy.Any(s => s.Nazwa == i.Wyrob))
                {
                    return BadRequest("Podanie nieistniejący wyroby");
                }
            }

            var wyroby = _context.WyrobCukierniczy
                .Where(w => request.Wyroby.Any(r => r.Wyrob == w.Nazwa))
                .ToList();

            
            var newOrder = new Zamówienie
            {
                DataPrzyjecia = request.DataPrzyjecia,
                Uwagi = request.Uwagi//,
                //ZamowienieWyrob = new List<Zamowienie_WyrobCukierniczy>
            };

            var newOrderProduct = request.Wyroby.Select(w => new Zamowienie_WyrobCukierniczy
            {
                Ilosc = w.Ilosc,
                Uwagi = w.Uwagi,
                Zamowienie = newOrder,
                Wyrob = _context.WyrobCukierniczy.Where(ww => ww.Nazwa == w.Wyrob).First()

            });

            _context.Zamówienia.Add(newOrder);

            _context.SaveChanges();

            return Ok();
        }
    }
}