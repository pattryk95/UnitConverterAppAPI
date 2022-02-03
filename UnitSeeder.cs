using UnitConverterAppAPI.Entities;

namespace UnitConverterAppAPI
{
    public class UnitSeeder
    {
        private readonly UnitConverterDbContext _dbContext;

        public UnitSeeder(UnitConverterDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Units.Any())
                {
                    var units = GetUnits();
                    _dbContext.Units.AddRange(units);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role() { Name = "User"},
                new Role() { Name = "Admin"}
            };

            return roles;
        }

        private IEnumerable<Unit> GetUnits()
        {
            var units = new List<Unit>()
            {
                new Unit() { Name = "millimeters", Factor = 0.001M},
                new Unit() { Name = "decimeter", Factor = 0.1M},
                new Unit() { Name = "centimeter", Factor = 0.01M},
                new Unit() { Name = "meter", Factor = 1M},
                new Unit() { Name = "dekameter", Factor = 10M},
                new Unit() { Name = "hectometer", Factor = 100M},
                new Unit() { Name = "kilometer ", Factor = 1000M}
            };

            return units;
        }
    }
}
