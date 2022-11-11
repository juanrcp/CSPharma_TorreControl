using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityBasicoDAL.cspharma_informacional;

namespace CSPharma_TorreControl.Pages
{
    public class EditModel : PageModel
    {
        private readonly EntityBasicoDAL.cspharma_informacional.CspharmaInformacionalContext _context;

        public EditModel(EntityBasicoDAL.cspharma_informacional.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TdcTchEstadoPedido TdcTchEstadoPedido { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.TdcTchEstadoPedidos == null)
            {
                return NotFound();
            }

            var tdctchestadopedido =  await _context.TdcTchEstadoPedidos.FirstOrDefaultAsync(m => m.CodPedido == id);
            if (tdctchestadopedido == null)
            {
                return NotFound();
            }
            TdcTchEstadoPedido = tdctchestadopedido;
           ViewData["CodEstadoDevolucion"] = new SelectList(_context.TdcCatEstadosDevolucionPedidos, "CodEstadoDevolucion", "CodEstadoDevolucion");
           ViewData["CodEstadoEnvio"] = new SelectList(_context.TdcCatEstadosEnvioPedidos, "CodEstadoEnvio", "CodEstadoEnvio");
           ViewData["CodEstadoPago"] = new SelectList(_context.TdcCatEstadosPagoPedidos, "CodEstadoPago", "CodEstadoPago");
           ViewData["CodLinea"] = new SelectList(_context.TdcCatLineasDistribucions, "CodLinea", "CodLinea");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TdcTchEstadoPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TdcTchEstadoPedidoExists(TdcTchEstadoPedido.CodPedido))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TdcTchEstadoPedidoExists(string id)
        {
          return _context.TdcTchEstadoPedidos.Any(e => e.CodPedido == id);
        }
    }
}
