using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopFashion.Data;
using ShopFashion.Models;

namespace ShopFashion.Controllers
{
    public class FashionsController : Controller
    {
        private readonly ShopFashionContext _context;

        public FashionsController(ShopFashionContext context)
        {
            _context = context;
        }

        // GET: Fashions
        public async Task<IActionResult> Index(string fashionGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Fashion
                                            orderby b.LoaiHang
                                            select b.LoaiHang;
            var fashions = from b in _context.Fashion
                        select b;
            if (!string.IsNullOrEmpty(searchString))
            {
                fashions = fashions.Where(s => s.MatHang!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(fashionGenre))
            {
                fashions = fashions.Where(x => x.LoaiHang == fashionGenre);
            }
            var fashionGenreVM = new FashionGenreViewModel
            {
                LoaiHangs = new SelectList(await
           genreQuery.Distinct().ToListAsync()),
                Fashions = await fashions.ToListAsync()
            };
            return View(fashionGenreVM);
        }
        public async Task<IActionResult> AdTrangChu(string fashionGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Fashion
                                            orderby b.LoaiHang
                                            select b.LoaiHang;
            var fashions = from b in _context.Fashion
                           select b;
            if (!string.IsNullOrEmpty(searchString))
            {
                fashions = fashions.Where(s => s.MatHang!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(fashionGenre))
            {
                fashions = fashions.Where(x => x.LoaiHang == fashionGenre);
            }
            var fashionGenreVM = new FashionGenreViewModel
            {
                LoaiHangs = new SelectList(await
           genreQuery.Distinct().ToListAsync()),
                Fashions = await fashions.ToListAsync()
            };
            return View(fashionGenreVM);
        }


        // GET: Fashions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fashion = await _context.Fashion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fashion == null)
            {
                return NotFound();
            }

            return View(fashion);
        }

        // GET: Fashions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fashions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MatHang,NgayDatHang,NgayGiaoHang,LoaiHang,Gia")] Fashion fashion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fashion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fashion);
        }

        // GET: Fashions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fashion = await _context.Fashion.FindAsync(id);
            if (fashion == null)
            {
                return NotFound();
            }
            return View(fashion);
        }

        // POST: Fashions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MatHang,NgayDatHang,NgayGiaoHang,LoaiHang,Gia")] Fashion fashion)
        {
            if (id != fashion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fashion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FashionExists(fashion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fashion);
        }

        // GET: Fashions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fashion = await _context.Fashion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fashion == null)
            {
                return NotFound();
            }

            return View(fashion);
        }

        // POST: Fashions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fashion = await _context.Fashion.FindAsync(id);
            _context.Fashion.Remove(fashion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FashionExists(int id)
        {
            return _context.Fashion.Any(e => e.Id == id);
        }
    }
}
