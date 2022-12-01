using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EntityBasicoDAL.cspharma_informacional;

/// <summary>
/// Tabla de registros de usuarios/empleados con md_uuid (metadatos), md_date (fecha de inserción), id (único y autoincrement), cod_empleado (nombre de usuario/empleado de máximo 7 caracteres y primary key), clave_empleado (contraseña con mínimo 8 caracteres) y nivel_acceso_empleado (rol que por defecto será 2).
/// </summary>
public partial class DlkCatAccEmpleado
{
    public long Id { get; set; }

    //Con esta etiqueta vinculamos el atributo al controlador
    [BindProperty]
    public string CodEmpleado { get; set; } = null!;
    
    [BindProperty]
    public string ClaveEmpleado { get; set; } = null!;

    public long NivelAccesoEmpleado { get; set; }

    public DateTime MdDate { get; set; }

    public string MdUuid { get; set; } = null!;
}
