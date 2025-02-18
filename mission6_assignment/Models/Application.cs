using System.ComponentModel.DataAnnotations;

namespace mission6_assignment.Models;

//form for entering movies 
//make sure everything but notes, lentto, and editied is required
//make sure notes can't be longer than 25 characters
public class Application
{
    //each of these represents a column, typically assigned to a database
    //change
    //another change
    //third change
    [Required]
    public required string Category { get; set; }
    
    [Required]
    [Key]
    public required string Title { get; set; }
    
    [Required]
    public required string Director { get; set; }
    
    [Required]
    public required string Rating { get; set; }
    public bool Edited { get; set; }
    public string? LentTo { get; set; }
    
    [StringLength(25, ErrorMessage = "Notes can't be longer than 25 characters.")]
    public string? Notes { get; set; }
}