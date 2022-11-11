using System;
using System.Collections.Generic;

namespace EntityBasicoDAL.cspharma_informacional;

public partial class TdcCatEstadosDevolucionPedido
{
    public int Id { get; set; }

    public string CodEstadoDevolucion { get; set; } = null!;

    public string? DesEstadoDevolucion { get; set; }

    public DateTime MdDate { get; set; }

    public string MdUuid { get; set; } = null!;

    public virtual ICollection<TdcTchEstadoPedido> TdcTchEstadoPedidos { get; } = new List<TdcTchEstadoPedido>();
}
