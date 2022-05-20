using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apimusicas.ModelsMusic
{
    [Table("tb_produtor")]
    [Index("IdMusica", Name = "id_musica")]
    public partial class TbProdutor
    {
        [Key]
        [Column("id_produtor")]
        public int IdProdutor { get; set; }
        [Column("nm_produtor")]
        [StringLength(100)]
        public string? NmProdutor { get; set; }
        [Column("dt_nascimento")]
        public DateOnly? DtNascimento { get; set; }
        [Column("id_musica")]
        public int? IdMusica { get; set; }

        [ForeignKey("IdMusica")]
        [InverseProperty("TbProdutors")]
        public virtual TbMusica? IdMusicaNavigation { get; set; }
    }
}
