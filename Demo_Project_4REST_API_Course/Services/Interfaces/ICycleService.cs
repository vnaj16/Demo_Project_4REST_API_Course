using Demo_Project_4REST_API_Course.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo_Project_4REST_API_Course.Services.Interfaces
{
    public interface ICycleService
    {
        Task<IEnumerable<Cycle>> GetCyclesAsync();
        Task<Cycle> GetCycleAsync(int id);
    }
}
