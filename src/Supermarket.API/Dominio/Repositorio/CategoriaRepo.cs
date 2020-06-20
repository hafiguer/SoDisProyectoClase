using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.Api.Dominio.Modelos;
using Supermarket.API.Dominio.Persistencia;


namespace Supermarket.API.Dominio.Repositorios
{
    public class CategoriaRepo : ICategoriaRepo
    {
         
        private readonly SupermarketApiContext db;
        public CategoriaRepo(SupermarketApiContext apiContex)
        {
            db = apiContex;
        }

        /// <summary>
        /// Secuencial sincrona
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Categoria> GetCategorias()
        {
            IEnumerable<Categoria> lista = db.categorias.ToList();
            return lista;
        }

        /// <summary>
        /// Busqueda de Categoria por ID
        /// </summary>
        /// <returns></returns>
        public async Task<Categoria> FindCategoriaById(int id)
        {
            Categoria resultado = await db.categorias.FindAsync(id);
            return resultado;
        }

        /// <summary>
        /// Secuencial asincrona
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            IEnumerable<Categoria> lista = await db.categorias.ToListAsync();
            return lista;
        }

        public  void crearCategoria(Categoria categoria)
        {
             db.categorias.AddAsync(categoria);
        }

        public void editarCategoria(int id, Categoria categoria)
        {
            db.Entry(categoria).State = EntityState.Modified;
            db.categorias.Update(categoria);
        }

        public void eliminarCategoria(Categoria categoria)
        {
            db.categorias.Remove(categoria);
        }

        public async Task<Categoria> guardarCategoria(Categoria categoria)
        {
            await db.SaveChangesAsync();
            return categoria;
        }

        
    }

}