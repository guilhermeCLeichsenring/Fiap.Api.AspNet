using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Api.AspNet.Models
{
    [Table("T_AREA_DE_RISCO")]
    public class AreaDeRiscoModel
    {
      //  [HiddenInput]
        [Key]
        [Column("id_area_de_risco")]
        public int AreaDeRiscoId { get; set; }

        [Column("localizacao_area_de_risco")]
        [Required(ErrorMessage = "Localizacao Area De Risc é obrigatório!")]
        [Display(Name = "Descrição do Rio")]
        public string LocalizacaoAreaDeRisco { get; set; }

        [Column("nivel_rio_area_de_risco_cm")]
        [Required(ErrorMessage = "NivelRioAreaDeRisco é obrigatório!")]
        [Display(Name = "NivelRioAreaDeRisco")]
        public int NivelRioAreaDeRisco { get; set; }

        [Column("dt_ultimo_registro")]
        [Required(ErrorMessage = "DataUltimoRegistro é obrigatório!")]
        [Display(Name = "DataUltimoRegistro")]
        public DateTime DataUltimoRegistro { get; set; }

        //foreign key
        //   [Column("id_rio")]
        [ForeignKey("id_rio")]
        [Required(ErrorMessage = "RioIde é obrigatório!")]
        [Display(Name = "RioId")]
        public int RioId { get; set; }

        //foreign key
        //[Column("T_PLUVIOMETRO_id_pluviometro")]

        [ForeignKey("id_pluviometro")]
        [Required(ErrorMessage = "PluviometroId é obrigatório!")]
        [Display(Name = "PluviometroId")]
        public int PluviometroId { get; set; }

        public RioModel? Rio { get; set; }
        public PluviometroModel? Pluviometro { get; set; }


    }
}
