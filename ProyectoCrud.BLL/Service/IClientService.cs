using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Service
{
    public interface IClientService
    {
        Task<bool> Insert(Client model);
        Task<bool> Update(Client model);
        Task<bool> Delete(int id);
        Task<Client> Get(int id);
        Task<IQueryable<Client>> GetAll();
        Task<Client> GetForName(string Name);
        Task<Client> GetForLastName(string LastName);
    }
}
