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
        private readonly ILogger<ConversionService> _logger;

        public ConversionService(UnitConverterDbContext context, IMapper mapper, ILogger<ConversionService>logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
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
            var conversion = GetConversion(conversionId);

            var conversionDto = _mapper.Map<ConversionDto>(conversion);

            return conversionDto;
        }

        public IEnumerable<ConversionDto> GetAll()
        {
           var conversions = GetAllConversions();

            var conversionDtos = _mapper.Map<List<ConversionDto>>(conversions);
            return conversionDtos;
        }

        public void RemoveAll()
        {
            var conversions = GetAllConversions();

            _context.Conversions.RemoveRange(conversions);
            _context.SaveChanges();

        }


        public void DeleteConversion(int id)
        {
            _logger.LogError($"Conversion with id: {id} DELETE action invoked");
            var conversion = GetConversion(id);
        }
        private IEnumerable<Conversion> GetAllConversions()
        {
            var conversions = _context.Conversions.Include(c => c.OriginalUnit).Include(c => c.TargetUnit).ToList();
            
            if (conversions is null)
            {
                throw new NotFoundException("Conversions not found");
            }

            return conversions;
        }

        private Conversion GetConversion(int conversionId)
        {
            var conversion = _context.Conversions
                                .Include(c => c.OriginalUnit)
                                .Include(c => c.TargetUnit)
                                .FirstOrDefault(c => c.Id == conversionId);


            //.Include(c => c.OriginalUnitId).ThenInclude(c => c.).FirstOrDefault(c => c.Id == conversionId);
            if (conversion is null)
            {
                throw new NotFoundException("Conversion not found");
            }

            return conversion;
        }
    }
}
