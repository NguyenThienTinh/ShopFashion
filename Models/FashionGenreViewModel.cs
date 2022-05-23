using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ShopFashion.Models
{
    public class FashionGenreViewModel
    {
        public List<Fashion>? Fashions { get; set; }
        public SelectList? LoaiHangs { get; set; }
        public string? FashionGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
