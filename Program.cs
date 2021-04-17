using System;
using System.Linq;
using Evidencia.Modelo;
using System.Collections.Generic;

namespace Evidencia
{
    class Program
    {
        static List<Empleados> empleados = new List<Empleados>();
        static Validaciones Validar = new Validaciones();
        static void Main(string[] args)
        {
            int menu;
            string aux;
            bool entradaValida = false;
            Marco();

            do
            {
                Console.SetCursorPosition(45, 8); Console.WriteLine("Bienvenidos....");

                Console.SetCursorPosition(45, 10); Console.WriteLine("1.) Agregar Empleados");
                Console.SetCursorPosition(45, 11); Console.WriteLine("2.) Buscar Empleados");
                Console.SetCursorPosition(45, 12); Console.WriteLine("3.) Listar Empleados");

                Console.SetCursorPosition(45, 14); Console.WriteLine("0.) Salir... ");

                do
                {
                    Console.SetCursorPosition(47, 18); Console.Write("╔═");
                    Console.SetCursorPosition(52, 18); Console.Write("═╗");
                    Console.SetCursorPosition(47, 20); Console.Write("╚═");
                    Console.SetCursorPosition(52, 20); Console.Write("═╝");
                    Console.SetCursorPosition(40, 16); Console.WriteLine("Escoja una opcion");
                    Console.SetCursorPosition(50, 19); aux = Console.ReadLine();
                    if (!Validar.Vacio(aux))
                        if (Validar.Numero(aux))
                            entradaValida = true;
                } while (!entradaValida);

                menu = Convert.ToInt32(aux);

                switch (menu)
                {
                    case 1:
                        AgregarEmpleado();
                        break;
                    case 2:
                        BuscarEmpleado();
                        break;
                    case 3:
                        ListarEmpleados();
                        break;
                    case 0:
                        Console.WriteLine("Gracias y hasta luego !...");
                        break;
                    default :
                        Console.WriteLine("Opcion invalida");
                        break;
                }
            } while (menu > 0);
        }

        static void AgregarEmpleado()
        {
            
            Console.Clear();
            var db = new evidenciaContext();
            string Nombre, Cedula, Salario, DiasVacaciones;
            int Cedula1, Salario1, DiasVacaciones1, divi, totalPagar;

            bool cedVal = false;
            bool nomVal = false;
            bool salVal = false;
            bool dvVal = false;

            Marco();
            Console.Clear();
            Console.SetCursorPosition(40, 5); Console.WriteLine("---------------------------------");
            Console.SetCursorPosition(40, 6); Console.WriteLine("........  Ingrese datos  ........");
            Console.SetCursorPosition(40, 7); Console.WriteLine("---------------------------------");


            do
            {
                Marco();
                Console.SetCursorPosition(20, 10); Console.WriteLine("Digite cedula del nuevo empleado: ");
                Console.SetCursorPosition(60, 10); Cedula = Console.ReadLine();
                if (!Validar.Vacio(Cedula))
                    if (Validar.Numero(Cedula))
                        cedVal = true;
            } while (!cedVal);
            Cedula1 = Convert.ToInt32(Cedula);

            do
            {
                Marco();
                Console.SetCursorPosition(20, 11); Console.WriteLine("Digite el nombre del empleado: ");
                Console.SetCursorPosition(60, 11); Nombre = Console.ReadLine();
                if (!Validar.Vacio(Nombre))
                    if (Validar.TipoTexto(Nombre))
                        nomVal = true;
            } while (!nomVal);

            do
            {
                Marco();
                Console.SetCursorPosition(20, 12); Console.WriteLine("Digite sueldo del empleado: ");
                Console.SetCursorPosition(60, 12); Salario = Console.ReadLine();
                if (!Validar.Vacio(Salario))
                    if (Validar.Numero(Salario))
                        salVal = true;
            } while (!salVal);
            Salario1 = Convert.ToInt32(Salario);

            do
            {
                Marco();
                Console.SetCursorPosition(20, 13); Console.WriteLine("Digite dias de vacaciones del empleado : ");
                Console.SetCursorPosition(60, 13); DiasVacaciones = Console.ReadLine();
                if (!Validar.Vacio(DiasVacaciones))
                    if (Validar.Numero(DiasVacaciones))
                        dvVal = true;
            } while (!dvVal);
            DiasVacaciones1 = Convert.ToInt32(DiasVacaciones);

            divi = Salario1 / 30;
            totalPagar = divi * DiasVacaciones1;


            Empleados AUX = new Empleados();
            AUX.Cedula = (uint)Convert.ToInt32(Cedula);
            AUX.Nombre = Nombre;
            AUX.Salario = (int)Convert.ToInt32(Salario);
            AUX.DiasVacaciones = (int)Convert.ToInt32(DiasVacaciones);
            AUX.VacacionesPagar = (int)Convert.ToInt32(totalPagar);

            db.Empleados.Add(AUX);
            empleados.Add(AUX);
            db.SaveChanges();

            Console.Clear();
        }

