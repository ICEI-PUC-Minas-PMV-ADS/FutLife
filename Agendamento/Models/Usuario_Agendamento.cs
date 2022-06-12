using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agendamento.Models
{
    public partial class Usuario_Agendamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Usuario_Agendamento { get; set; }
        public int Id_Quadra { get; set; }
        public DateTime? Horario { get; set; }
        public byte Jogadores { get; set; }
        [Display(Name = "Incluir Bola")]
        public bool Incluir_Bola { get; set; }
        [Display(Name = "Incluir Colete")]
        public bool Incluir_Colete { get; set; }
        public int Usuario_Id_Usuario { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
