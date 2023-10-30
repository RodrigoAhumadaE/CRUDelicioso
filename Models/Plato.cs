#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CRUDelicioso.Models;

public class Plato{

    [Key]
    public int PlatoId {get;set;}

    [Required(ErrorMessage = "Debe Ingresar este dato.")]
    public string Nombre {get;set;}

    [Required(ErrorMessage = "Debe Ingresar este dato.")]
    public string Chef {get;set;}

    [Required(ErrorMessage = "Debe Ingresar este dato.")]
    [Range(1, 6, ErrorMessage = "Debe ingresar un valor entre 1 y 5.")]
    public int Sabor {get;set;}

    [Required(ErrorMessage = "Debe Ingresar este dato.")]
    [Range(1,Int32.MaxValue, ErrorMessage ="Debe ingresar un valor mayor a 0.")]
    public int Calorias {get;set;}

    [Required(ErrorMessage = "Debe Ingresar este dato.")]
    public string Descripcion {get;set;}
    public DateTime FechaCreacion {get;set;} = DateTime.Now;
    public DateTime FechaActualizacion {get;set;} = DateTime.Now;
}