        static void BuscarEmpleado()
        {
            Console.Clear();
            var db = new evidenciaContext();
            var empleados = db.Empleados.ToList();
            string cedula;
            bool cedVal = false;
            
            do
            { 
                Console.Clear();
                Marco();
                Console.SetCursorPosition(35, 5); Console.WriteLine("BUSCAR UN EMPLEADO...");
                Console.SetCursorPosition(35, 10); Console.WriteLine("Digite la cedula a buscar: ");
                Console.SetCursorPosition(40, 15); cedula = (Console.ReadLine());
                if (!Validar.Vacio(cedula))
                    if (Validar.Numero(cedula))
                        cedVal = true;
            } while (!cedVal);

            if (Existe(Convert.ToInt32(cedula)))
            {
                Marco();
                Console.SetCursorPosition(38, 5); Console.WriteLine("Empleado encontrado...");

                Empleados myEmpleado = ObtenerDatos(Convert.ToInt32(cedula));

                Console.SetCursorPosition(38, 8); Console.WriteLine("Cedula: " + myEmpleado.Cedula);
                Console.SetCursorPosition(38, 9); Console.WriteLine("Nombre: " + myEmpleado.Nombre);
                Console.SetCursorPosition(38, 10); Console.WriteLine("Salario: " + myEmpleado.Salario);
                Console.SetCursorPosition(38, 11); Console.WriteLine("Dias de vacaciones:" + myEmpleado.DiasVacaciones);
                Console.SetCursorPosition(38, 12); Console.WriteLine("Vacaciones a Pagar: " + myEmpleado.VacacionesPagar);

                Console.SetCursorPosition(30, 20); Console.WriteLine("Presione una tecla para continnuar");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("El empleado no existe... ");
                Console.ReadKey();
            }
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        
        static void ListarEmpleados()
        {
            Console.Clear();
            Marco();
            var db = new evidenciaContext();
            var empleados = db.Empleados.ToList();
            int y = 10;
            Console.SetCursorPosition(2, 5); Console.WriteLine("...Listar Empleados...");
            
            Console.SetCursorPosition(4, y); Console.WriteLine("Cedula: ");
            Console.SetCursorPosition(25, y); Console.WriteLine("Nombre: ");
            Console.SetCursorPosition(50, y); Console.WriteLine("Salarios: ");
            Console.SetCursorPosition(65, y); Console.WriteLine("Dias: ");
            Console.SetCursorPosition(80, y); Console.WriteLine("Total pago vacaciones: ");

            foreach (var myEmpleado in empleados)
                
            {
                y++;
                Marco();
                Console.SetCursorPosition(4, y); Console.WriteLine(myEmpleado.Cedula);
                Console.SetCursorPosition(25, y); Console.WriteLine(myEmpleado.Nombre);
                Console.SetCursorPosition(50, y); Console.WriteLine(myEmpleado.Salario);
                Console.SetCursorPosition(65, y); Console.WriteLine(myEmpleado.DiasVacaciones);
                Console.SetCursorPosition(80, y); Console.WriteLine(myEmpleado.VacacionesPagar);

            }

            Console.WriteLine("\n");
           
            Console.SetCursorPosition(10, 20); Console.WriteLine("Presione una tecla para volver al menu principal");
            Console.ReadKey();
            Console.Clear();


        }

        static bool Existe(int cedula)
        {
            Console.Clear();
            var db = new evidenciaContext();
            var empleados = db.Empleados.ToList();
            bool aux = false;
            foreach (var myEmpleado in empleados)
            {
                if (myEmpleado.Cedula == cedula)
                    aux = true;
            }
            return aux;
        }

        static Empleados ObtenerDatos(int cedula)
        {
            var db = new evidenciaContext();
            var empleados = db.Empleados.ToList();
            foreach (Empleados ObjetoEmpleado in empleados)
            {
                if (ObjetoEmpleado.Cedula == cedula)
                    return ObjetoEmpleado;
            }
            return null;
            
        }

        static void Marco()
        {
            for (int i = 1; i <= 110; i++)
            {
                Console.SetCursorPosition(i, 1); Console.Write("█");
                Console.SetCursorPosition(i, 25); Console.Write("█");
            }

            for (int i = 1; i <= 25; i++)
            {
                Console.SetCursorPosition(1, i); Console.Write("█");
                Console.SetCursorPosition(110, i); Console.Write("█");
            }

            Console.SetCursorPosition(1, 1); Console.Write("╔═");
            Console.SetCursorPosition(109, 1); Console.Write("═╗");
            Console.SetCursorPosition(1, 25); Console.Write("╚═");
            Console.SetCursorPosition(109, 25); Console.Write("═╝");
        }



    }
}
