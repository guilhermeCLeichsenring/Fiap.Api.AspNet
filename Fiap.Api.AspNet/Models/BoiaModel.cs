using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Api.AspNet.Models
{
    [Table("T_BOIA_MONITO")]
    public class BoiaModel
    {
        [Key]
        [Column("id_ferramenta")]
        public int FerramentaId { get; set; }

        [Column("localizacao_ferramenta")]
        [Required(ErrorMessage = "Localizacao Ferrament é obrigatório!")]
        [Display(Name = "Localizacao Ferramento")]
        public int LocalizacaoFerramenta { get; set; }

        [Column("status_rio")]
        [Required(ErrorMessage = "Status Rio é obrigatório!")]
        [Display(Name = "Status Rio")]
        public string StatusRio { get; set; }

        [Column("alerta_risco")]
        [Required(ErrorMessage = "Alerta Risco é obrigatório!")]
        [Display(Name = "Alerta Risco")]
        public bool AlertaRisco { get; set; }

        [Column("dt_ultimo_registro")]
        [Required(ErrorMessage = "Data Ultimo Registro é obrigatório!")]
        [Display(Name = "Data Ultimo Registro")]
        public DateTime DataUltimoRegistro { get; set; }

        [Column("id_rio")]
        [Required(ErrorMessage = "Rio Id é obrigatório!")]
        [Display(Name = "Rio Id")]
        public int RioId { get; set; }

        public RioModel? Rio { get; set; }
    }
}
