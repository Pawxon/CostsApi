using Microsoft.EntityFrameworkCore;
using CostsApi.Data;
using CostsApi.IServices;
using CostsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostsApi.Services
{
    public class CostsService : ICostsService

    {
        ApplicationDbContext dbContext;
        public CostsService(ApplicationDbContext _db)
        {
            dbContext = _db;
        }

        public async Task<string> AddCosts(Costs costs)
        {
            dbContext.Costs.Add(costs);
            await dbContext.SaveChangesAsync();

            return await Task.FromResult("");

        }

        public async Task<string> DeleteCosts(int id)
        {

            var car = dbContext.Costs.FirstOrDefault(x => x.idCosts == id);
            dbContext.Entry(car).State = EntityState.Deleted;

            dbContext.SaveChanges();
            return await Task.FromResult("");
        }

        public async Task<Costs> GetCostsByIdAsync(int id)
        {
            var costs = await dbContext.Costs.FindAsync(id);

            if (costs == null)
            {

            }

            return costs;
        }

        public async Task<IEnumerable<Costs>> GetCosts()
        {
            return await dbContext.Costs.ToListAsync();
        }

        public Costs UpdateCosts(Costs costs)
        {
            dbContext.Entry(costs).State = EntityState.Modified;
            dbContext.SaveChanges();
            return costs;
        }



    }
}