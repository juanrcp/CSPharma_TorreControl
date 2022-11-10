using System;
using System.Collections.Generic;

namespace EntityBasicoDAL.cspharma_informacional;

public partial class TdcCatEstadosEnvioPedido
{
    public int Id { get; set; }

    public string CodEstadoEnvio { get; set; } = null!;

    public string? DesEstadoEnvio { get; set; }

    public DateTime MdDate { get; set; }

    public string MdUuid { get; set; } = null!;

    public virtual ICollection<TdcTchEstadoPedido> TdcTchEstadoPedidos { get; } = new List<TdcTchEstadoPedido>();
}
