using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataBaseFirst.Models;

[Table("PELICULA")]
public partial class Pelicula
{
    [Key]
    [Column("ID_PELICULA")]
    public int IdPelicula { get; set; }

    [Column("NOMBRE")]
    [StringLength(50)]
    public string? Nombre { get; set; }

    [Column("DURACION")]
    public int? Duracion { get; set; }

    [Column("ESTADO")]
    public bool? Estado { get; set; }

    [InverseProperty("IdPeliculaNavigation")]
    public virtual ICollection<PeliculaSalaCine> PeliculaSalaCines { get; set; } = new List<PeliculaSalaCine>();
}
