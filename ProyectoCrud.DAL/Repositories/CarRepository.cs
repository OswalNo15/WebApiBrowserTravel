using ProyectoCrud.DAL.BD_Context;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL.Repositories
{
    public class CarRepository : IGenericRepository<Car>
    {
        private readonly BdMilesCarRentalContext _context;
        //constructor
        public CarRepository(BdMilesCarRentalContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            Car model = _context.Cars.First(c => c.IdCar == id);
            _context.Cars.Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Car> Get(int id)
        {
            return await _context.Cars.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<IQueryable<Car>> GetAll()
        {
            IQueryable<Car> queryContratoSQL = _context.Cars;
            return queryContratoSQL;
        }

        public async Task<bool> Insert(Car model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Car model)
        {
            _context.Cars.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
