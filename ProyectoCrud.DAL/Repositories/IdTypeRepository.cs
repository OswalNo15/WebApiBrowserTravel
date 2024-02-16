using Microsoft.EntityFrameworkCore;
using ProyectoCrud.DAL.BD_Context;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL.Repositories
{
    public class IdTypeRepository : IGenericRepository<IdType>
    {
        private readonly BdMilesCarRentalContext _context;
        //constructor
        public IdTypeRepository(BdMilesCarRentalContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                User model = _context.Users.First(c => c.IdUser == id.ToString());
                _context.Users.Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
       
        }

        public async Task<IdType> Get(int id)
        {
            return await _context.IdTypes.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<IQueryable<IdType>> GetAll()
        {
            IQueryable<IdType> queryContratoSQL = _context.IdTypes;
            return queryContratoSQL;
        }

        public async Task<bool> Insert(IdType model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(IdType model)
        {
            _context.IdTypes.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
