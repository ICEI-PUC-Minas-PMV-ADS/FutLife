using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agendamento.Models
{
    public class Perfil
    {
        public Usuario Usuario { get; set; }
        public List<Usuario_Agendamento> Agendamentos { get; set; }
        public List<Usuario_Equipe> Equipes { get; set; }
    }
}