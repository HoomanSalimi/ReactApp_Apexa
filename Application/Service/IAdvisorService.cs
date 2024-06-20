using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public interface IAdvisorService
    {
        Task<int> DeleteAdvisor(int id);
        Task<List<Advisor>> GetAllAdvisor();
        Task<Advisor> GetAdvisorById(int id);
        Task<Advisor> CreateAdvisor(Advisor advisor);
        Task<int> UpdateAdvisor(int id, Advisor advisor);
    }
}
