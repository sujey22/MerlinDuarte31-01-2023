using MerlinDuarte23_03_23.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerlinDuarte23_03_23.DAO
{
    public class CrudProductos
    { 
        public void AgregarProductos(Producto ParametroProducto)
        {
            using(AlmacenContext db = new AlmacenContext()) 
            {
                Producto Prod = new Producto();
                
                Prod.Nombre = ParametroProducto.Nombre;
                Prod.Descripción = ParametroProducto.Descripción;
                Prod.Precio = ParametroProducto.Precio;
                Prod.Stock = ParametroProducto.Stock;
                db.Add(Prod);
                db.SaveChanges();
            }
        }

        public Producto ProdIndividual(int id)
        {
            using (AlmacenContext db = new AlmacenContext())
            {
                var buscar = db.Productos.FirstOrDefault(x => x.Id == id);
                return buscar;
            }
        }

        public void ActualizarProduct(Producto ParametroProduct, int Lector)
        {
            using (AlmacenContext db = new AlmacenContext())
            {
                var buscar = ProdIndividual(ParametroProduct.Id);

                if (buscar == null)
                {
                    Console.WriteLine("El Id no existe");
                }
                else
                {
                    switch(Lector)
                    {
                        case 1:
                            buscar.Nombre = ParametroProduct.Nombre;
                            break;

                        case 2:
                            buscar.Descripción = ParametroProduct.Descripción;
                            break;

                        case 3:
                            buscar.Precio = ParametroProduct.Precio;
                            break;

                        case 4:
                            buscar.Stock = ParametroProduct.Stock;
                            break;
                    }
                    db.Update(buscar);
                    db.SaveChanges();
                }
            }

        }

        public String EliminarProduct(int id)
        {
            using (AlmacenContext db = new AlmacenContext())
            {
                var buscar = ProdIndividual(id);

                if (buscar == null)
                {
                    return "El producto no existe";
                }
                else
                {
                    db.Productos.Remove(buscar);
                    db.SaveChanges();
                    return "El producto se elimino";
                }
            }
        }

        public List<Producto> ListarProduct()
        {
            using (AlmacenContext db = new AlmacenContext())
            {
                return db.Productos.ToList();
            }
        }

    }
}
