using AutoMapper;
using Demo_Project_4REST_API_Course.Models;
using Demo_Project_4REST_API_Course.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Demo_Project_4REST_API_Course.Services
{
    public class CycleService : ICycleService
    {
        private readonly ControlNotasDbContext _controlNotasDbContext;
        private readonly IMapper mapper;

        public CycleService(ControlNotasDbContext controlNotasDbContext
            , IMapper mapper)
        {
            _controlNotasDbContext = controlNotasDbContext;
            this.mapper = mapper;
        }

        public async Task<Cycle> GetCycleAsync(int id)
        {
            var entity = await _controlNotasDbContext.Cycles
            .SingleOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return mapper.Map<Cycle>(entity);
        }
    }
}
