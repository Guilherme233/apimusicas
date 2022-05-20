using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apimusicas.ModelsMusic
{
    [Table("tb_musica")]
    public partial class TbMusica
    {
        public TbMusica()
        {
            TbMusicaCantors = new HashSet<TbMusicaCantor>();
            TbProdutors = new HashSet<TbProdutor>();
        }

        [Key]
        [Column("id_musica")]
        public int IdMusica { get; set; }
        [Column("nm_musica")]
        [StringLength(100)]
        public string? NmMusica { get; set; }
        [Column("ds_genero")]
        [StringLength(100)]
        public string? DsGenero { get; set; }
        [Column("nr_duracao")]
        [Precision(10, 2)]
        public decimal? NrDuracao { get; set; }
        [Column("vl_avaliacao")]
        [Precision(10, 2)]
        public decimal? VlAvaliacao { get; set; }
        [Column("bt_disponivel")]
        public bool? BtDisponivel { get; set; }
        [Column("dt_lancamento")]
        public DateOnly? DtLancamento { get; set; }

        [InverseProperty("IdMusicaNavigation")]
        public virtual ICollection<TbMusicaCantor> TbMusicaCantors { get; set; }
        [InverseProperty("IdMusicaNavigation")]
        public virtual ICollection<TbProdutor> TbProdutors { get; set; }
    }
}
