using ProyectoCrud.DAL.BD_Context;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL.Repositories
{
    public class UserRepository : IGenericRepository<User>
    {
        private readonly BdMilesCarRentalContext _context;
        //constructor
        public UserRepository(BdMilesCarRentalContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            User model = _context.Users.First(c => c.IdUser == id.ToString());
            _context.Users.Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<IQueryable<User>> GetAll()
        {
            IQueryable<User> queryContratoSQL = _context.Users;
            return queryContratoSQL;
        }

        public async Task<bool> Insert(User model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(User model)
        {
            _context.Users.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
