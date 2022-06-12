using Agendamento.Models;
using Agendamento.Service;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Agendamento.Controllers
{
    public class CampeonatoController : Controller
    {
        CampeonatoService service = new CampeonatoService();
        UsuarioService usuarioService = new UsuarioService();

        [HttpGet]
        public ActionResult Campeonato()
        {
            var idUsuarioLogado = usuarioService.UsuarioLogado();

            if (idUsuarioLogado == 0)
            {
                return RedirectToAction("Login", "Usuario");
            }

            List<Usuario_Equipe> model = service.ListarEquipes();

            return View(model);
        }

        [HttpPost]
        public ActionResult CriarEquipe()
        {
            try
            {
                var idUsuarioLogado = usuarioService.UsuarioLogado();

                List<Equipe_Integrante> equipe_Integrantes = new List<Equipe_Integrante>();

                var nomeEquipe = Request.Form.Get("NomeEquipe");

                foreach (string item in Request.Form)
                {
                    if (item != "NomeEquipe")
                    {
                        equipe_Integrantes.Add(new Equipe_Integrante()
                        {
                            Nome_Integrante = Request.Form.Get(item),
                            Posicao = item
                        });
                    }
                }

                service.CriarEquipe(nomeEquipe, equipe_Integrantes, idUsuarioLogado);

                return RedirectToAction("Campeonato");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult RemoverEquipe(int idEquipe)
        {
            try
            {
                service.RemoverEquipe(idEquipe);

                return RedirectToAction("Campeonato");
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}