using System;
using System.Collections.Generic;

namespace EntityBasicoDAL.cspharma_informacional;

public partial class TdcCatEstadosPagoPedido
{
    public int Id { get; set; }

    public string CodEstadoPago { get; set; } = null!;

    public string? DesEstadoPago { get; set; }

    public DateTime MdDate { get; set; }

    public string MdUuid { get; set; } = null!;

    public virtual ICollection<TdcTchEstadoPedido> TdcTchEstadoPedidos { get; } = new List<TdcTchEstadoPedido>();
}
