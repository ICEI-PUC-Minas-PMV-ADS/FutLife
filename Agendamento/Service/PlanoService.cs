using Agendamento.DataAccess;
using Agendamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agendamento.Service
{
    public class PlanoService
    {
        Context context = new Context();

        public int? GetAssinaturaUsuario(int idUsuario)
        {
           return context.Usuario_Plano.SingleOrDefault(x => x.Usuario_Id_Usuario == idUsuario)?.Id_Plano;
        }

        public void Assinar(int idPlano, int idUsuario)
        {
            var assinaturaUsuario = context.Usuario_Plano.Where(x => x.Usuario_Id_Usuario == idUsuario);

            if (assinaturaUsuario.Any())
            {
                context.Usuario_Plano.RemoveRange(assinaturaUsuario);
            }
            
            context.Usuario_Plano.Add(new Usuario_Plano
            {
                Id_Plano = idPlano,
                Usuario_Id_Usuario = idUsuario
            });

            context.SaveChanges();
        }
        
        public void RetirarAssinatura(int idUsuario)
        {
            var assinaturaUsuario = context.Usuario_Plano.Where(x => x.Usuario_Id_Usuario == idUsuario);

            if (assinaturaUsuario.Any())
            {
                context.Usuario_Plano.RemoveRange(assinaturaUsuario);
            }

            context.SaveChanges();
        }
    }
}