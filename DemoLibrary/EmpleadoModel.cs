using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class EmpleadoModel
    {
        public int idEmpleado { get; }
        public string nombreEmpleado { get; set; }
        public string puesto { get; set; }
        public DateTime fechaIngreso { get; set; }
    }
}
