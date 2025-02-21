using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace mission6_assignment.Models;


//form for entering movies
//make sure everything but notes, lentto, and editied is required
//make sure notes can't be longer than 25 characters
public class Movie
{
    //each of these represents a column, typically assigned to a database
    [Key]
    [Required]
    public int MovieId { get; set; }
  
    //forgien key is in both tables
    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }
    
    //this is needed to get it with database
    public Category? Category { get; set; }
  
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
  
    [Required(ErrorMessage="Year is required")]
    [Range(1888,2400, ErrorMessage = "Year must be after 1888")]
    public int Year { get; set; }
    public string?  Director { get; set; }
    public string? Rating { get; set; }
  
    [Required(ErrorMessage = "Edited is required")]
    public int Edited { get; set; }
    public string? LentTo { get; set; }
  
    [Required(ErrorMessage = "CopiedToPlex is required")]
    public int CopiedToPlex { get; set; }
  
    [StringLength(25, ErrorMessage = "Notes can't be longer than 25 characters.")]
    public string? Notes { get; set; }
}