using Microsoft.EntityFrameworkCore;
using PracMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracMVVM.Data;

public class Contex: DbContext
{
    public Contex() 
    {
        if (DeviceInfo.Platform == DevicePlatform.iOS || DeviceInfo.Platform == DevicePlatform.MacCatalyst)
        {
            SQLitePCL.Batteries_V2.Init();
        }
        this.Database.EnsureCreated(); //crea la base de datos
        this.Database.Migrate(); // para aplicar los cambios del modelo a la base de datos
    }

    // declarar las tablas que se van hacer la migracion

    //metodo DbSet

    public DbSet<ClsCategoriasBE>clsCategoriasBE { get; set; }
    public DbSet<clsClientesBE> clsClientesBE { get; set; }
    public DbSet<clsDetalleFacturasBE> clsDetalleFacturasBE { get; set; }
    public DbSet<clsFacturasBE> clsFacturasBE { get; set; }
    public DbSet<clsProductosBE> clsProductosBE { get; set; }
    public DbSet<clsTipoFacturasBE> clsTipoFacturasBE { get; set; }

    [Obsolete]
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string rutaDB = String.Empty;

        switch (Device.RuntimePlatform)
        {
            case Device.iOS:
                {
                    rutaDB = Path.Combine(FileSystem.AppDataDirectory, "unad.db");
                }
                break;
            case Device.Android:
                {
                    rutaDB = Path.Combine(FileSystem.AppDataDirectory, "unad.db");
                }
                break;
            case Device.MacCatalyst:
                {
                    rutaDB = Path.Combine(FileSystem.AppDataDirectory, "unad.db");
                }
                break;
        }
        optionsBuilder.UseSqlite($"Filename={rutaDB}");
        base.OnConfiguring(optionsBuilder);

    }

    
       

     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClsCategoriasBE>()
            .HasMany(category => category.Productos)
            .WithOne()
            .HasForeignKey(product => product.CategoriaID);
        modelBuilder.Entity<clsDetalleFacturasBE>()
            .HasOne(detalle => detalle.Producto)
            .WithMany()
            .HasForeignKey(detalle => detalle.ProductoID);
        modelBuilder.Entity<clsFacturasBE>()
            .HasMany(fac => fac.DetalleFacturas)
            .WithOne()
            .HasForeignKey(detalle => detalle.FacturaID);
        modelBuilder.Entity<clsFacturasBE>()
            .HasOne(factura => factura.TipoFacturas)
            .WithMany()
            .HasForeignKey(factura => factura.TipoFacturaId);
        modelBuilder.Entity<clsFacturasBE>()
            .HasOne(fac => fac.Cliente)
            .WithMany()
            .HasForeignKey(fac => fac.ClienteId);
        
        base.OnModelCreating(modelBuilder);
     }
}

