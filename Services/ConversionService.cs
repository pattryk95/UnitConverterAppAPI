using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UnitConverterAppAPI.Entities;
using UnitConverterAppAPI.Exceptions;
using UnitConverterAppAPI.Models;

namespace UnitConverterAppAPI.Services
{
    public class ConversionService : IConversionService
    {
        private readonly UnitConverterDbContext _context;
        private readonly IMapper _mapper;

        public ConversionService(UnitConverterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(CreateConversionDto dto)
        {
            var conversionEntity = _mapper.Map<Conversion>(dto);

            _context.Conversions.Add(conversionEntity);
            _context.SaveChanges();

            return conversionEntity.Id;
        }

        public ConversionDto GetById(int conversionId)
        {
            var conversion = _context.Conversions
                                .Include(c => c.OriginalUnit)
                                .Include(c=>c.TargetUnit)
                                .FirstOrDefault(c=>c.Id == conversionId);
                
                
                //.Include(c => c.OriginalUnitId).ThenInclude(c => c.).FirstOrDefault(c => c.Id == conversionId);
            if (conversion is null)
            {
                throw new NotFoundException("Conversion not found");
            }

            var conversionDto = _mapper.Map<ConversionDto>(conversion);

            return conversionDto;
        }

        public IEnumerable<ConversionDto> GetAll()
        {
            var conversions = _context.Conversions.Include(c=>c.OriginalUnit).Include(c=>c.TargetUnit).ToList();

            var conversionDtos = _mapper.Map<List<ConversionDto>>(conversions);
            return conversionDtos;
        }
    }
}
