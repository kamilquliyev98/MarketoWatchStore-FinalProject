using MarketoWatchStore.DAL;
using MarketoWatchStore.Enums;
using MarketoWatchStore.Extensions;
using MarketoWatchStore.Helpers;
using MarketoWatchStore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ProductController : Controller
    {
        private readonly MarketoDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductController(MarketoDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        #region Method for Pagination
        private async Task<IEnumerable<Product>> PaginateAsync(string status, int page)
        {
            ViewBag.Status = status;
            ViewBag.CurrentPage = page;

            IEnumerable<Product> products;

            switch (status)
            {
                case "active":
                    products = await _context.Products
                        .Include(p => p.Brand)
                        .Include(p => p.Display)
                        .Include(p => p.PowerSource)
                        .Include(p => p.SpecialType)
                        .Include(p => p.ProductImages)
                        .Include(p => p.Reviews)
                        .Include(p => p.ProductTags).ThenInclude(p => p.Tag)
                        .Include(p => p.ProductColours).ThenInclude(p => p.Colour)
                        .Include(p => p.ProductFeatures).ThenInclude(p => p.Feature)
                        .Where(p => !p.IsDeleted)
                        .OrderByDescending(p => p.Id)
                        .ToListAsync();
                    break;
                case "deleted":
                    products = await _context.Products
                        .Include(p => p.Brand)
                        .Include(p => p.Display)
                        .Include(p => p.PowerSource)
                        .Include(p => p.SpecialType)
                        .Include(p => p.ProductImages)
                        .Include(p => p.Reviews)
                        .Include(p => p.ProductTags).ThenInclude(p => p.Tag)
                        .Include(p => p.ProductColours).ThenInclude(p => p.Colour)
                        .Include(p => p.ProductFeatures).ThenInclude(p => p.Feature)
                        .Where(p => p.IsDeleted)
                        .OrderByDescending(p => p.Id)
                        .ToListAsync();
                    break;
                default:
                    products = await _context.Products
                        .Include(p => p.Brand)
                        .Include(p => p.Display)
                        .Include(p => p.PowerSource)
                        .Include(p => p.SpecialType)
                        .Include(p => p.ProductImages)
                        .Include(p => p.Reviews)
                        .Include(p => p.ProductTags).ThenInclude(p => p.Tag)
                        .Include(p => p.ProductColours).ThenInclude(p => p.Colour)
                        .Include(p => p.ProductFeatures).ThenInclude(p => p.Feature)
                        .OrderByDescending(p => p.Id)
                        .ToListAsync();
                    break;
            }

            ViewBag.PageCount = Math.Ceiling((double)products.Count() / 5);

            return products.Skip((page - 1) * 5).Take(5);
        }
        #endregion

        public async Task<IActionResult> AddProduct()
        {
            ViewBag.Colours = await _context.Colours.Where(c => !c.IsDeleted).ToListAsync();

            return PartialView("_ProductColourCountPartial");
        }

        #region Read
        public async Task<IActionResult> Index(string status = "active", int page = 1)
        {
            return View(await PaginateAsync(status, page));
        }

        public async Task<IActionResult> Detail(int? id, string status = "active", int page = 1)
        {
            if (id == null) return BadRequest();

            Product product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Display)
                .Include(p => p.PowerSource)
                .Include(p => p.SpecialType)
                .Include(p => p.ProductImages)
                .Include(p => p.Reviews)
                .Include(p => p.ProductTags).ThenInclude(p => p.Tag)
                .Include(p => p.ProductColours).ThenInclude(p => p.Colour)
                .Include(p => p.ProductFeatures).ThenInclude(p => p.Feature)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            ViewBag.Status = status;
            ViewBag.CurrentPage = page;

            return View(product);
        }
        #endregion

        #region Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Brands = await _context.Brands.Where(b => !b.IsDeleted).OrderBy(b => b.Title).ToListAsync();
            ViewBag.Displays = await _context.Displays.Where(d => !d.IsDeleted).OrderBy(d => d.Title).ToListAsync();
            ViewBag.PowerSources = await _context.PowerSources.Where(ps => !ps.IsDeleted).OrderBy(ps => ps.Title).ToListAsync();
            ViewBag.SpecialTypes = await _context.SpecialTypes.Where(st => !st.IsDeleted).OrderBy(st => st.Title).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).OrderBy(t => t.Title).ToListAsync();
            ViewBag.Colours = await _context.Colours.Where(c => !c.IsDeleted).OrderBy(c => c.Title).ToListAsync();
            ViewBag.Features = await _context.Features.Where(f => !f.IsDeleted).OrderBy(f => f.Title).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, string status = "active", int page = 1)
        {
            ViewBag.Brands = await _context.Brands.Where(b => !b.IsDeleted).OrderBy(b => b.Title).ToListAsync();
            ViewBag.Displays = await _context.Displays.Where(d => !d.IsDeleted).OrderBy(d => d.Title).ToListAsync();
            ViewBag.PowerSources = await _context.PowerSources.Where(ps => !ps.IsDeleted).OrderBy(ps => ps.Title).ToListAsync();
            ViewBag.SpecialTypes = await _context.SpecialTypes.Where(st => !st.IsDeleted).OrderBy(st => st.Title).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).OrderBy(t => t.Title).ToListAsync();
            ViewBag.Colours = await _context.Colours.Where(c => !c.IsDeleted).OrderBy(c => c.Title).ToListAsync();
            ViewBag.Features = await _context.Features.Where(f => !f.IsDeleted).OrderBy(f => f.Title).ToListAsync();

            if (!ModelState.IsValid) return View();

            if (product.Title.Length > 255)
            {
                ModelState.AddModelError("Title", "Max 255 symbols");
                return View();
            }

            if (product.Price < 0 || product.DiscountPrice < 0 || product.ExTax < 0)
            {
                ModelState.AddModelError("", "Money can not be lower than 0.");
                return View();
            }





            if (product.DiscountPrice >= product.Price)
            {
                ModelState.AddModelError("DiscountPrice", "Discount price cannot be equal to or greater than price.");
                return View();
            }

            if (product.ExTax >= product.Price)
            {
                ModelState.AddModelError("ExTax", "Tax price cannot be equal to or greater than price.");
                return View();
            }





            if (!await _context.Brands.AnyAsync(b => b.Id == product.BrandId && !b.IsDeleted))
            {
                ModelState.AddModelError("BrandId", "Has been selected incorrect brand.");
                return View();
            }





            if (!await _context.Displays.AnyAsync(d => d.Id == product.DisplayId && !d.IsDeleted))
            {
                ModelState.AddModelError("DisplayId", "Has been selected incorrect display.");
                return View();
            }





            if (!await _context.PowerSources.AnyAsync(ps => ps.Id == product.PowerSourceId && !ps.IsDeleted))
            {
                ModelState.AddModelError("PowerSourceId", "Has been selected incorrect power source.");
                return View();
            }





            if ((int)product.Gender < 1 || (int)product.Gender > 3)
            {
                ModelState.AddModelError("Gender", "Has been selected incorrect gender.");
                return View();
            }





            if (product.SpecialTypeId != null)
            {
                if (!await _context.SpecialTypes.AnyAsync(st => st.Id == product.SpecialTypeId && !st.IsDeleted))
                {
                    ModelState.AddModelError("SpecialTypeId", "Has been selected incorrect special type.");
                    return View();
                }
            }





            if (product.FeatureIds.Count > 0)
            {
                foreach (int featureId in product.FeatureIds)
                {
                    if (!await _context.Features.AnyAsync(c => c.Id == featureId))
                    {
                        ModelState.AddModelError("", "Has been selected incorrect feature.");
                        return View();
                    }
                }

                List<ProductFeature> productFeatures = new List<ProductFeature>();
                foreach (var item in product.FeatureIds)
                {
                    ProductFeature productFeature = new ProductFeature
                    {
                        FeatureId = item
                    };

                    productFeatures.Add(productFeature);
                }
                product.ProductFeatures = productFeatures;
            }





            if (product.TagIds.Count > 0)
            {
                foreach (int tagId in product.TagIds)
                {
                    if (!await _context.Tags.AnyAsync(c => c.Id == tagId))
                    {
                        ModelState.AddModelError("", "Has been selected incorrect tag.");
                        return View();
                    }
                }

                List<ProductTag> tags = new List<ProductTag>();
                foreach (int item in product.TagIds)
                {
                    ProductTag productTag = new ProductTag
                    {
                        TagId = item
                    };

                    tags.Add(productTag);
                }
                product.ProductTags = tags;
            }





            if (product.ColourIds.Count != product.Counts.Count)
            {
                ModelState.AddModelError("", "Please, select all options.");
                return View();
            }

            foreach (int colourId in product.ColourIds)
            {
                if (!await _context.Colours.AnyAsync(c => c.Id == colourId))
                {
                    ModelState.AddModelError("", "Has been selected incorrect colour.");
                    return View();
                }
            }

            List<ProductColour> productColourCounts = new List<ProductColour>();
            for (int i = 0; i < product.ColourIds.Count; i++)
            {
                ProductColour productColourCount = new ProductColour
                {
                    ColourId = product.ColourIds[i],
                    Count = product.Counts[i]
                };

                productColourCounts.Add(productColourCount);
            }
            product.ProductColours = productColourCounts;

            product.Count = product.Counts.Sum();





            #region Images Checking & Saving
            if (product.ProductImagesFiles != null && product.ProductImagesFiles.Count() > 6)
            {
                ModelState.AddModelError("ProductImagesFiles", "Max 6 images can be uploaded...");
                return View();
            }

            if (product.MainImageFile != null)
            {
                if (!product.MainImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("MainImageFile", "File content type is not image/jpeg");
                    return View();
                }

                if (!product.MainImageFile.CheckFileSize(100))
                {
                    ModelState.AddModelError("MainImageFile", "File size is greater than 100 KB");
                    return View();
                }

                product.MainImage = product.MainImageFile.CreateFile(_env, "assets", "images", "products");
            }
            else
            {
                ModelState.AddModelError("MainImageFile", "You have to upload an image.");
                return View();
            }

            if (product.ProductImagesFiles != null && product.ProductImagesFiles.Count() > 0)
            {
                List<ProductImage> productImages = new List<ProductImage>();

                foreach (IFormFile file in product.ProductImagesFiles)
                {
                    if (!file.CheckFileContentType("image/jpeg"))
                    {
                        ModelState.AddModelError("ProductImagesFiles", "Not all files have the same content type image/jpeg");
                        return View();
                    }

                    if (!file.CheckFileSize(100))
                    {
                        ModelState.AddModelError("ProductImagesFiles", "The size of all files is not less than 100 KB");
                        return View();
                    }

                    ProductImage productImage = new ProductImage
                    {
                        Image = file.CreateFile(_env, "assets", "images", "products"),
                        CreatedAt = DateTime.UtcNow.AddHours(4)
                    };

                    productImages.Add(productImage);
                }

                product.ProductImages = productImages;
            }
            else
            {
                ModelState.AddModelError("ProductImagesFiles", "You have to upload other images of this product.");
                return View();
            }

            if (product.SlideImageFile != null)
            {
                if (!product.SlideImageFile.CheckFileContentType("image/png") || !product.SlideImageFile.CheckFileContentType("image/webp"))
                {
                    ModelState.AddModelError("SlideImageFile", "File content type is not image/png or image/webp");
                    return View();
                }

                if (!product.SlideImageFile.CheckFileSize(100))
                {
                    ModelState.AddModelError("SlideImageFile", "File size is greater than 100 KB");
                    return View();
                }

                product.SlideImage = product.SlideImageFile.CreateFile(_env, "assets", "images", "slider");
            }
            else
            {
                if (product.ShareOnHomeSlide == true)
                {
                    ModelState.AddModelError("ShareOnHomeSlide", "You have to upload an image for slide.");
                    return View();
                }
            }

            if (product.PosterImageFile != null)
            {
                if (!product.PosterImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("PosterImageFile", "File content type is not image/jpeg");
                    return View();
                }

                if (!product.PosterImageFile.CheckFileSize(100))
                {
                    ModelState.AddModelError("PosterImageFile", "File size is greater than 100 KB");
                    return View();
                }

                product.PosterImage = product.PosterImageFile.CreateFile(_env, "assets", "images", "poster");
            }
            else
            {
                if (product.ShareAsPoster == true)
                {
                    ModelState.AddModelError("ShareAsPoster", "You have to upload an image for poster.");
                    return View();
                }
            }
            #endregion





            product.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            Product product = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Brand)
                .Include(p => p.Display)
                .Include(p => p.PowerSource)
                .Include(p => p.SpecialType)
                .Include(p => p.ProductTags).ThenInclude(p => p.Tag)
                .Include(p => p.ProductColours).ThenInclude(p => p.Colour)
                .Include(p => p.ProductFeatures).ThenInclude(p => p.Feature)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null) return NotFound();

            ViewBag.Brands = await _context.Brands.Where(b => !b.IsDeleted).OrderBy(b => b.Title).ToListAsync();
            ViewBag.Displays = await _context.Displays.Where(d => !d.IsDeleted).OrderBy(d => d.Title).ToListAsync();
            ViewBag.PowerSources = await _context.PowerSources.Where(ps => !ps.IsDeleted).OrderBy(ps => ps.Title).ToListAsync();
            ViewBag.SpecialTypes = await _context.SpecialTypes.Where(st => !st.IsDeleted).OrderBy(st => st.Title).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).OrderBy(t => t.Title).ToListAsync();
            ViewBag.Colours = await _context.Colours.Where(c => !c.IsDeleted).OrderBy(c => c.Title).ToListAsync();
            ViewBag.Features = await _context.Features.Where(f => !f.IsDeleted).OrderBy(f => f.Title).ToListAsync();

            product.ColourIds = product.ProductColours.Select(c => c.Colour.Id).ToList();
            product.Counts = product.ProductColours.Select(c => c.Count).ToList();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Product product, int? id, string status = "active", int page = 1)
        {
            if (id == null) return BadRequest();

            if (product.Id != id) return BadRequest();

            ViewBag.Brands = await _context.Brands.Where(b => !b.IsDeleted).OrderBy(b => b.Title).ToListAsync();
            ViewBag.Displays = await _context.Displays.Where(d => !d.IsDeleted).OrderBy(d => d.Title).ToListAsync();
            ViewBag.PowerSources = await _context.PowerSources.Where(ps => !ps.IsDeleted).OrderBy(ps => ps.Title).ToListAsync();
            ViewBag.SpecialTypes = await _context.SpecialTypes.Where(st => !st.IsDeleted).OrderBy(st => st.Title).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).OrderBy(t => t.Title).ToListAsync();
            ViewBag.Colours = await _context.Colours.Where(c => !c.IsDeleted).OrderBy(c => c.Title).ToListAsync();
            ViewBag.Features = await _context.Features.Where(f => !f.IsDeleted).OrderBy(f => f.Title).ToListAsync();

            Product dbProduct = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Brand)
                .Include(p => p.Display)
                .Include(p => p.PowerSource)
                .Include(p => p.SpecialType)
                .Include(p => p.ProductTags).ThenInclude(p => p.Tag)
                .Include(p => p.ProductColours).ThenInclude(p => p.Colour)
                .Include(p => p.ProductFeatures).ThenInclude(p => p.Feature)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (dbProduct == null) return NotFound();

            if (!ModelState.IsValid) return View(dbProduct);

            if (product.Title.Length > 255)
            {
                ModelState.AddModelError("Title", "Max 255 symbols");
                return View();
            }

            if (product.Price < 0 || product.DiscountPrice < 0 || product.ExTax < 0)
            {
                ModelState.AddModelError("", "Money can not be lower than 0.");
                return View();
            }





            if (product.DiscountPrice >= product.Price)
            {
                ModelState.AddModelError("DiscountPrice", "Discount price cannot be equal to or greater than price.");
                return View();
            }

            if (product.ExTax >= product.Price)
            {
                ModelState.AddModelError("ExTax", "Tax price cannot be equal to or greater than price.");
                return View();
            }





            if (!await _context.Brands.AnyAsync(b => b.Id == product.BrandId && !b.IsDeleted))
            {
                ModelState.AddModelError("BrandId", "Has been selected incorrect brand.");
                return View();
            }





            if (!await _context.Displays.AnyAsync(d => d.Id == product.DisplayId && !d.IsDeleted))
            {
                ModelState.AddModelError("DisplayId", "Has been selected incorrect display.");
                return View();
            }





            if (!await _context.PowerSources.AnyAsync(ps => ps.Id == product.PowerSourceId && !ps.IsDeleted))
            {
                ModelState.AddModelError("PowerSourceId", "Has been selected incorrect power source.");
                return View();
            }





            if ((int)product.Gender < 1 || (int)product.Gender > 3)
            {
                ModelState.AddModelError("Gender", "Has been selected incorrect gender.");
                return View();
            }





            if (product.SpecialTypeId != null)
            {
                if (!await _context.SpecialTypes.AnyAsync(st => st.Id == product.SpecialTypeId && !st.IsDeleted))
                {
                    ModelState.AddModelError("SpecialTypeId", "Has been selected incorrect special type.");
                    return View();
                }
            }





            if (product.FeatureIds.Count > 0)
            {
                foreach (int featureId in product.FeatureIds)
                {
                    if (!await _context.Features.AnyAsync(c => c.Id == featureId))
                    {
                        ModelState.AddModelError("", "Has been selected incorrect feature.");
                        return View();
                    }
                }

                _context.ProductFeatures.RemoveRange(dbProduct.ProductFeatures);

                List<ProductFeature> productFeatures = new List<ProductFeature>();
                foreach (var item in product.FeatureIds)
                {
                    ProductFeature productFeature = new ProductFeature
                    {
                        FeatureId = item
                    };

                    productFeatures.Add(productFeature);
                }
                product.ProductFeatures = productFeatures;
            }
            else
            {
                _context.ProductFeatures.RemoveRange(dbProduct.ProductFeatures);
            }





            if (product.TagIds.Count > 0)
            {
                foreach (int tagId in product.TagIds)
                {
                    if (!await _context.Tags.AnyAsync(c => c.Id == tagId))
                    {
                        ModelState.AddModelError("", "Has been selected incorrect tag.");
                        return View();
                    }
                }

                _context.ProductTags.RemoveRange(dbProduct.ProductTags);

                List<ProductTag> productTags = new List<ProductTag>();
                foreach (var item in product.TagIds)
                {
                    ProductTag productTag = new ProductTag
                    {
                        TagId = item
                    };

                    productTags.Add(productTag);
                }
                product.ProductTags = productTags;
            }
            else
            {
                _context.ProductTags.RemoveRange(dbProduct.ProductTags);
            }





            if (product.ColourIds.Count != product.Counts.Count)
            {
                ModelState.AddModelError("", "Please, select all options.");
                return View();
            }

            foreach (int colourId in product.ColourIds)
            {
                if (!await _context.Colours.AnyAsync(c => c.Id == colourId))
                {
                    ModelState.AddModelError("", "Has been selected incorrect colour.");
                    return View();
                }
            }

            _context.ProductColours.RemoveRange(dbProduct.ProductColours);

            List<ProductColour> productColourCounts = new List<ProductColour>();
            for (int i = 0; i < product.ColourIds.Count; i++)
            {
                ProductColour productColourCount = new ProductColour
                {
                    ColourId = product.ColourIds[i],
                    Count = product.Counts[i]
                };

                productColourCounts.Add(productColourCount);
            }
            product.ProductColours = productColourCounts;












            #region Image Checking
            int emptySpace4Images = 6 - (int)(dbProduct.ProductImages?.Where(p => !p.IsDeleted).Count());

            if (product.ProductImagesFiles != null && product.ProductImagesFiles.Count() > emptySpace4Images)
            {
                if (emptySpace4Images == 0)
                {
                    ModelState.AddModelError("ProductImagesFiles", "You have reached product images limit.");
                }
                else
                {
                    ModelState.AddModelError("ProductImagesFiles", $"You can upload max {emptySpace4Images} image(s).");
                }
                return View(dbProduct);
            }





            if (product.MainImageFile != null)
            {
                if (!product.MainImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("MainImageFile", "File content type is not image/jpeg");
                    return View(dbProduct);
                }

                if (!product.MainImageFile.CheckFileSize(100))
                {
                    ModelState.AddModelError("MainImageFile", "File size is greater than 100 KB");
                    return View(dbProduct);
                }

                Helper.DeleteFile(_env, dbProduct.MainImage, "assets", "images", "products");
                dbProduct.MainImage = product.MainImageFile.CreateFile(_env, "assets", "images", "products");
            }





            if (product.ProductImagesFiles != null && product.ProductImagesFiles.Count() > 0)
            {
                List<ProductImage> productImages = dbProduct.ProductImages.ToList();

                foreach (IFormFile file in product.ProductImagesFiles)
                {
                    if (!file.CheckFileContentType("image/jpeg"))
                    {
                        ModelState.AddModelError("ProductImagesFiles", "Not all files have the same content type image/jpeg");
                        return View(dbProduct);
                    }

                    if (!file.CheckFileSize(100))
                    {
                        ModelState.AddModelError("ProductImagesFiles", "The size of all files is not less than 100 KB");
                        return View(dbProduct);
                    }

                    ProductImage productImage = new ProductImage
                    {
                        Image = file.CreateFile(_env, "assets", "img", "product"),
                        CreatedAt = DateTime.UtcNow.AddHours(4)
                    };

                    productImages.Add(productImage);
                }

                dbProduct.ProductImages = productImages;
            }





            if (product.SlideImageFile != null)
            {
                if (!product.SlideImageFile.CheckFileContentType("image/png") || !product.SlideImageFile.CheckFileContentType("image/webp"))
                {
                    ModelState.AddModelError("SlideImageFile", "File content type is not image/png or image/webp");
                    return View();
                }

                if (!product.SlideImageFile.CheckFileSize(100))
                {
                    ModelState.AddModelError("SlideImageFile", "File size is greater than 100 KB");
                    return View();
                }

                product.SlideImage = product.SlideImageFile.CreateFile(_env, "assets", "images", "slider");
            }
            else
            {
                if (product.ShareOnHomeSlide == true)
                {
                    ModelState.AddModelError("ShareOnHomeSlide", "You have to upload an image for slide.");
                    return View();
                }
            }





            if (product.PosterImageFile != null)
            {
                if (!product.PosterImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("PosterImageFile", "File content type is not image/jpeg");
                    return View();
                }

                if (!product.PosterImageFile.CheckFileSize(100))
                {
                    ModelState.AddModelError("PosterImageFile", "File size is greater than 100 KB");
                    return View();
                }

                product.PosterImage = product.PosterImageFile.CreateFile(_env, "assets", "images", "poster");
            }
            else
            {
                if (product.ShareAsPoster == true)
                {
                    ModelState.AddModelError("ShareAsPoster", "You have to upload an image for poster.");
                    return View();
                }
            }
            #endregion





            dbProduct.Title = product.Title;
            dbProduct.Price = product.Price;
            dbProduct.DiscountPrice = product.DiscountPrice;
            dbProduct.ExTax = product.ExTax;
            dbProduct.Description = product.Description;
            dbProduct.BrandId = product.BrandId;
            dbProduct.DisplayId = product.DisplayId;
            dbProduct.PowerSourceId = product.PowerSourceId;
            dbProduct.Gender = product.Gender;
            dbProduct.SpecialTypeId = product.SpecialTypeId;
            dbProduct.IsNewArrival = product.IsNewArrival;
            dbProduct.ShareOnHomeSlide = product.ShareOnHomeSlide;
            dbProduct.ShareAsPoster = product.ShareAsPoster;
            dbProduct.ProductFeatures = product.ProductFeatures;
            dbProduct.ProductTags = product.ProductTags;
            dbProduct.ProductColours = product.ProductColours;
            dbProduct.Count = product.Counts.Sum();

            dbProduct.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }

        public async Task<IActionResult> DeleteProductImage(int? id)
        {
            if (id == null) return BadRequest();

            Product product = await _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.ProductImages.Any(pi => pi.Id == id && !pi.IsDeleted));

            if (product == null) return NotFound();

            ViewBag.Brands = await _context.Brands.Where(b => !b.IsDeleted).OrderBy(b => b.Title).ToListAsync();
            ViewBag.Displays = await _context.Displays.Where(d => !d.IsDeleted).OrderBy(d => d.Title).ToListAsync();
            ViewBag.PowerSources = await _context.PowerSources.Where(ps => !ps.IsDeleted).OrderBy(ps => ps.Title).ToListAsync();
            ViewBag.SpecialTypes = await _context.SpecialTypes.Where(st => !st.IsDeleted).OrderBy(st => st.Title).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).OrderBy(t => t.Title).ToListAsync();
            ViewBag.Colours = await _context.Colours.Where(c => !c.IsDeleted).OrderBy(c => c.Title).ToListAsync();
            ViewBag.Features = await _context.Features.Where(f => !f.IsDeleted).OrderBy(f => f.Title).ToListAsync();

            ProductImage productImage = product.ProductImages.FirstOrDefault(p => p.Id == id);
            productImage.IsDeleted = true;
            productImage.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_UpdateProductImagesPartial", product);
        }

        public async Task<IActionResult> DeleteSlideImage(string slide)
        {
            if (slide == null) return BadRequest();

            Product product = await _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.SlideImage == slide && !p.IsDeleted);

            if (product == null) return NotFound();

            ViewBag.Brands = await _context.Brands.Where(b => !b.IsDeleted).OrderBy(b => b.Title).ToListAsync();
            ViewBag.Displays = await _context.Displays.Where(d => !d.IsDeleted).OrderBy(d => d.Title).ToListAsync();
            ViewBag.PowerSources = await _context.PowerSources.Where(ps => !ps.IsDeleted).OrderBy(ps => ps.Title).ToListAsync();
            ViewBag.SpecialTypes = await _context.SpecialTypes.Where(st => !st.IsDeleted).OrderBy(st => st.Title).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).OrderBy(t => t.Title).ToListAsync();
            ViewBag.Colours = await _context.Colours.Where(c => !c.IsDeleted).OrderBy(c => c.Title).ToListAsync();
            ViewBag.Features = await _context.Features.Where(f => !f.IsDeleted).OrderBy(f => f.Title).ToListAsync();

            Helper.DeleteFile(_env, product.SlideImage, "assets", "images", "slider");

            product.SlideImage = null;
            product.ShareOnHomeSlide = false;

            await _context.SaveChangesAsync();

            return PartialView("_UpdateProductImagesPartial", product);
        }

        public async Task<IActionResult> DeletePosterImage(string poster)
        {
            if (poster == null) return BadRequest();

            Product product = await _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.PosterImage == poster && !p.IsDeleted);

            if (product == null) return NotFound();

            ViewBag.Brands = await _context.Brands.Where(b => !b.IsDeleted).OrderBy(b => b.Title).ToListAsync();
            ViewBag.Displays = await _context.Displays.Where(d => !d.IsDeleted).OrderBy(d => d.Title).ToListAsync();
            ViewBag.PowerSources = await _context.PowerSources.Where(ps => !ps.IsDeleted).OrderBy(ps => ps.Title).ToListAsync();
            ViewBag.SpecialTypes = await _context.SpecialTypes.Where(st => !st.IsDeleted).OrderBy(st => st.Title).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).OrderBy(t => t.Title).ToListAsync();
            ViewBag.Colours = await _context.Colours.Where(c => !c.IsDeleted).OrderBy(c => c.Title).ToListAsync();
            ViewBag.Features = await _context.Features.Where(f => !f.IsDeleted).OrderBy(f => f.Title).ToListAsync();

            Helper.DeleteFile(_env, product.PosterImage, "assets", "images", "poster");

            product.PosterImage = null;
            product.ShareAsPoster = false;

            await _context.SaveChangesAsync();

            return PartialView("_UpdateProductImagesPartial", product);
        }
        #endregion
    }
}
