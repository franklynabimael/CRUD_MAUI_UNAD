
using PracMVVM.Data;
using PracMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracMVVM.Services;

public class CategoriaServices
{
    Contex db;

    public CategoriaServices(){}

    public string CategoriasSave(string Categoria)
    {
        try
        {
            db = new Contex();

            db.clsCategoriasBE.Add(new Models.ClsCategoriasBE
            {
                Categoria = Categoria
            });

            db.SaveChanges();

            return "Guardado correctamente";
        }
        catch (Exception ex) { return ex.Message; }
    }

    public string CategoriasUpdate(int CategoriaID, string Categoria)
    {
        try
        {
            db = new Contex();

            var row = db.clsCategoriasBE.Where(x => x.CategoriaID == CategoriaID).FirstOrDefault();

            if (row != null)
            {
                row.Categoria = Categoria;
                            
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
    public string DeleteByCategoriaID(int CategoriaID)
    {
        try
        {
            db = new Contex();

            var row = db.clsCategoriasBE.Where(x => x.CategoriaID == CategoriaID).FirstOrDefault();

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
    public ClsCategoriasBE CategoriasGetByCategoriaID(int CategoriaID)
    {
        try
        {
            db = new Contex();

            return db.clsCategoriasBE.Where(x => x.CategoriaID == CategoriaID).FirstOrDefault();

        }
        catch (Exception ex)
        {
            return new ClsCategoriasBE();
        }
    }
    public List<Models.ClsCategoriasBE> CategoriasGet()
    {

        db = new Contex();

        var result = db.clsCategoriasBE;

        return result.ToList();
    }
}