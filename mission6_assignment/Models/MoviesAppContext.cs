using Microsoft.EntityFrameworkCore;

namespace mission6_assignment.Models;

public class MoviesAppContext : DbContext //inherit from dbcontext
{
    //options that are passed in an options that are inherited
    public MoviesAppContext(DbContextOptions<MoviesAppContext> options) : base(options) //constructor
    {
    }
    //what are we storing in our database? dating applications! 
    //we are putting a table in our database
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }
}