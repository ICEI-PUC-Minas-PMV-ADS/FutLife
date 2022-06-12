using Agendamento.DataAccess;
using Agendamento.Models;
using System;
using System.Linq;
using System.Web;

namespace Agendamento.Service
{
    public class UsuarioService
    {
        private const string COOKIE_KEY_LOGGED = "logged";
        Context context = new Context();

        public void Cadastrar(Usuario dados)
        {
            context.Usuarios.Add(dados);

            context.SaveChanges();
        }

        public void RealizarLogin(Usuario dados)
        {
            Usuario usuario = context.Usuarios.AsNoTracking().SingleOrDefault(x => x.Login == dados.Login && x.Senha == dados.Senha);

            if (usuario != null)
            {
                HttpCookie logged = new HttpCookie(COOKIE_KEY_LOGGED);
                logged.Value = usuario.Id_Usuario.ToString();
                logged.Expires = DateTime.Now.AddMinutes(30);

                HttpContext.Current.Response.Cookies.Set(logged);
            }
            else
            {
                throw new Exception("Usuário/Senha inválido");
            }
        }

        public int UsuarioLogado()
        {
            var cookieLogged = HttpContext.Current.Request.Cookies.Get(COOKIE_KEY_LOGGED);
            int cookieLoggedValue = 0;

            if (cookieLogged != null)
            {
                int.TryParse(cookieLogged.Value, out cookieLoggedValue);
            }

            return cookieLoggedValue;
        }

        public Usuario GetDadosUsuario(int idUsuario)
        {
            return context.Usuarios.Find(idUsuario);
        }
    }
}