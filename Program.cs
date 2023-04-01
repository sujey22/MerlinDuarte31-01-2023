using MerlinDuarte23_03_23.DAO;
using MerlinDuarte23_03_23.Models;
using System.Xml;

CrudProductos CrudProductos = new CrudProductos();
Producto Prod = new Producto();

bool Continuar = true;

while (Continuar)
{

    Console.WriteLine(@"Menú
Pulse el numero 1 Para Insertar un nuevo Producto:
Pulse el numero 2 Actualizar un Producto 
Pulse el numero 3 Eliminar un Producto
Pulse el numero 4 Para mostrar el listado de Productos
Pulse el numero 5 Para Salir:");

    var Menú = Convert.ToInt32(Console.ReadLine());

    switch (Menú)
    {
        case 1:
            bool bucle = true;
            while (bucle == true)
            {
                Console.WriteLine("Ingrese el nombre del producto: ");
                Prod.Nombre = Console.ReadLine();
                Console.WriteLine("\nIngrese una descripción del producto: ");
                Prod.Descripción = Console.ReadLine();
                Console.WriteLine("\nIngrese el precio del producto: $");
                Prod.Precio = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("\nIngrese la cantidad de productos existentes");
                Prod.Stock = Convert.ToInt32(Console.ReadLine());

                CrudProductos.AgregarProductos(Prod);


                Console.Write(@"
El Producto se ingreso correctamente

Pulsa 1 para seguir insertando Productos
Pulsa 2 para salir
: ");

                var Menú2 = Convert.ToInt32(Console.ReadLine());

                switch (Menú2)
                {
                    case 1:
                        bucle = true;
                        break;

                    case 2:
                        bucle = false;
                        break;

                    default:
                        Console.Write("Ingrese una opción del menú");
                        break;
                }
            }
            break;
        case 2:
            Console.WriteLine("Actulizar Productos");
            Console.WriteLine("Ingrese el Id del producto a actualzar: ");

            var BuscarProdIndividualU = CrudProductos.ProdIndividual(Convert.ToInt32(Console.ReadLine()));

            if (BuscarProdIndividualU == null)
            {
                Console.WriteLine("El producto no existe");
            }
            else
            {
                Console.WriteLine($"\nId: {BuscarProdIndividualU.Id}, Nombre: {BuscarProdIndividualU.Nombre}, Descripción: {BuscarProdIndividualU.Descripción}, Precio: {BuscarProdIndividualU.Precio}, Stock: {BuscarProdIndividualU.Stock}");
                Console.WriteLine(@"
Ingrese el numero 1 para Actualizar el Nombre del Producto
Ingrese el numero 2 para Actualizar la Descripcción
Ingrese el numero 3 para Actualizar la Precio
Ingrese el numero 4 para Actualizar la Stock: ");

                var Lector = Convert.ToInt32(Console.ReadLine());

                switch (Lector)
                {
                    case 1:
                        Console.WriteLine("Ingrese el Nombre del Producto: ");
                        BuscarProdIndividualU.Nombre = Console.ReadLine();
                        break;

                    case 2:
                        Console.WriteLine("Ingrese la Descripción: ");
                        BuscarProdIndividualU.Descripción = Console.ReadLine();
                        break;

                    case 3:
                        Console.WriteLine("Ingrese el Precio: ");
                        BuscarProdIndividualU.Precio = Convert.ToInt32(Console.ReadLine());
                        break;

                    case 4:
                        Console.WriteLine("Ingrese el Stock: ");
                        BuscarProdIndividualU.Stock = Convert.ToInt32(Console.ReadLine());
                        break;


                    default:
                        Console.WriteLine("No se ncuentra disponible esta opción en el menú");
                        break;

                }

                CrudProductos.ActualizarProduct(BuscarProdIndividualU, Lector);
                Console.WriteLine("Actualización completa");
            }
            break;


        case 3:
            Console.WriteLine("\nIngrese el Id del Producto que desea Eliminar: ");

            var ProdIndividualD = CrudProductos.ProdIndividual(Convert.ToInt32(Console.ReadLine()));

            if (ProdIndividualD == null)
            {
                Console.WriteLine("Este producto no existe");
            }
            else
            {
                Console.WriteLine("Eliminar Producto");
                Console.WriteLine($"\nId: {ProdIndividualD.Id}, Nombre: {ProdIndividualD.Nombre}, Descripción: {ProdIndividualD.Descripción}, Precio: {ProdIndividualD.Precio}, Stock: {ProdIndividualD.Stock}");

                Console.WriteLine("El producto encontrado es el correcto ingrese el numero 1: ");
                var Lector = Convert.ToInt32(Console.ReadLine());

                if (Lector == 1)
                {
                    var Id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(CrudProductos.EliminarProduct(Id));
                }
                else
                {
                    Console.WriteLine("Inicia nuevamente");
                }
            }
            break;

        case 4:
            Console.WriteLine("Lista de Productos");

            var ListaProductos = CrudProductos.ListarProduct();

            foreach (var i in ListaProductos)
            {
                Console.WriteLine($"{i.Id}, {i.Nombre}, {i.Descripción}, {i.Precio}, {i.Stock}");
            }
            break;

        case 5:
            Console.WriteLine("Gracias por utilizar nuestro programa");
            Continuar = false;
            break;

        default:
            Console.WriteLine("La opción no se encuentra disponible");
            break;

    }

    Console.WriteLine(@"Desea Continuar
Ingrese Si para continuar utilizando
Ingrese No  para poder Salir
: ");
    var cont = Console.ReadLine();

    if(cont.Equals("No"))
    {
        Continuar = false;
    }
    else if (cont.Equals("Si"))
    {
        Continuar = true;
    }
}

Console.WriteLine("Gracias por Usar el programa");