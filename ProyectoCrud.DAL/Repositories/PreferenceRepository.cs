using ProyectoCrud.DAL.BD_Context;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL.Repositories
{
    public class PreferenceRepository : IGenericRepository<Preference>
    {
        private readonly BdMilesCarRentalContext _context;
        //constructor
        public UserRepository(BdMilesCarRentalContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            Preference model = _context.Preferences.First(c => c.IdPreference == id);
            _context.Preferences.Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Preference> Get(int id)
        {
            return await _context.Preferences.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<IQueryable<Preference>> GetAll()
        {
            IQueryable<Preference> queryContratoSQL = _context.Preferences;
            return queryContratoSQL;
        }

        public async Task<bool> Insert(Preference model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Preference model)
        {
            _context.Preferences.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
