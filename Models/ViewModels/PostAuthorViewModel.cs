using dotnet_mvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace dotnet_mvc.Models;

public class PostAuthorViewModel
{
    public List<Post>? Posts { get; set; }
    public SelectList? Author { get; set; }
    public string? PostAuthor { get; set; }
    public string? SearchString { get; set; }
}