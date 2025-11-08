using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetCare.Models
{
    public enum Especie
    {
        Perro = 1,
        Gato = 2,
        Ave = 3,
        Otro = 4
    }

    public class Mascota : IValidatableObject
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MinLength(2, ErrorMessage = "El nombre debe tener al menos 2 caracteres.")]
        [Display(Name = "Nombre de la mascota")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar una especie.")]
        [Display(Name = "Especie")]
        public Especie? Especie { get; set; }

        [Display(Name = "Raza")]
        public string? Raza { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria.")]
        [Range(0, 25, ErrorMessage = "La edad debe estar entre 0 y 25 años.")]
        [Display(Name = "Edad (años)")]
        public int? Edad { get; set; }

        [Required(ErrorMessage = "El nombre del dueño es obligatorio.")]
        [MinLength(3, ErrorMessage = "El nombre del dueño debe tener al menos 3 caracteres.")]
        [Display(Name = "Nombre del dueño")]
        public string DuenoNombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El teléfono debe tener 8 dígitos (formato: ########).")]
        [Display(Name = "Teléfono del dueño")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de ingreso es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de ingreso")]
        public DateTime? FechaIngreso { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FechaIngreso.HasValue)
            {
                if (FechaIngreso.Value.Date != DateTime.Today)
                {
                    yield return new ValidationResult(
                        "La fecha de ingreso debe ser la fecha actual.",
                        new[] { nameof(FechaIngreso) }
                    );
                }
            }
        }
    }
}
