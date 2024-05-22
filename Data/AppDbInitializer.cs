using System;
using MAFTLECOME.Models;

namespace MAFTLECOME.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
            {
                new Product()
{
    Name = "PSTN/ISDN (geen DSL)",
    Description = "PSTN/ISDN (geen DSL) item 46_00117.A1.2.MP EXT",
    ImageURL = "https://example.com/image_pstn_isdn.jpg",
    Price = 56.7919m, // Price in euro
    ArticleNumber = "101"
},
new Product()
{
    Name = "PSTN/ISDN (pas de xDSL)",
    Description = "PSTN/ISDN (pas de xDSL) item 46_00117.A3.1.MP EXT",
    ImageURL = "https://example.com/image_pstn_isdn_xdsl.jpg",
    Price = 58.0196m, // Price in euro
    ArticleNumber = "102"
},
new Product()
{
    Name = "PSTN/ISDN (pas de xDSL)",
    Description = "PSTN/ISDN (pas de xDSL) item 46_00117.A4.5.MP EXT",
    ImageURL = "https://example.com/image_pstn_isdn_xdsl.jpg",
    Price = 57.4615m, // Price in euro
    ArticleNumber = "103"
},
new Product()
{
    Name = "xDSL Telco",
    Description = "xDSL Telco item 46_00117.A1.2.MP EXT",
    ImageURL = "https://example.com/image_xdsl_telco.jpg",
    Price = 60.6539m, // Price in euro
    ArticleNumber = "104"
},
new Product()
{
    Name = "Support Full Install",
    Description = "Support Full Install item 46_00117.A1.2.MP EXT",
    ImageURL = "https://example.com/image_support_full_install.jpg",
    Price = 59.3702m, // Price in euro
    ArticleNumber = "105"
},
new Product()
{
    Name = "Standard & Advanced (premiers 50m inclus)",
    Description = "Standard & Advanced (premiers 50m inclus) item 46_00117.A3.1.MP EXT",
    ImageURL = "https://example.com/image_standard_advanced.jpg",
    Price = 60.6539m, // Price in euro
    ArticleNumber = "106"
},
new Product()
{
    Name = "Standard & Advanced (premiers 50m inclus)",
    Description = "Standard & Advanced (premiers 50m inclus) item 46_00117.A4.5.MP EXT",
    ImageURL = "https://example.com/image_standard_advanced.jpg",
    Price = 60.0846m, // Price in euro
    ArticleNumber = "107"
},
new Product()
{
    Name = "Standard Install",
    Description = "Standard Install item 46_00117.A1.2.MP EXT",
    ImageURL = "https://example.com/image_standard_install.jpg",
    Price = 67.1054m, // Price in euro
    ArticleNumber = "108"
},
new Product()
{
    Name = "Jumpering",
    Description = "Jumpering item 46_00117.A1.2.MP EXT",
    ImageURL = "https://example.com/image_jumpering.jpg",
    Price = 40.0154m, // Price in euro
    ArticleNumber = "109"
},
new Product()
{
    Name = "Jumpering",
    Description = "Jumpering item 46_00117.A3.1.MP EXT",
    ImageURL = "https://example.com/image_jumpering.jpg",
    Price = 40.8861m, // Price in euro
    ArticleNumber = "110"
},
new Product()
{
    Name = "Jumpering",
    Description = "Jumpering item 46_00117.A4.5.MP EXT",
    ImageURL = "https://example.com/image_jumpering.jpg",
    Price = 40.4731m, // Price in euro
    ArticleNumber = "111"
},
new Product()
{
    Name = "Swap Modems en/of Multiple Decoders",
    Description = "Swap Modems en/of Multiple Decoders item 46_00117.A1.2.MP EXT",
    ImageURL = "https://example.com/image_swap_modems.jpg",
    Price = 40.6517m, // Price in euro
    ArticleNumber = "112"
}




                // Add more products as needed
            });
                    context.SaveChanges();
                }
            }
        }

    }
}