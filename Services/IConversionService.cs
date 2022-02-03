using UnitConverterAppAPI.Models;

namespace UnitConverterAppAPI.Services
{
    public interface IConversionService
    {
        int Create(CreateConversionDto dto);
        ConversionDto GetById(int conversionId);
        public IEnumerable<ConversionDto> GetAll();
        void RemoveAll();
        void DeleteConversion(int id);
    }
}