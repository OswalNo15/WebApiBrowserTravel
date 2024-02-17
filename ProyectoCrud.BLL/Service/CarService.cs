using Microsoft.IdentityModel.Tokens;
using ProyectoCrud.DAL.Repositories;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Service
{
    public class CarService : ICarService
    {
        private readonly IGenericRepository<Car> _carRepo;
        public CarService(IGenericRepository<Car> carRepo)
        {
            _carRepo = carRepo;
        }
        public async Task<bool> Delete(int id)
        {
            return await _carRepo.Delete(id);
        }

        public async Task<Car> Get(int id)
        {
            return await _carRepo.Get(id);
        }

        public async Task<IQueryable<Car>> GetAll()
        {
            return await _carRepo.GetAll();
        }

        public async Task<IQueryable<Car>> GetForColor(string color)
        {
            IQueryable<Car> queryCarSQL = await _carRepo.GetAll();
            IQueryable<Car> car = queryCarSQL.Where(c => c.Color == color);
            if (car == null) throw new ArgumentNullException("Car not found");
            return car;
        }

        public async Task<IQueryable<Car>> GetForModel(int? year)
        {
            IQueryable<Car> queryCarSQL = await _carRepo.GetAll();
            IQueryable<Car> car = queryCarSQL.Where(c => c.Model == year);
            if (car == null) throw new ArgumentNullException("Car not found");
            return car;
        }
        public async Task<IQueryable<Car>> GetForLocalityCollected(string LocalityCollected)
        {
            IQueryable<Car> queryCarSQL = await _carRepo.GetAll();
            IQueryable<Car> car = queryCarSQL.Where(c => c.Locality_collected.ToLower().Contains(LocalityCollected));
            if (car == null) throw new ArgumentNullException("Car not found");
            return car;
        }
        
        public async Task<IQueryable<Car>> GetForReturnLocation(string ReturnLocation)
        {
            IQueryable<Car> queryCarSQL = await _carRepo.GetAll();
            IQueryable<Car> car = queryCarSQL.Where(c => c.Return_location.ToLower().Contains(ReturnLocation));
            if (car == null) throw new ArgumentNullException("Car not found");
            return car;
        }

        public async Task<bool> Insert(Car model)
        {
            return await _carRepo.Insert(model);
        }

        public async Task<bool> Update(Car model)
        {
            return await _carRepo.Update(model);
        }
    }
}
