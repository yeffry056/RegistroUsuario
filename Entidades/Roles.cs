using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsuario.Entidades
{
    public class Roles
    {
        [Key]
        public int ID { get; set; }
        public String Nombres { get; set; }
        public String Alias { get; set; }
        public String Email { get; set; }
        public String Clave { get; set; }
        public String ConfirmarClave { get; set; }
        public int CostoXHora { get; set; }
        public String Nivel { get; set; }
        public String Activo { get; set; }

    }
}
