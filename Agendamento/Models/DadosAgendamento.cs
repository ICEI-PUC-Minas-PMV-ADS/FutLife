using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agendamento.Models
{
    public class DadosAgendamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Quadra { get; set; }
        public string Horario { get; set; }
        public string Jogadores { get; set; }
    }
}