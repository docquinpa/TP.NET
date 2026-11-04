using FTELMarket.DTOs;

namespace FTELMarket.Data;

public static class StaticData
{
    public static List<CategoryDto> Categories { get; } = new()
    {
        new CategoryDto { Id = 1, Name = "PlayStation 5" },
        new CategoryDto { Id = 2, Name = "Nintendo Switch" },
        new CategoryDto { Id = 3, Name = "Xbox Series X" },
        new CategoryDto { Id = 4, Name = "PC" }
    };

    public static List<ProductDto> Products { get; } = new()
    {
        new ProductDto { Id = 1, Name = "The Last of Us Part II", Description = "Boîte et notice, disque sans rayure.", Price = 19.9m, Stock = 3, CategoryId = 1, CreatedAt = DateTime.Parse("2026-09-02T09:15:00Z").ToUniversalTime(), CategoryName = "PlayStation 5" },
        new ProductDto { Id = 2, Name = "Gran Turismo 7", Description = null, Price = 29.9m, Stock = 1, CategoryId = 1, CreatedAt = DateTime.Parse("2026-09-05T14:30:00Z").ToUniversalTime(), CategoryName = "PlayStation 5" },
        new ProductDto { Id = 3, Name = "The Legend of Zelda: Tears of the Kingdom", Description = "Cartouche seule.", Price = 39.9m, Stock = 2, CategoryId = 2, CreatedAt = DateTime.Parse("2026-09-08T10:00:00Z").ToUniversalTime(), CategoryName = "Nintendo Switch" },
        new ProductDto { Id = 4, Name = "Mario Kart 8 Deluxe", Description = "Complet, très bon état.", Price = 34.9m, Stock = 5, CategoryId = 2, CreatedAt = DateTime.Parse("2026-09-10T16:45:00Z").ToUniversalTime(), CategoryName = "Nintendo Switch" },
        new ProductDto { Id = 5, Name = "Halo Infinite", Description = null, Price = 14.9m, Stock = 4, CategoryId = 3, CreatedAt = DateTime.Parse("2026-09-12T11:20:00Z").ToUniversalTime(), CategoryName = "Xbox Series X" },
        new ProductDto { Id = 6, Name = "Forza Horizon 5", Description = "Édition standard.", Price = 24.9m, Stock = 0, CategoryId = 3, CreatedAt = DateTime.Parse("2026-09-15T08:05:00Z").ToUniversalTime(), CategoryName = "Xbox Series X" },
        new ProductDto { Id = 7, Name = "Baldur’s Gate 3", Description = "Clé physique, coffret collector.", Price = 44.9m, Stock = 1, CategoryId = 4, CreatedAt = DateTime.Parse("2026-09-18T17:40:00Z").ToUniversalTime(), CategoryName = "PC" },
        new ProductDto { Id = 8, Name = "Hades", Description = null, Price = 9.9m, Stock = 6, CategoryId = 4, CreatedAt = DateTime.Parse("2026-09-21T13:10:00Z").ToUniversalTime(), CategoryName = "PC" }
    };
}