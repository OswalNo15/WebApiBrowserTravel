using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientService _clientService;
       
        public ClientService(IClientService clientService)
        {
            _clientService = clientService;
        }
        public async Task<bool> Delete(int id)
        {
            return await _clientService.Delete(id);
        }

        public async Task<Client> Get(int id)
        {
            return await _clientService.Get(id);
        }

        public async Task<IQueryable<Client>> GetAll()
        {
            return await _clientService.GetAll();
        }

        public async Task<Client> GetForName(string Name)
        {
            IQueryable<Client> queryClientSQL = await _clientService.GetAll();
            Client c = queryClientSQL.FirstOrDefault(x => x.FirstNameClient.Equals(Name));
            if (c == null) throw new ArgumentNullException("Client not found");
            return c;
        }
        public async Task<Client> GetForLastName(string LastName)
        {
            IQueryable<Client> queryClientSQL = await _clientService.GetAll();
            Client c = queryClientSQL.FirstOrDefault(x => x.FirstSurnameClient.Equals(LastName));
            if (c == null) throw new ArgumentNullException("Client not found");
            return c;
        }

        public async Task<bool> Insert(Client model)
        {
            return await _clientService.Insert(model);
        }

        public async Task<bool> Update(Client model)
        {
            return await _clientService.Update(model);
        }
    }
}
