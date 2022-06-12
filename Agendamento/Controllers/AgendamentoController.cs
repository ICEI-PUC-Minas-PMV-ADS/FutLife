using Agendamento.Models;
using Agendamento.Service;
using System;
using System.Web.Mvc;

namespace Agendamento.Controllers
{
    public class AgendamentoController : Controller
    {
        AgendamentoService service = new AgendamentoService();
        UsuarioService usuarioService = new UsuarioService();

        [HttpGet]
        public ActionResult Agendamento(int? reservaEspecifica)
        {
            try
            {
                var idUsuarioLogado = usuarioService.UsuarioLogado();

                if (idUsuarioLogado == 0)
                {
                    return RedirectToAction("Login", "Usuario");
                }

                var model = service.ListaAgendamento(idUsuarioLogado);

                ViewBag.ReservaEspecifica = reservaEspecifica;

                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult CriarReserva(Usuario_Agendamento novaReserva)
        {
            try
            {
                var idUsuarioLogado = usuarioService.UsuarioLogado();

                if (novaReserva.Id_Usuario_Agendamento == 0)
                {
                    service.CriarReserva(novaReserva, idUsuarioLogado);
                }
                else
                {
                    service.AlterarReserva(novaReserva, idUsuarioLogado);
                }                

                return RedirectToAction("Agendamento");
            }
            catch (Exception)
            {
                throw;
            }            
        }

        [HttpPost]
        public ActionResult AlterarCancelarReserva(int Id)
        {
            if (Request.Form["alterarReserva"] != null)
            {
                return RedirectToAction("Agendamento", new { reservaEspecifica = Id });
            }

            try
            {
                if (Request.Form["cancelarReserva"] != null)
                {
                    service.CancelarReserva(Id);
                }

                return RedirectToAction("Agendamento");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}