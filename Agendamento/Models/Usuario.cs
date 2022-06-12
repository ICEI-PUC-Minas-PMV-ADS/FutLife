using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agendamento.Models
{
    [Table("Usuario")]
    public partial class Usuario
    {
        public Usuario()
        {
            Usuario_Agendamento = new HashSet<Usuario_Agendamento>();
            Usuario_Plano = new HashSet<Usuario_Plano>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Usuario { get; set; }

        [Display(Name = "Email")]
        [StringLength(100)]        
        [Required(ErrorMessage = "Email Inválido")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        [StringLength(60)]
        [Required(ErrorMessage = "Senha Inválida")]
        public string Senha { get; set; }

        [Display(Name = "Nome")]
        [StringLength(30)]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome")]
        [StringLength(30)]
        public string Sobrenome { get; set; }

        public virtual ICollection<Usuario_Agendamento> Usuario_Agendamento { get; set; }
        public virtual ICollection<Usuario_Equipe> Usuario_Equipe { get; set; }

        public virtual ICollection<Usuario_Plano> Usuario_Plano { get; set; }
    }
}
