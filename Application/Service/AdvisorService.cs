using Domain.Model;
using Domain.Rep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class AdvisorService : IAdvisorService
    {

        private readonly IAdvisorRep _iAdvisorRep;
        public AdvisorService(IAdvisorRep iAdvisorRep)
        {
            _iAdvisorRep = iAdvisorRep; 
        }

        public async Task<Advisor> CreateAdvisor(Advisor advisor)
        {
            return await _iAdvisorRep.CreateAdvisor(advisor);
        }

        public async Task<int> DeleteAdvisor(int id)
        {
            return await _iAdvisorRep.DeleteAdvisor(id);
        }

        public async Task<Advisor> GetAdvisorById(int id)
        {
            return await _iAdvisorRep.GetAdvisorById(id);
        }

        public async Task<List<Advisor>> GetAllAdvisor()
        {
            return await _iAdvisorRep.GetAllAdvisor();
        }

        public async Task<int> UpdateAdvisor(int id, Advisor advisor)
        {
            return await _iAdvisorRep.UpdateAdvisor(id, advisor);
        }
    }
}
