using System.ComponentModel.DataAnnotations;

namespace Agendamento.Models
{
    public partial class Equipe_Integrante
    {
        [Key]
        public int Id_Equipe_Integrante { get; set; }
        [Required]
        [StringLength(45)]
        public string Nome_Integrante { get; set; }
        [Required]
        [StringLength(10)]
        public string Posicao { get; set; }
        public int Usuario_Equipe_Id_Usuario_Equipe { get; set; }

        public virtual Usuario_Equipe Usuario_Equipe { get; set; }
    }
}
