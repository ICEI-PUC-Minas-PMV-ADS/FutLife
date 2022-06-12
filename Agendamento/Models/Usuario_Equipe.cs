using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Agendamento.Models
{
    public partial class Usuario_Equipe
    {
        public Usuario_Equipe()
        {
            Equipe_Integrante = new HashSet<Equipe_Integrante>();
        }

        [Key]
        public int Id_Usuario_Equipe { get; set; }
        [Required]
        [StringLength(45)]
        public string Nome { get; set; }
        public int Usuario_Id_Usuario { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Equipe_Integrante> Equipe_Integrante { get; set; }
    }
}
