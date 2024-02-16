using ProyectoCrud.DAL.BD_Context;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL.Repositories
{
    public  class PreferenceClientRepository : IGenericRepository<PreferenceClient>
    {

        private readonly BdMilesCarRentalContext _context;
        //constructor
        public  PreferenceClientRepository(BdMilesCarRentalContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            PreferenceClient model = _context.PreferenceClients.First(c => c.IdPreferenceType == id);
            _context.PreferenceClients.Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PreferenceClient> Get(int id)
        {
            return await _context.PreferenceClients.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<IQueryable<PreferenceClient>> GetAll()
        {
            IQueryable<PreferenceClient> queryContratoSQL = _context.PreferenceClients;
            return queryContratoSQL;
        }

        public async Task<bool> Insert(PreferenceClient model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(PreferenceClient model)
        {
            _context.PreferenceClients.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
