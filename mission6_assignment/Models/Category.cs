using System.ComponentModel.DataAnnotations;
namespace mission6_assignment.Models;

//this is the category class to connect to the categories table in the database
public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}