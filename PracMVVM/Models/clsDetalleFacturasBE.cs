using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracMVVM.Models;

[Table("DetalleFactura")]
public class clsDetalleFacturasBE
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DetalleFacturaId { get; set; }
   
    [StringLength(50)]
    public int ProductoID { get; set; }
    public virtual clsProductosBE? Producto { get; set; }
    public int FacturaID { get; set; }
    public float Costo {  get; set; }
    public float Cantidad { get; set; }
    public float Precio { get; set; }
}
