﻿using ProyectoCrud.DAL.Repositories;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Service
{
    public class PreferenceService : IPreferenceService
    {
        private readonly IGenericRepository<Preference> _PreferenceRepo;
        public PreferenceService(IGenericRepository<Preference> PreferenceRepo)
        {
            _PreferenceRepo = PreferenceRepo;
        }

        public async Task<bool> Delete(int id)
        {
            return await _PreferenceRepo.Delete(id);
        }

        public Task<Preference> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Preference>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(Preference model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Preference model)
        {
            throw new NotImplementedException();
        }
    }
}
