﻿using F1Management.Core.Models.Abstractions.Repositories;
using F1Management.Core.Models.Abstractions.Repositories.PartRepositories;
using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure.Repositories
{
    public class GearboxRepository : IGenericRepository<Gearbox>, IPartRepository<Gearbox>
    {
        private readonly AppDbContext _dbContext;

        public GearboxRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Gearbox gearbox)
        {
            _dbContext.Gearboxes.Add(gearbox);
            _dbContext.SaveChanges();
        }

        public void Delete(Gearbox gearbox)
        {
            _dbContext.Gearboxes.Remove(gearbox);
            _dbContext.SaveChanges();
        }

        public List<Gearbox> GetAll()
        {
            return _dbContext.Gearboxes.ToList();
        }

        public List<Gearbox> GetByCar(RaceCar raceCar)
        {
            return _dbContext.Gearboxes
                .Where(g => g.RaceCar == raceCar)
                .ToList();
        }

        public Gearbox GetById(Guid id)
        {
            return _dbContext.Gearboxes.FirstOrDefault(g => g.Id == id);
        }

        public void Update(Gearbox gearbox)
        {
            _dbContext.Gearboxes.Update(gearbox);
            _dbContext.SaveChanges();
        }
    }
}