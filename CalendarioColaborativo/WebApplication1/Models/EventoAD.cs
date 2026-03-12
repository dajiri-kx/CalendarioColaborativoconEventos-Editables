using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class EventoAD
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El título es obligatorio.")]
    [StringLength(200)]
    public string Titulo { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Descripcion { get; set; }

    [Required]
    public DateTime FechaInicio { get; set; }

    [Required]
    public DateTime FechaFin { get; set; }

    [StringLength(20)]
    public string? Color { get; set; }

    [NotMapped]
    public DiaSemana DiaSemana => FechaInicio.DayOfWeek switch
    {
        DayOfWeek.Monday    => DiaSemana.Lunes,
        DayOfWeek.Tuesday   => DiaSemana.Martes,
        DayOfWeek.Wednesday => DiaSemana.Miercoles,
        DayOfWeek.Thursday  => DiaSemana.Jueves,
        DayOfWeek.Friday    => DiaSemana.Viernes,
        DayOfWeek.Saturday  => DiaSemana.Sabado,
        DayOfWeek.Sunday    => DiaSemana.Domingo,
        _ => throw new InvalidOperationException("Día no válido.")
    };

    [NotMapped]
    public MesAnio Mes => (MesAnio)FechaInicio.Month;

    [NotMapped]
    public int Anio => FechaInicio.Year;
}
