using Demo_Project_4REST_API_Course.Models;
using System.Threading.Tasks;

namespace Demo_Project_4REST_API_Course.Services.Interfaces
{
    public interface ICycleService
    {
        Task<Cycle> GetCycleAsync(int id);
    }
}
