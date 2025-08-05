using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataBaseFirst.Models;

[Table("PELICULA_SALA_CINE")]
public partial class PeliculaSalaCine
{
    [Key]
    [Column("ID_PELICULA_CINE")]
    public int IdPeliculaCine { get; set; }

    [Column("ID_SALA_CINE")]
    public int? IdSalaCine { get; set; }

    [Column("FECHA_PUBLICACION")]
    public DateOnly? FechaPublicacion { get; set; }

    [Column("FECHA_FIN")]
    public DateOnly? FechaFin { get; set; }

    [Column("ID_PELICULA")]
    public int? IdPelicula { get; set; }

    [ForeignKey("IdPelicula")]
    [InverseProperty("PeliculaSalaCines")]
    public virtual Pelicula? IdPeliculaNavigation { get; set; }

    [ForeignKey("IdSalaCine")]
    [InverseProperty("PeliculaSalaCines")]
    public virtual SalaCine? IdSalaCineNavigation { get; set; }
}
