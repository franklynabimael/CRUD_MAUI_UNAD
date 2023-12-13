using PracMVVM.Data;
using PracMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracMVVM.Services;

public class ProductoServices
{
    Contex db;

    public ProductoServices() { }

    public string ProductosSave(string Producto, float Costo, float Cantidad, float Precio, int CategoriaID)
    {
        try
        {
            db = new Contex();

            db.clsProductosBE.Add(new Models.clsProductosBE
            {
                
                Producto = Producto,
                Costo = Costo,
                Cantidad = Cantidad,
                Precio = Precio,
                CategoriaID = CategoriaID

            });

            db.SaveChanges();

            return "Guardado correctamente";
        }
        catch (Exception ex) { return ex.Message; }
    }


    public string ProductosUpdate(int ProductoID, string Producto, float Costo, float Cantidad, float Precio, int CategoriaID)
    {
        try
        {
            db = new Contex();

            var row = db.clsProductosBE.Where(x => x.ProductoId == ProductoID).FirstOrDefault();

            if (row != null)
            {
                row.Producto = Producto;
                row.Costo = Costo;
                row.Cantidad = Cantidad;
                row.Precio = Precio;
                row.CategoriaID = CategoriaID;
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
    public string DeleteByProductoID(int ProductoID)
    {
        try
        {
            db = new Contex();

            var row = db.clsProductosBE.Where(x => x.ProductoId == ProductoID).FirstOrDefault();

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
    public clsProductosBE ProductosGetByProductoID(int ProductoId)
    {
        try
        {
            db = new Contex();

            return db.clsProductosBE.Where(x => x.ProductoId == ProductoId).FirstOrDefault();

        }
        catch (Exception ex)
        {
            return new clsProductosBE();
        }
    }
    public List<Models.clsProductosBE> ProductosGet()
    {

        db = new Contex();

        var result = db.clsProductosBE;

        return result.ToList();
    }



}