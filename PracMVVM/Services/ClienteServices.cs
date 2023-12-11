using PracMVVM.Data;
using PracMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracMVVM.Services;

public class ClienteServices
{
    Contex db;

    public ClienteServices() { }

    public string ClientesSave(string Nombres, string Direccion, string Telefono)
    {
        try
        {
            db = new Contex();

            db.clsClientesBE.Add(new Models.clsClientesBE
            {
                
                Nombres = Nombres,
                Direccion = Direccion,
                Telefono = Telefono,
                
            });

            db.SaveChanges();

            return "Guardado correctamente";
        }
        catch (Exception ex) { return ex.Message; }
    }


    public string ClientesUpdate(int ClienteID, string Nombres, string Direccion, string Telefono)
    {
        try
        {
            db = new Contex();

            var row = db.clsClientesBE.Where(x => x.ClienteID == ClienteID).FirstOrDefault();

            if (row != null)
            {
                row.Nombres = Nombres;
                row.Direccion = Direccion;
                row.Telefono = Telefono;
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
    public string DeleteByClienteID(int ClienteID)
    {
        try
        {
            db = new Contex();

            var row = db.clsClientesBE.Where(x => x.ClienteID == ClienteID).FirstOrDefault();

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
    public clsClientesBE ClientesGetByClienteID(int ClienteID)
    {
        try
        {
            db = new Contex();

            return db.clsClientesBE.Where(x => x.ClienteID == ClienteID).FirstOrDefault();

        }
        catch (Exception ex)
        {
            return new clsClientesBE();
        }
    }
    public List<Models.clsClientesBE> ClientesGet()
    {

        db = new Contex();

        var result = db.clsClientesBE;

        return result.ToList();
    }



}