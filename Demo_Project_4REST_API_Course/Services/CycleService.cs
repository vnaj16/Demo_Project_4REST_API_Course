using AutoMapper;
using AutoMapper.QueryableExtensions;
using Demo_Project_4REST_API_Course.Models;
using Demo_Project_4REST_API_Course.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo_Project_4REST_API_Course.Services
{
    public class CycleService : ICycleService
    {
        private readonly ControlNotasDbContext _controlNotasDbContext;
        private readonly IConfigurationProvider _mappingConfiguration;

        public CycleService(ControlNotasDbContext controlNotasDbContext
            , IConfigurationProvider mappingConfiguration)
        {
            _controlNotasDbContext = controlNotasDbContext;
            _mappingConfiguration = mappingConfiguration;
        }

        public async Task<Cycle> GetCycleAsync(int id)
        {
            var entity = await _controlNotasDbContext.Cycles
            .SingleOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            var mapper = _mappingConfiguration.CreateMapper();
            return mapper.Map<Cycle>(entity);
        }

        public async Task<IEnumerable<Cycle>> GetCyclesAsync()
        {
            var query = _controlNotasDbContext.Cycles
                .ProjectTo<Cycle>(_mappingConfiguration);

            return await query.ToArrayAsync();
        }
    }
}
