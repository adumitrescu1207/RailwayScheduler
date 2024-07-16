using RailwayScheduler.Models;
using RailwayScheduler.Database;

namespace RailwayScheduler.Services
{
    public class TrainService
    {
        private readonly DatabaseContext _trainContext;
        public TrainService(DatabaseContext trainContext)
        {
            _trainContext = trainContext;
        }
        public List<Train>? GetAll()
        {
            return _trainContext.Set<Train>().ToList();
        }
        public Train? GetById(int id) 
        {
            return _trainContext.Set<Train>().FirstOrDefault(train => train.Id == id);
        }
        public List<Train>? GetBySource(string source)
        {
            return _trainContext.Trains.Where(train => train.Source == source).ToList();
        }

        public List<Train>? GetByDestination(string destination)
        {
            return _trainContext.Trains.Where(train => train.Destination == destination).ToList();
        }

        public void Add(Train train)
        {
            _trainContext.Set<Train>().Add(train);
            _trainContext.SaveChanges();
        }

        public void Remove(int id)
        {
            var train = _trainContext.Set<Train>().FirstOrDefault(d => d.Id == id);
            _trainContext.Set<Train>().Remove(train);
            _trainContext.SaveChanges();
        }
        public void Update(int id, Train train) {
            var check = _trainContext.Set<Train>().FirstOrDefault(u => u.Id == id);
            if(check != null)
            {
                check.Destination = train.Destination;
                check.Source = train.Source;
                check.TimeDestination = train.TimeDestination;
                check.TimeSource = train.TimeSource;
                _trainContext.SaveChanges();
            }
        
        }
    }
}
