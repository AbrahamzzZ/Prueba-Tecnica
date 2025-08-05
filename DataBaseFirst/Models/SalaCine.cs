using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataBaseFirst.Models;

[Table("SALA_CINE")]
public partial class SalaCine
{
    [Key]
    [Column("ID_SALA")]
    public int IdSala { get; set; }

    [Column("NOMBRE")]
    [StringLength(50)]
    public string? Nombre { get; set; }

    [Column("ESTADO")]
    public bool? Estado { get; set; }

    [InverseProperty("IdSalaCineNavigation")]
    public virtual ICollection<PeliculaSalaCine> PeliculaSalaCines { get; set; } = new List<PeliculaSalaCine>();
}
