﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectMPD.Data;
using ProiectMPD.Models;

namespace ProiectMPD.Pages.Songs
{
    public class CreateModel : PageModel
    {
        private readonly ProiectMPD.Data.ApplicationDbContext _context;

        public CreateModel(ProiectMPD.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ReleaseID"] = new SelectList(_context.Releases, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Song Song { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Songs.Add(Song);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
