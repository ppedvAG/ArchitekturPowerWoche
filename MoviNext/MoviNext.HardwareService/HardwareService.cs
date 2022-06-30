using MoviNext.Model;
using MoviNext.Model.Contracts;

namespace MoviNext.HardwareService
{
    public class HardwareService
    {
        public IRepository Repository { get; }

        public HardwareService(IRepository repository)
        {
            Repository = repository;
        }

        public Umrichter GetUmrichterWithMostLeistung()
        {
            return Repository.Query<Umrichter>()
                             .OrderByDescending(x => x.Leistung)
                             .FirstOrDefault();
        }
    }
}