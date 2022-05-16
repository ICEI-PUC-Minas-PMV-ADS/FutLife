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
        public string ArquivoEnderecoNome
        {
            get
            {
                return $"{AppDomain.CurrentDomain.BaseDirectory}Content\\Storage\\Dados.json";
            }
        }

        private List<DadosAgendamento> LerArquivoReservas()
        {
            if (System.IO.File.Exists(ArquivoEnderecoNome))
            {
                string currentStorage = System.IO.File.ReadAllText(ArquivoEnderecoNome);

                return JsonConvert.DeserializeObject<List<DadosAgendamento>>(currentStorage);
            }
            else
                return new List<DadosAgendamento>();
        }

        private void GravarArquivoReservas(List<DadosAgendamento> listaReservas)
        {
            string json = JsonConvert.SerializeObject(listaReservas);
            System.IO.File.WriteAllText(ArquivoEnderecoNome, json);
        }

        [HttpGet]
        public ActionResult Agendamento(int? reservaEspecifica)
        {
            var model = LerArquivoReservas();

            ViewBag.ReservaEspecifica = reservaEspecifica;

            return View(model);
        }

        [HttpPost]
        public ActionResult CriarReserva(DadosAgendamento novaReserva)
        {
            var reservas = LerArquivoReservas();

            if (novaReserva.Id != 0)
            {
                var reserva = reservas.FirstOrDefault(x => x.Id == novaReserva.Id);
                reserva.Nome = novaReserva.Nome;
                reserva.Sobrenome = novaReserva.Sobrenome;
                reserva.Quadra = novaReserva.Quadra;
                reserva.Horario = novaReserva.Horario;
                reserva.Jogadores = novaReserva.Jogadores;
            }
            else
            {
                int maxId = 0;

                if (reservas != null && reservas.Count > 0)
                    maxId = reservas.Max(x => x.Id);

                novaReserva.Id = maxId + 1;

                reservas.Add(novaReserva);
            }

            if (reservas.Count > 3)
            {
                var antigaReserva = reservas.Min(x => x.Id);
                reservas.RemoveAll(x => x.Id == antigaReserva);
            }

            GravarArquivoReservas(reservas);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AlterarCancelarReserva(DadosAgendamento model)
        {
            if (Request.Form["alterarReserva"] != null)
            {
                return RedirectToAction("Index", new { reservaEspecifica = model.Id });
            }

            if (Request.Form["cancelarReserva"] != null)
            {
                var reservas = LerArquivoReservas();

                reservas.RemoveAll(x => x.Id == model.Id);

                GravarArquivoReservas(reservas);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Pagamentos()
        {
            return View();

        }

        public ActionResult Perfil()
        {
            return View();

        }

        public ActionResult Cadastro()
        {
            return View();

        }

        public ActionResult Campeonato()
        {
            return View();

        }

        public ActionResult Login()
        {
            return View();

        }

        public ActionResult Planos()
        {
            return View();

        }

        public ActionResult Index()
        {
            return View();

        }
    }
}