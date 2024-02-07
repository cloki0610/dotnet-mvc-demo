using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_mvc.Models;

public class Tag
{
    public Guid Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [Display(Name = "Display Name")]
    public string? DisplayName { get; set; }
    [ForeignKey("Post")]
    public ICollection<Post> Posts { get; } = [];
}