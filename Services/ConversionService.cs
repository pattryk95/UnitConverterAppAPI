using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UnitConverterAppAPI.Authorization;
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
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        public ConversionService(
                                UnitConverterDbContext context, 
                                IMapper mapper, 
                                ILogger<ConversionService> logger, 
                                IAuthorizationService authorizationService,
                                IUserContextService userContextService)
        {
            _userContextService = userContextService;
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
        }
        public int Create(CreateConversionDto dto)
        {
            var result = CountResult(dto.ConvertedValue, dto.OriginalUnitId, dto.TargetUnitId);
            dto.ConversionResult = result;
            var conversionEntity = _mapper.Map<Conversion>(dto);
            conversionEntity.CreatedById = _userContextService.GetUserId;

            _context.Conversions.Add(conversionEntity);
            _context.SaveChanges();

            return conversionEntity.Id;
        }

        private decimal CountResult(decimal convertedValue, int originalUnitId, int targetUnitId)
        {
            var originalUnit = _context.Units.FirstOrDefault(u => u.Id == originalUnitId);
            var targetUnit = _context.Units.FirstOrDefault(u => u.Id == targetUnitId);
            
            if (originalUnit == null && targetUnit == null)
            {
                throw new InvalidOperationException();
            }

            return (convertedValue * originalUnit.Factor) / targetUnit.Factor;
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

           var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, conversion,
               new ResourceOperationRequirement(ResourceOperation.Delete)).Result;
            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }
            _context.Conversions.Remove(conversion);
            _context.SaveChanges();
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
