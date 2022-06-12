using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agendamento.Models
{
    public partial class Usuario_Plano
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Usuario_Plano { get; set; }
        public int Id_Plano { get; set; }

        public int Usuario_Id_Usuario { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
