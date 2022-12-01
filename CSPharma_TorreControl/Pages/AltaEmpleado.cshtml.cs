using EntityBasicoDAL.cspharma_informacional;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSPharma_TorreControl.Pages
{
    public class AltaEmpleadoModel : PageModel
    {
        public string CodEmpleado { get; set; }
        public string ClaveEmpleado { get; set; }

        [BindProperty]
        public string ConfirmarClave { get; set; }

        //Aqui guardamos los mensajes de error y otros avisos, y se los pasamos a la vista.
        [BindProperty]
        public List<string> Mensajes { get; set; }

        private EntityBasicoDAL.cspharma_informacional.CspharmaInformacionalContext context = new CspharmaInformacionalContext();

        public void OnGet()
        {
        }

        public void OnPostSubmit(DlkCatAccEmpleado empleado)
        {
            Boolean clave = true;
            Boolean user = true;
            var usuarios = context.DlkCatAccEmpleados.ToList();

            // Comprobacion usuario. Comprobamos que no este vacio, sea nulo o tenga mas de 7 caracteres.
            if ((empleado.CodEmpleado == null) || (empleado.CodEmpleado.Length == 0) || (empleado.CodEmpleado.Length > 7))
            {
                Console.WriteLine("Nombre de usuario no valido.");
                Mensajes.Add("Nombre de usuario no valido.");
                user = false;

            }

            // Comprobacion usuario 2. Comprobamos que el usuario no exista en la BBDD
            foreach (var usuario in usuarios)
            {
               if(usuario.CodEmpleado == empleado.CodEmpleado)
               {
                    user = false;
                    Console.WriteLine("El Codigo de Empleado introducido ya existe.");
                    Mensajes.Add("El Codigo de Empleado introducido ya existe.");
                    break;
               }
            }
                        
            // Comprobamos clave. Comprobamos que no este vacia, sea nula o tenga menos de 8 caracteres.
            if ((empleado.ClaveEmpleado == null) || (empleado.ClaveEmpleado.Length == 0) || (empleado.ClaveEmpleado.Length < 8))
            {
                Console.WriteLine("Clave no valida. Tiene que tener al menos 8 caracteres.");
                Mensajes.Add("Clave no valida. Tiene que tener al menos 8 caracteres.");
                clave = false;

            }

            //Nos aseguramos que la clave y su confimacion sean iguales.
            if (this.ConfirmarClave != empleado.ClaveEmpleado)
            {
                Console.WriteLine("Las claves no coinciden.");
                Mensajes.Add("Las claves no coinciden.");
                clave = false;
            }

            if (clave && user)
            {
                //Una vez confimrado los datos introducidos procedemos a guardarlos en las variables del empleado procedemos a incluir la fecha de registro y campos por defecto.
                //Guardamos fecha de registro.
                empleado.MdDate = DateTime.Now;

                //Guardamos metadatos, para lo cual rescatamos el metadato anterior sumandole un numero.
                string sufijo = usuarios[usuarios.Count() - 1].MdUuid.Substring(usuarios[usuarios.Count() - 1].MdUuid.Length - 1);
                empleado.MdUuid = usuarios[usuarios.Count() - 1].MdUuid.Substring(0, usuarios[usuarios.Count() - 1].MdUuid.Length - 1) + (Convert.ToInt32(sufijo)+1);

                //Guardamos el empleado en el contexto para que lo añada a la BBDD y guardamos los cambios
                context.Add(empleado);
                context.SaveChanges();

                Console.WriteLine("Empleado añadido correctamente.");
                Mensajes.Add("Empleado añadido correctamente.");

            }
        }
    }
}
