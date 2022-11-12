using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityBasicoDAL.cspharma_informacional;

namespace CSPharma_TorreControl.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly EntityBasicoDAL.cspharma_informacional.CspharmaInformacionalContext _context;

        public DetailsModel(EntityBasicoDAL.cspharma_informacional.CspharmaInformacionalContext context)
        {
            _context = context;
        }

      public TdcTchEstadoPedido TdcTchEstadoPedido { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.TdcTchEstadoPedidos == null)
            {
                return NotFound();
            }

            var tdctchestadopedido = await _context.TdcTchEstadoPedidos.FirstOrDefaultAsync(m => m.CodPedido == id);
            if (tdctchestadopedido == null)
            {
                return NotFound();
            }
            else 
            {
                TdcTchEstadoPedido = tdctchestadopedido;
            }
            return Page();
        }
    }
}
