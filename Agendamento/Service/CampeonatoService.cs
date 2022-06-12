using Agendamento.DataAccess;
using Agendamento.Models;
using System.Collections.Generic;
using System.Linq;

namespace Agendamento.Service
{
    public class CampeonatoService
    {
        Context context = new Context();

        public List<Usuario_Equipe> ListarEquipes(int? idUsuario = null)
        {
            var equipes = context.Usuario_Equipes.AsQueryable();

            if (idUsuario.HasValue)
            {
                equipes.Where(x => x.Usuario_Id_Usuario == idUsuario);
            }

            return equipes.ToList();
        }

        public void CriarEquipe(string nomeEquipe, List<Equipe_Integrante> equipe_Integrantes, int idUsuario)
        {
            var novaEquipe = new Usuario_Equipe()
            {
                Nome = nomeEquipe,
                Usuario_Id_Usuario = idUsuario
            };

            context.Usuario_Equipes.Add(novaEquipe);

            context.SaveChanges();

            equipe_Integrantes.ForEach(x => x.Usuario_Equipe_Id_Usuario_Equipe = novaEquipe.Id_Usuario_Equipe);

            context.Equipe_Integrantes.AddRange(equipe_Integrantes);

            context.SaveChanges();
        }

        public void RemoverEquipe(int idEquipe)
        {
            var equipe = context.Usuario_Equipes.Find(idEquipe);

            if (equipe != null)
            {
                context.Equipe_Integrantes.RemoveRange(equipe.Equipe_Integrante);
                context.Usuario_Equipes.Remove(equipe);
            }

            context.SaveChanges();
        }
    }
}