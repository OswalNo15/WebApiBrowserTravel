using ProyectoCrud.DAL.BD_Context;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL.Repositories
{
    public class RoleRepository : IGenericRepository<Role>
    {
        private readonly BdMilesCarRentalContext _context;
        //constructor
        public RoleRepository(BdMilesCarRentalContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            Role model = _context.Roles.First(c => c.IdRole == id);
            _context.Roles.Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Role> Get(int id)
        {
            return await _context.Roles.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<IQueryable<Role>> GetAll()
        {
            IQueryable<Role> queryContratoSQL = _context.Roles;
            return queryContratoSQL;
        }

        public async Task<bool> Insert(Role model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Role model)
        {
            _context.Roles.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
