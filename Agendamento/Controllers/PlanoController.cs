using Agendamento.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agendamento.Controllers
{
    public class PlanoController : Controller
    {
        PlanoService service = new PlanoService();
        UsuarioService usuarioService = new UsuarioService();

        public ActionResult Planos()
        {
            var idUsuarioLogado = usuarioService.UsuarioLogado();

            if (idUsuarioLogado == 0)
            {
                return RedirectToAction("Login", "Usuario");
            }

            ViewBag.PlanoUsuario = service.GetAssinaturaUsuario(idUsuarioLogado);

            return View();
        }

        public ActionResult Assinar(int idPlano)
        {
            try
            {
                var idUsuarioLogado = usuarioService.UsuarioLogado();

                if (idUsuarioLogado == 0)
                {
                    return RedirectToAction("Login", "Usuario");
                }

                service.Assinar(idPlano, idUsuarioLogado);

                return RedirectToAction("Pagamentos", "Home");
            }
            catch (Exception)
            {

                throw;
            }            
        }

        public ActionResult RetirarAssinatura()
        {
            try
            {
                var idUsuarioLogado = usuarioService.UsuarioLogado();

                if (idUsuarioLogado == 0)
                {
                    return RedirectToAction("Login", "Usuario");
                }

                service.RetirarAssinatura(idUsuarioLogado);

                return RedirectToAction("Planos");
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}