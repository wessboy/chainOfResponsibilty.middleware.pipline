using chainOfResponsibilty.pipline.Domaine.Entities;
using chainOfResponsibilty.pipline.Domaine.Services;
using chainOfResponsibilty.pipline.Infrastructure;
namespace chainOfResponsibilty.pipline.Application
{
    public class PaymentManager : IPaymentManager
    {
        private readonly DataStore _store;
        public PaymentManager(DataStore store)
        {
                _store = store;
        }
        public bool CalculateFee(decimal fee, int subId)
        {
            
            
            Subscription subscription = _store.GetSubscriptionById(subId);

            if (subscription is null)
                return false;


            subscription.Balance -= fee;

            return true;
               
            


        }
    }
}
