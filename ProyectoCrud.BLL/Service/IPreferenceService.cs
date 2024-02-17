using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Service
{
    public interface IPreferenceService
    {
        Task<bool> Insert(Preference model);
        Task<bool> Update(Preference model);
        Task<bool> Delete(int id);
        Task<Preference> Get(int id);
        Task<IQueryable<Preference>> GetAll();
    }
}
