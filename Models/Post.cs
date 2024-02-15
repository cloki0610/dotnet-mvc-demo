using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace dotnet_mvc.Models;

public class Post
{
    [Key]
    public Guid Id { get; set; }
    [Required, ForeignKey("User")]
    public required string Author { get; set; }
    [Required, StringLength(30, MinimumLength = 5)]
    public required string Heading { get; set; }
    [Required, StringLength(1000, MinimumLength = 20)]
    public required string Content { get; set; }
    [Display(Name = "Short Description")]
    public string? ShortDescription { get; set; }
    [Display(Name = "Featured Image Url")]
    public string? FeaturedImageUrl { get; set; }
    [Display(Name = "Url Handle")]
    public string? UrlHandle { get; set; }
    [Display(Name = "Publish Date"), DataType(DataType.Date)]
    public DateTime PublishDate { get; set; } = DateTime.Now.Date;
    public bool Visible { get; set; } = true;
    [ForeignKey("Tag")]
    public ICollection<Tag>? Tags { get; } = [];
}