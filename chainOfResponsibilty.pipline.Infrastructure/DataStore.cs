using chainOfResponsibilty.pipline.Domaine.Entities;

namespace chainOfResponsibilty.pipline.Infrastructure
{
    public class DataStore
    {
        private readonly List<Subscription> _subscriptions;

        public DataStore()
        {
            _subscriptions = new List<Subscription>()
            {
                new Subscription{Id = 1 , Balance = 60 },
                new Subscription{Id = 2 , Balance = 20 },
                new Subscription{Id = 3 , Balance = 100 },
            };
        }
        public Subscription? GetSubscriptionById(int id)
        {
            return _subscriptions.FirstOrDefault(sub => sub.Id == id);
        }




        
    }
}
