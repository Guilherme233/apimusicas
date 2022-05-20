using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apimusicas.ModelsMusic
{
    [Table("tb_musica_cantor")]
    [Index("IdCantor", Name = "id_cantor")]
    [Index("IdMusica", Name = "id_musica")]
    public partial class TbMusicaCantor
    {
        [Key]
        [Column("id_musica_cantor")]
        public int IdMusicaCantor { get; set; }
        [Column("nm_album")]
        [StringLength(100)]
        public string? NmAlbum { get; set; }
        [Column("id_musica")]
        public int? IdMusica { get; set; }
        [Column("id_cantor")]
        public int? IdCantor { get; set; }

        [ForeignKey("IdCantor")]
        [InverseProperty("TbMusicaCantors")]
        public virtual TbCantor? IdCantorNavigation { get; set; }
        [ForeignKey("IdMusica")]
        [InverseProperty("TbMusicaCantors")]
        public virtual TbMusica? IdMusicaNavigation { get; set; }
    }
}
