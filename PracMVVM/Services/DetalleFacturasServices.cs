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

    public string DetalleFacturasSave(int ProductoID, int FacturaID, float Costo, float Cantidad, float Precio)
    {
        try
        {
            db = new Contex();

            

            db.clsDetalleFacturasBE.Add(new Models.clsDetalleFacturasBE
            {

                ProductoID = ProductoID,
                FacturaID = FacturaID,
                Costo = Costo,
                Cantidad = Cantidad,
                Precio = Precio
            });

            db.SaveChanges();

            return "Guardado correctamente";
        }
        catch (Exception ex) { return ex.Message; }
    }

    public string DetalleFacturasUpdate(int DetalleFacturaID, int ProductoID, int FacturaID, float Costo, float Cantidad, float Precio)
    {
        try
        {
            db = new Contex();

            var row = db.clsDetalleFacturasBE.Where(x => x.DetalleFacturaID == DetalleFacturaID).FirstOrDefault();

            if (row != null)
            {
                row.ProductoID = ProductoID;
                row.FacturaID = FacturaID;
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

    public string DetalleFacturasDeleteGetByDetalleFacturaID(int DetalleFacturaID)
    {
        try
        {
            db = new Contex();

            var row = db.clsDetalleFacturasBE.Where(x => x.DetalleFacturaID == DetalleFacturaID).FirstOrDefault();

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

    public clsDetalleFacturasBE DetalleFacturasGetByDetalleFacturaID(int DetalleFacturaID)
    {
        try
        {
            db = new Contex();

            return db.clsDetalleFacturasBE.Where(x => x.DetalleFacturaID == DetalleFacturaID).FirstOrDefault();

        }
        catch (Exception ex)
        {
            return new clsDetalleFacturasBE();
        }
    }
        
    #endregion





}
