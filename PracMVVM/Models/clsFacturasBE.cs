    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracMVVM.Models;
[Table("Facturas")]
public class clsFacturasBE
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FacturaID { get; set; }
    public DateTime? Fecha { get; set; }
    public float SubTotal { get; set; }
    public float Descuento { get; set; }
    public float Monto { get; set; }
    public int TipoFacturaId { get; set; }
    public virtual clsTipoFacturasBE TipoFacturas { get; set; }
    public int ClienteId { get; set; }
    public virtual clsClientesBE Cliente { get; set;}
    public virtual ICollection<clsDetalleFacturasBE> DetalleFacturas { get; set; }
}