using PracMVVM.Data;
using PracMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracMVVM.Services;

public class DetalleFacturasServices
{
    Contex db;
    public DetalleFacturasServices() { 
    }

    #region DetalleFacturas

    public string DetalleFacturasSave(int ProductoId, int FacturaId, float Costo, float Cantidad, float Precio)
    {
        try
        { 
            db = new Contex();

            

            db.clsDetalleFacturasBE.Add(new Models.clsDetalleFacturasBE
            {

                ProductoID = ProductoId,
                FacturaID = FacturaId,
                Costo = Costo,
                Cantidad = Cantidad,
                Precio = Precio
            });

            db.SaveChanges();

            return "Guardado correctamente";
        }
        catch (Exception ex) { return ex.Message; }
    }

    public string DetalleFacturasUpdate(int DetalleFacturaId, int ProductoId, int FacturaId, float Costo, float Cantidad, float Precio)
    {
        try
        {
            db = new Contex();

            var row = db.clsDetalleFacturasBE.Where(x => x.DetalleFacturaId == DetalleFacturaId).FirstOrDefault();

            if (row != null)
            {
                row.ProductoID = ProductoId;
                row.FacturaID = FacturaId;
                row.Costo = Costo;
                row.Cantidad = Cantidad;
                row.Precio = Precio;

                db.Entry(row).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                db.SaveChanges();

            }

            return "Modificado correctamente";

        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string DetalleFacturasDeleteGetByDetalleFacturaID(int DetalleFacturaId)
    {
        try
        {
            db = new Contex();

            var row = db.clsDetalleFacturasBE.Where(x => x.DetalleFacturaId == DetalleFacturaId).FirstOrDefault();

            if (row != null)
            {
                db.Entry(row).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

                db.SaveChanges();

            }

            return "Eliminado correctamente";

        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public clsDetalleFacturasBE DetalleFacturasGetByDetalleFacturaID(int DetalleFacturaId)
    {
        try
        {
            db = new Contex();

            return db.clsDetalleFacturasBE.Where(x => x.DetalleFacturaId == DetalleFacturaId).FirstOrDefault();

        }
        catch (Exception ex)
        {
            return new clsDetalleFacturasBE();
        }
    }

    #endregion

    public List<Models.clsDetalleFacturasBE> DetalleFacturasGet()
    {

        db = new Contex();

        var result = db.clsDetalleFacturasBE;

        return result.ToList();
    }



}
