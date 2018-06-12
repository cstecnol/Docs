﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRNotify.Models;

namespace SignalRNotify.Controllers
{
    public class HomeController : Controller
    {
        IHubContext<NotificationHub> _hubContext;

        public HomeController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            _hubContext.Clients.All.SendAsync("notify", $"Home page loaded at: {DateTime.Now}");
            return View();
        }

        [Route("notification")]
        public IActionResult Test()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
