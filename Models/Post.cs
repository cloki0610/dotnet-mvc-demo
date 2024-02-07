using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_mvc.Models;

public class Post
{
    public Guid Id { get; set; }
    [Required]
    public required string Author { get; set; }
    [Required]
    public required string Heading { get; set; }
    [Required]
    [Display(Name = "Page Title")]
    public required string PageTitle { get; set; }
    [Required]
    public required string Content { get; set; }
    [Display(Name = "Short Description")]
    public string? ShortDescription { get; set; }
    [Display(Name = "Featured Image Url")]
    public string? FeaturedImageUrl { get; set; }
    [Display(Name = "Url Handle")]
    public string? UrlHandle { get; set; }
    [DataType(DataType.Date)]
    [Display(Name = "Publish Date")]
    public DateTime PublishDate { get; set; }
    public bool Visible { get; set; }
    [ForeignKey("Tag")]
    public ICollection<Tag> Tags { get; } = [];
}