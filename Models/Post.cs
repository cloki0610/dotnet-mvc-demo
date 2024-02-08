using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace dotnet_mvc.Models;

public class Post
{
    [Key]
    public Guid Id { get; set; }
    [Required, StringLength(15, MinimumLength = 3)]
    [ForeignKey("User")]
    public required string AuthorId { get; set; }
    public required IdentityUser Author { get; set; }
    [Required, StringLength(30, MinimumLength = 5)]
    public required string Heading { get; set; }
    [Required, Display(Name = "Page Title"), StringLength(30, MinimumLength = 5)]
    public required string PageTitle { get; set; }
    [Required, StringLength(1000, MinimumLength = 20)]
    public required string Content { get; set; }
    [Display(Name = "Short Description")]
    public string? ShortDescription { get; set; }
    [Display(Name = "Featured Image Url")]
    public string? FeaturedImageUrl { get; set; }
    [Display(Name = "Url Handle")]
    public string? UrlHandle { get; set; }
    [Display(Name = "Publish Date"), DataType(DataType.Date),
    DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime PublishDate { get; set; }
    public bool Visible { get; set; }
    [ForeignKey("Tag")]
    public ICollection<Tag> Tags { get; } = [];
}