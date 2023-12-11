using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracMVVM.Models;
[Table("Productos")]
public class clsProductosBE
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductoID { get; set; }
    public string Producto { get; set; } = string.Empty;
    public float Costo { get; set;}
    public float Cantidad { get; set;}
    public float Precio { get; set; }
    public int CategoriaID { get; set;}
}
