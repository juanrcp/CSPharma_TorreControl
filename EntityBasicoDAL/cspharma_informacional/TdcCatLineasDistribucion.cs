using System;
using System.Collections.Generic;

namespace EntityBasicoDAL.cspharma_informacional;

public partial class TdcCatLineasDistribucion
{
    public int Id { get; set; }

    public string CodLinea { get; set; } = null!;

    public string CodProvincia { get; set; } = null!;

    public string CodMunicipio { get; set; } = null!;

    public string CodBarrio { get; set; } = null!;

    public DateTime MdDate { get; set; }

    public string MdUuid { get; set; } = null!;

    public virtual ICollection<TdcTchEstadoPedido> TdcTchEstadoPedidos { get; } = new List<TdcTchEstadoPedido>();
}
