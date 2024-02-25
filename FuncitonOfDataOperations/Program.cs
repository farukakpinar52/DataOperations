// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");


Console.WriteLine( );
public class ETicaretDbContext : DbContext
{
    DbSet<Urun> Uruns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder.UseSqlServer("Server=DESKTOP-P7KA77K\\SQLEXPRESS;Database=DataOperations;User Id=sa;Password=1234; ;TrustServerCertificate=true");

    }

}

public class Urun
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
}


