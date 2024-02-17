using ProyectoCrud.DAL.Repositories;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoCrud.BLL.Service
{
    public class PreferenceClientService : IPreferenceClientService
    {
        private readonly IGenericRepository<PreferenceClient> _PreferenceRepo;

        public PreferenceClientService(IGenericRepository<PreferenceClient> PreferenceRepo) {
            _PreferenceRepo = PreferenceRepo;
        }

        public async Task<bool> Delete(int id)
        {
            return await _PreferenceRepo.Delete(id);
        }

        public async Task<PreferenceClient> Get(int id)
        {
            return await _PreferenceRepo.Get(id);
        }

        public async Task<IQueryable<PreferenceClient>> GetAll()
        {
            return await _PreferenceRepo.GetAll();
        }

        public async Task<bool> Insert(PreferenceClient model)
        {
            return await _PreferenceRepo.Insert(model);

        }

        public async Task<bool> Update(PreferenceClient model)
        {
            return await _PreferenceRepo.Update(model);
        }
    }
}
