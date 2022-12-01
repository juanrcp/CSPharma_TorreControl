using EntityBasicoDAL.cspharma_informacional;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace CSPharma_TorreControl.Pages
{

    public class LoginModel : PageModel
    {
        //CodEmpleado para pasarlo a la vista
        public string CodEmpleado { get; set; }

        //ClaveEmpleado para pasarlo a la vista
        public string ClaveEmpleado { get; set; }

        //Aqui guardamos los mensajes de error y otros avisos, y se los pasamos a la vista.
        [BindProperty]
        public List<string> Mensajes { get; set; }

        private EntityBasicoDAL.cspharma_informacional.CspharmaInformacionalContext context = new CspharmaInformacionalContext();

        public void OnGet()
        {
        }

        //Establecemos metodo OnPostSubmit con variable de la clase de la consulta que queremos realizar
        public void OnPostSubmit(DlkCatAccEmpleado empleado)
        {
            Boolean clave = true;
            Boolean user = true;

            // Comprobacion usuario. Comprobamos que no este vacio, sea nulo o tenga mas de 7 caracteres.
            if ((empleado.CodEmpleado == null) || (empleado.CodEmpleado.Length == 0) || (empleado.CodEmpleado.Length > 7))
            {
                Console.WriteLine("Nombre de usuario no valido.");
                this.Mensajes.Add("Nombre de usuario no valido.");
                user = false;
            }

            // Comprobamos clave. Comprobamos que no este vacia, sea nula o tenga menos de 8 caracteres.
            if ((empleado.ClaveEmpleado == null) || (empleado.ClaveEmpleado.Length == 0) || (empleado.ClaveEmpleado.Length < 8))
            {
                Console.WriteLine("Clave no valida. Tiene que tener al menos 8 caracteres.");
                this.Mensajes.Add("Clave no valida. Tiene que tener al menos 8 caracteres.");
                clave = false;
            }

            
            if(clave && user)
            {
                //Guardamos en una lista la informacion recogida en el contexto
                var usuarios = context.DlkCatAccEmpleados.ToList();

                //Comprobamos que los datos recogidos se corresponden a los datos de un empleado (CodEmpleado y ClaveEmpleado)
                for (int i = 0; i < usuarios.Count; i++)
                {
                    if (usuarios[i].CodEmpleado == empleado.CodEmpleado && usuarios[i].ClaveEmpleado == empleado.ClaveEmpleado)
                    {
                        user = true;
                        break;
                    }
                    else
                    {
                        user = false;
                    }
                }

                //Mensajes de confimacion o negacion de acceso
                if (clave && user)
                {
                    Console.WriteLine("ACCESO CONCEDIDO: Codigo de Empleado y Clave de Empleado correctos.");
                    this.Mensajes.Add("ACCESO CONCEDIDO: Codigo de Empleado y Clave de Empleado correctos.");
                }
                else
                {
                    Console.WriteLine("ACCESO DENEGADO: Codigo de Empleado y Clave de Empleado incorrectos.");
                    this.Mensajes.Add("ACCESO DENEGADO: Codigo de Empleado y Clave de Empleado incorrectos.");
                }
            }         
        }
    }
}
