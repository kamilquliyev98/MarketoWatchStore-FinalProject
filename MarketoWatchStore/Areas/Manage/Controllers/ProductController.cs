using MarketoWatchStore.DAL;
using MarketoWatchStore.Extensions;
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

        public async Task<IActionResult> AddProduct()
        {
            ViewBag.Colours = await _context.Colours.Where(c => !c.IsDeleted).ToListAsync();

            return PartialView("_ProductColourCountPartial");
        }

        #region Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Brands = await _context.Brands.Where(b => !b.IsDeleted).ToListAsync();
            ViewBag.Displays = await _context.Displays.Where(d => !d.IsDeleted).ToListAsync();
            ViewBag.PowerSources = await _context.PowerSources.Where(ps => !ps.IsDeleted).ToListAsync();
            ViewBag.SpecialTypes = await _context.SpecialTypes.Where(st => !st.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();
            ViewBag.Colours = await _context.Colours.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Features = await _context.Features.Where(f => !f.IsDeleted).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, string status = "active", int page = 1)
        {
            ViewBag.Brands = await _context.Brands.Where(b => !b.IsDeleted).ToListAsync();
            ViewBag.Displays = await _context.Displays.Where(d => !d.IsDeleted).ToListAsync();
            ViewBag.PowerSources = await _context.PowerSources.Where(ps => !ps.IsDeleted).ToListAsync();
            ViewBag.SpecialTypes = await _context.SpecialTypes.Where(st => !st.IsDeleted).ToListAsync();
            ViewBag.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();
            ViewBag.Colours = await _context.Colours.Where(c => !c.IsDeleted).ToListAsync();
            ViewBag.Features = await _context.Features.Where(f => !f.IsDeleted).ToListAsync();

            if (!ModelState.IsValid) return View();

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

            if (!await _context.SpecialTypes.AnyAsync(st => st.Id == product.SpecialTypeId && !st.IsDeleted))
            {
                ModelState.AddModelError("SpecialTypeId", "Has been selected incorrect special type.");
                return View();
            }

            if (product.ProductImagesFiles.Count() > 6)
            {
                ModelState.AddModelError("ProductImagesFiles", "Max 6 images can be uploaded...");
                return View();
            }

            if (product.ProductImagesFiles != null && product.ProductImagesFiles.Count() > 6)
            {
                ModelState.AddModelError("ProductImagesFiles", "You can upload max 6 images.");
                return View();
            }

            if (product.MainImageFile != null)
            {
                if (!product.MainImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("MainImageFile", "Content type must be image/jpeg");
                    return View();
                }

                if (!product.MainImageFile.CheckFileSize(100))
                {
                    ModelState.AddModelError("MainImageFile", "Max file size: 100 KB");
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
                        ModelState.AddModelError("ProductImagesFiles", "Content type must be image/jpeg");
                        return View();
                    }

                    if (!file.CheckFileSize(50))
                    {
                        ModelState.AddModelError("ProductImagesFiles", "Max file size: 50 KB");
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
                    ModelState.AddModelError("SlideImageFile", "Content type must be image/png or image/webp");
                    return View();
                }

                if (!product.SlideImageFile.CheckFileSize(100))
                {
                    ModelState.AddModelError("SlideImageFile", "Max file size: 100 KB");
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
                    ModelState.AddModelError("PosterImageFile", "Content type must be image/jpeg");
                    return View();
                }

                if (!product.PosterImageFile.CheckFileSize(100))
                {
                    ModelState.AddModelError("PosterImageFile", "Max file size: 100 KB");
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

            product.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }
        #endregion
    }
}
