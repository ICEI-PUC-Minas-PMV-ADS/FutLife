using Agendamento.Models;
using Agendamento.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agendamento.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioService service = new UsuarioService();
        AgendamentoService agendamentoService = new AgendamentoService();
        CampeonatoService campeonatoService = new CampeonatoService();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario dados)
        {
            try
            {
                service.RealizarLogin(dados);
                return RedirectToAction("Perfil");
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public ActionResult Perfil()
        {
            var idUsuarioLogado = service.UsuarioLogado();

            if (idUsuarioLogado == 0)
            {
                return RedirectToAction("Login");
            }

            var perfil = new Perfil();

            perfil.Agendamentos = agendamentoService.ListaAgendamento(idUsuarioLogado);
            perfil.Equipes = campeonatoService.ListarEquipes(idUsuarioLogado);
            perfil.Usuario = service.GetDadosUsuario(idUsuarioLogado);

            return View(perfil);
        }

        public ActionResult Cadastro(Usuario dados)
        {
            try
            {
                service.Cadastrar(dados);
                return RedirectToAction("Perfil");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}