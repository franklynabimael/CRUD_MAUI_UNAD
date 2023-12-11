
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;

namespace PracMVVM.Models;
[Table("TipoFacturas")]
public class clsTipoFacturasBE
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TipoFacturaID { get; set; }
    public string TipoFactura { get; set; }



}