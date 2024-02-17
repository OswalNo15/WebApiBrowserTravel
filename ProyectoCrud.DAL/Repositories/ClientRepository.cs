using ProyectoCrud.DAL.BD_Context;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL.Repositories
{
    public class ClientRepository : IGenericRepository<Client>
    {
        private readonly BdMilesCarRentalContext _context;
        //constructor
        public ClientRepository(BdMilesCarRentalContext context)
        {
            _context = context;
        }

        public async  Task<bool> Delete(int id)
        {
            try
            {
                Client model = _context.Clients.First(c => c.IdClient == id.ToString());
                _context.Clients.Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async  Task<Client> Get(int id)
        {
            return await _context.Clients.FindAsync(id).ConfigureAwait(false);
        }

        public async  Task<IQueryable<Client>> GetAll()
        {
            IQueryable<Client> queryContratoSQL = _context.Clients;
            return queryContratoSQL;
        }

        public async  Task<bool> Insert(Client model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async  Task<bool> Update(Client model)
        {
            _context.Clients.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
