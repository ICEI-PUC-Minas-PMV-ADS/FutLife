using Agendamento.DataAccess;
using Agendamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agendamento.Service
{
    public class AgendamentoService
    {
        Context context = new Context();

        public List<Usuario_Agendamento> ListaAgendamento(int idUsuario)
        {
            return context.Usuario_Agendamento
                .Where(x => x.Usuario_Id_Usuario == idUsuario).ToList();
            //.Select(x => new DadosAgendamento()
            //{
            //    Id = x.Id_Usuario_Agendamento,
            //    Quadra = x.Id_Quadra.ToString(),
            //    Horario = x.Horario.ToString(),
            //    Jogadores = x.Jogadores.ToString(),
            //    Nome = x.Usuario.Nome,
            //    Sobrenome = x.Usuario.Sobrenome
            //})

        }

        public void CriarReserva(Usuario_Agendamento dadosAgendamento, int idUsuario)
        {
            //context.Usuario_Agendamento.Add(new Usuario_Agendamento()
            //{
            //    Id_Quadra = int.Parse(dadosAgendamento.Quadra),
            //    Horario = DateTime.Parse(dadosAgendamento.Horario),
            //    Jogadores = byte.Parse(dadosAgendamento.Jogadores),
            //    Usuario_Id_Usuario = idUsuario
            //});

            dadosAgendamento.Usuario_Id_Usuario = idUsuario;

            context.Usuario_Agendamento.Add(dadosAgendamento);

            context.SaveChanges();
        }

        public void AlterarReserva(Usuario_Agendamento dadosAgendamento, int idUsuario)
        {
            var reserva = context.Usuario_Agendamento.Find(dadosAgendamento.Id_Usuario_Agendamento);

            //reserva.Id_Quadra = int.Parse(dadosAgendamento.Quadra);
            //reserva.Horario = DateTime.Parse(dadosAgendamento.Horario);
            //reserva.Jogadores = byte.Parse(dadosAgendamento.Jogadores);
            reserva.Usuario_Id_Usuario = idUsuario;

            reserva.Id_Quadra = dadosAgendamento.Id_Quadra;
            reserva.Horario = dadosAgendamento.Horario;
            reserva.Jogadores = dadosAgendamento.Jogadores;

            context.SaveChanges();
        }

        public void CancelarReserva(int idReserva)
        {
            var reserva = context.Usuario_Agendamento.Find(idReserva);

            if (reserva != null)
            {
                context.Usuario_Agendamento.Remove(reserva);
                context.SaveChanges();
            }
        }
    }
}