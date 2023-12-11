using PracMVVM.Data;
using PracMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracMVVM.Services;

public class FacturaServices
{
    Contex db;

    public FacturaServices() { }

    public string FacturasSave(DateTime Fecha, float SubTotal, float Descuento, float Monto, int TipoFacturaId, int ClienteId)
    {
        try
        {
            db = new Contex();

            db.clsFacturasBE.Add(new Models.clsFacturasBE
            {

                Fecha = Fecha,
                SubTotal = SubTotal,
                Descuento = Descuento,
                Monto = Monto,
                TipoFacturaId = TipoFacturaId,
                ClienteId = ClienteId               

            });

            db.SaveChanges();

            return "Guardado correctamente";
        }
        catch (Exception ex) { return ex.Message; }
    }


    public string FacturasUpdate(int FacturaID, DateTime Fecha, float SubTotal, float Descuento, float Monto, int TipoFacturaId, int ClienteId)
    {
        try
        {
            db = new Contex();

            var row = db.clsFacturasBE.Where(x => x.FacturaID == FacturaID).FirstOrDefault();

            if (row != null)
            {
                row.Fecha = Fecha;
                row.SubTotal = SubTotal;
                row.Descuento = Descuento;
                row.Monto = Monto;
                row.TipoFacturaId = TipoFacturaId;
                row.ClienteId = ClienteId;
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
    public string DeleteByFacturaID(int FacturaID)
    {
        try
        {
            db = new Contex();

            var row = db.clsFacturasBE.Where(x => x.FacturaID == FacturaID).FirstOrDefault();

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
    public clsFacturasBE FacturasGetByFacturaID(int FacturaID)
    {
        try
        {
            db = new Contex();

            return db.clsFacturasBE.Where(x => x.FacturaID == FacturaID).FirstOrDefault();

        }
        catch (Exception ex)
        {
            return new clsFacturasBE();
        }
    }
    public List<Models.clsFacturasBE> FacturasGet()
    {

        db = new Contex();

        var result = db.clsFacturasBE;

        return result.ToList();
    }



}