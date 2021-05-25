using AppSiteWeb.Data;
using AppSiteWeb.Models;
using AppSiteWeb.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSiteWeb.Services
{
    public class ProdutoService
    {
        private readonly AppSiteWebContext _context;

        public ProdutoService(AppSiteWebContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> FindAllAsync()
        {
            return await _context.Produto.ToListAsync(); 
        }

        //public async Task<List<Vendedor>> FindAllCompletoAsync()
        //{
        //    return await _context.Vendedor.Include(obj => obj.Departamento).ToListAsync(); //Acessar os dados da tabela de vendedores.
        //}

        public async Task InsertAsync(Produto obj) //Inserir um novo Produto
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto> FindByIdAsync(int id)
        {
            return await _context.Produto.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Produto.FindAsync(id);
                _context.Produto.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Produto obj)
        {
            bool hasAny = await _context.Produto.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny) //Tem algum registro
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);

            }
        }
    }
}
