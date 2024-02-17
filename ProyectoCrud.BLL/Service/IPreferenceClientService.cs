using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Service
{
    public interface IPreferenceClientService
    {
        Task<bool> Insert(PreferenceClient model);
        Task<bool> Update(PreferenceClient model);
        Task<bool> Delete(int id);
        Task<PreferenceClient> Get(int id);
        Task<IQueryable<PreferenceClient>> GetAll();
    }
}
