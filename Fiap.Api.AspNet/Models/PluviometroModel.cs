using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Api.AspNet.Models
{
    [Table("T_PLUVIOMETRO")]
    public class PluviometroModel
    {
        [Key]
        [Column("id_pluviometro")]
        public int PluviometroId { get; set; }

        [Column("nivel_chuva")]
        [Required(ErrorMessage = "Nível da chuva é obrigatório é obrigatório!")]
        [Display(Name = "Nível da Chuva")]
        public int NivelChuva { get; set; }

        [Column("ds_pluviometro")]
        [Required(ErrorMessage = "Descrição Pluviômetro é obrigatório!")]
        [Display(Name = "Descrição do Rio")]
        public string DescricaoPluviometro { get; set; }

        [Column("dt_ultimo_registro")]
        [Required(ErrorMessage = "Data Ultimo Registro é obrigatório!")]
        [Display(Name = "Data Ultimo Registro")]
        public DateTime DataUltimoRegistro { get; set; }
    }
}
