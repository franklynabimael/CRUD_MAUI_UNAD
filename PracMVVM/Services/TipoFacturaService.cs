using PracMVVM.Data;
using PracMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracMVVM.Services;

public class TipoFacturaServices
{
    Contex db;

    public TipoFacturaServices() { }

    public string TipoFacturasSave( string TipoFactura)
    {
        try
        {
            db = new Contex();

            db.clsTipoFacturasBE.Add(new Models.clsTipoFacturasBE
            {

                TipoFactura = TipoFactura,
               
            });

            db.SaveChanges();

            return "Guardado correctamente";
        }
        catch (Exception ex) { return ex.Message; }
    }


    public string TipoFacturasUpdate(int TipoFacturaID, string TipoFactura)
    {
        try
        {
            db = new Contex();

            var row = db.clsTipoFacturasBE.Where(x => x.TipoFacturaID == TipoFacturaID).FirstOrDefault();

            if (row != null)
            {
                row.TipoFactura = TipoFactura;
                
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
    public string DeleteByTipoFacturaID(int TipoFacturaID)
    {
        try
        {
            db = new Contex();

            var row = db.clsTipoFacturasBE.Where(x => x.TipoFacturaID == TipoFacturaID).FirstOrDefault();

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
    public clsTipoFacturasBE TipoFacturasGetByTipoFacturaID(int TipoFacturaID)
    {
        try
        {
            db = new Contex();

            return db.clsTipoFacturasBE.Where(x => x.TipoFacturaID == TipoFacturaID).FirstOrDefault();

        }
        catch (Exception ex)
        {
            return new clsTipoFacturasBE();
        }
    }
    public List<Models.clsTipoFacturasBE> TipoFacturasGet()
    {

        db = new Contex();

        var result = db.clsTipoFacturasBE;

        return result.ToList();
    }



}