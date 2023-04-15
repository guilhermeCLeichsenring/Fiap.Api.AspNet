using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Api.AspNet.Models
{
    [Table("T_RIO")]
    public class RioModel
    {
        [Key]
        [Column("ID_RIO")]
        public int RioId { get; set; }

        [Column("NM_RIO")]
        [Required(ErrorMessage = "Nome do rioe é obrigatório!")]
        [Display(Name = "Nome do Rio")]
        public string? NomeRio { get; set; }

        [Column("DS_RIO")]
        [Required(ErrorMessage = "Descrição do rio é obrigatório!")]
        [Display(Name = "Descrição do Rio")]
        public string? DescricaoRio { get; set; }


        public RioModel() { }

        public RioModel(int rioId, string nomeRio)
        {
            RioId = rioId;
            NomeRio = nomeRio;
        }
        public RioModel(int rioId, string nomeRio, string descricaoRio)
        {
            RioId = rioId;
            NomeRio = nomeRio;
            DescricaoRio = descricaoRio;
        }
    }

 



}
