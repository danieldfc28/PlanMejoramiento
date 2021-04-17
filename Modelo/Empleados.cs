using System;
using System.Collections.Generic;

namespace Evidencia.Modelo
{
    public partial class Empleados
    {
        public uint Cedula { get; set; }
        public string Nombre { get; set; }
        public int? Salario { get; set; }
        public int? DiasVacaciones { get; set; }
        public int? VacacionesPagar { get; set; }
    }
}
