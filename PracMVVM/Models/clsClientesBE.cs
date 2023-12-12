using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracMVVM.Models;
[Table("Clientes")]
public class clsClientesBE
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClienteID { get; set; }
    public string? Nombres { get; set;}
    public string? Direccion { get; set; }

    public string? Telefono { get; set; }



}
