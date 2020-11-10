using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace DemoLibrary
{
    public class SqliteDataAccess
    {
        public static List<EmpleadoModel> CargaEmpleados()
        {
            using (IDbConnection cnn = new SQLiteConnection(CargaConnectionString()))
            {
                var output = cnn.Query<EmpleadoModel>("select * from Empleados", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void GuardaEmpleado(EmpleadoModel empleado)
        {
            using (IDbConnection cnn = new SQLiteConnection(CargaConnectionString()))
            {
                cnn.Execute("insert into Empleados (NombreEmpleado, Puesto, FechaIngreso) values (@nombreEmpleado, @puesto, @fechaIngreso)", empleado);
            }
        }

        public static string CargaConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
