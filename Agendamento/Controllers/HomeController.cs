using Agendamento.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Agendamento.Controllers
{
    public class HomeController : Controller
    {   
        public ActionResult Pagamentos()
        {
            return View();

        }

        

        public ActionResult Cadastro()
        {
            return View();

        }                       

        public ActionResult Index()
        {
            return View();

        }
    }
}