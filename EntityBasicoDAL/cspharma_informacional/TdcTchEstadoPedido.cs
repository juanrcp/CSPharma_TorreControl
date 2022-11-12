using System;
using System.Collections.Generic;

namespace EntityBasicoDAL.cspharma_informacional;

public partial class TdcTchEstadoPedido
{
    public int Id { get; set; }

    public string CodPedido { get; set; } = null!;

    public string CodLinea { get; set; } = null!;

    public DateTime MdDate { get; set; }

    public string MdUuid { get; set; } = null!;

    public string? CodEstadoPago { get; set; }

    public string? CodEstadoEnvio { get; set; }

    public string? CodEstadoDevolucion { get; set; }

    public virtual TdcCatEstadosDevolucionPedido? CodEstadoDevolucionNavigation { get; set; }

    public virtual TdcCatEstadosEnvioPedido? CodEstadoEnvioNavigation { get; set; }

    public virtual TdcCatEstadosPagoPedido? CodEstadoPagoNavigation { get; set; }

<<<<<<< HEAD
    public virtual TdcCatLineasDistribucion CodLineaNavigation { get; set; } = null!;
=======
    //Tenemos que poner opcional este campo. 
    public virtual TdcCatLineasDistribucion? CodLineaNavigation { get; set; } = null!;
>>>>>>> e5de13ec8660ebe848d93f77819343ba0ceedf23
}
