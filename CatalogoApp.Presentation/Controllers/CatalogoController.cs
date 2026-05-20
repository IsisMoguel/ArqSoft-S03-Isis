using CatalogoApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;



namespace Catalogo.Controllers
{
    public class CatalogoController : Controller
    {
        /* CatalogoController
         * ==================
         * 
         * Controlador encargado de gestionar el flujo de datos
         * del catálogo de videojuegos.
         * 
         * Su función es recibir las peticiones del usuario,
         * consultar la lista de items y devolver la vista
         * correspondiente.
         * * * * */



        private static List<Item> _items = new()
        {
            new Item {
                Id = 1,
                Titulo = "Coraline y la puerta secreta",
                Genero = "Terror",
                Ano = 2009,
                Plataforma = "Claro Video, DGO",
                Descripcion = "Una niña descubre una puerta secreta en su nueva casa y entra a una realidad alterna"
            },
            new Item
            {
                Id = 2,
                Titulo = "Isla de perros",
                Genero = "Fantasia",
                Ano = 2018,
                Plataforma = "Disney+",
                Descripcion = "El alcade de una ciudad japonesa decreta que todos los perros deben quedar confinados en una isla debido a una epidemia de gripe canina"
            },
            new Item
            {
                Id = 3,
                Titulo = "El fantastico sr. zorro",
                Genero = "Comedia",
                Ano = 2009,
                Plataforma = "Disney+",
                Descripcion = "Tres malvados granjeros le declaran la guerra a un zorro y este anima a sus vecinos animales a defenderse"
            }
        };
        public IActionResult Index(string? genero)
        {
            var resultado = string.IsNullOrEmpty(genero)
                ? _items
                : _items.Where(i => i.Genero == genero).ToList();



            ViewBag.Generos = _items.Select(i => i.Genero).Distinct().ToList();
            ViewBag.GeneroActual = genero;

            return View(resultado);
        }



        public IActionResult Detalle(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            return item == null ? NotFound() : View(item);
        }



        public IActionResult Agregar()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Agregar(Item item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
            return RedirectToAction("Index");
        }
    }
}





