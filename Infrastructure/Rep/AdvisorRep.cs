using Domain.Model;
using Domain.Rep;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Rep
{
    public class AdvisorRep : IAdvisorRep
    {
        private readonly ApplicationDbContext _db;
        public AdvisorRep(ApplicationDbContext db)
        {
                _db = db;
        }

        public async Task<Advisor> CreateAdvisor(Advisor advisor)
        {
            try
            {
                var check = await _db.Advisors.Where(x => x.SIN == advisor.SIN).FirstOrDefaultAsync();
                if (check == null)
                {
                    var Names = new List<string> { "Green", "Yellow", "Red" };

                    Random rand = new Random();
                    int index = rand.Next(Names.Count);
                    var Result = Names[index];
                    if (Result == "Red" || Result == "Yellow")
                    {
                        index = rand.Next(Names.Count);
                        Result = Names[index];
                    }
                    if (Result == "Red" || Result == "Yellow")
                    {
                        index = rand.Next(Names.Count);
                        Result = Names[index];
                    }
                    advisor.HealthStatus = Result;

                    await _db.Advisors.AddAsync(advisor);
                    await _db.SaveChangesAsync();
                    return advisor;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<int> DeleteAdvisor(int id)
        {
            try
            {
                var x = await _db.Advisors.Where(x => x.AdvisorId == id).SingleAsync();
                _db.Remove(x);
                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Advisor> GetAdvisorById(int id)
        {
            try
            {
                return await _db.Advisors.Where(x => x.AdvisorId == id).SingleAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Advisor>> GetAllAdvisor()
        {
            try
            {
                return await _db.Advisors.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateAdvisor(int id, Advisor advisor)
        {
            try
            {
                var x = _db.Advisors.Where(x =>x.SIN == advisor.SIN && x.AdvisorId!=advisor.AdvisorId).FirstOrDefault();
                if (x!=null)
                {
                    return 0;
                }
                return await _db.Advisors.Where(model => model.AdvisorId == id)
                 .ExecuteUpdateAsync(setters => setters
                   .SetProperty(m => m.Name, advisor.Name)
                   .SetProperty(m => m.SIN, advisor.SIN)
                   .SetProperty(m => m.Address, advisor.Address)
                   .SetProperty(m => m.Phone, advisor.Phone));
                
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
