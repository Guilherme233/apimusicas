using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apimusicas.ModelsMusic
{
    [Table("tb_cantor")]
    public partial class TbCantor
    {
        public TbCantor()
        {
            TbMusicaCantors = new HashSet<TbMusicaCantor>();
        }

        [Key]
        [Column("id_cantor")]
        public int IdCantor { get; set; }
        [Column("nm_cantor")]
        [StringLength(100)]
        public string? NmCantor { get; set; }
        [Column("vl_altura")]
        [Precision(10, 2)]
        public decimal? VlAltura { get; set; }
        [Column("dt_nascimento")]
        public DateOnly? DtNascimento { get; set; }

        [InverseProperty("IdCantorNavigation")]
        public virtual ICollection<TbMusicaCantor> TbMusicaCantors { get; set; }
    }
}
