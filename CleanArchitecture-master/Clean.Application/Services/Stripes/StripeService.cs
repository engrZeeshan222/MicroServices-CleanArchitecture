using Clean.Application.Dtos;
using Clean.Application.Interface;

namespace Clean.Application.Services.Stripes
{
    public class StripeService : IStripeService
    {
        private readonly IStripeRepository stripeRepository;

        public StripeService(IStripeRepository stripeRepository)
        {
            this.stripeRepository = stripeRepository;
        }
  
        public async Task<ResponseDto> CheckOutSessionAsync(List<string> priceIds, int quantity)
        {
           return await this.stripeRepository.CheckOutSessionAsync(priceIds,quantity);
        }

        public ResponseDto GetUserSubscriptions(string customerId)
        {
           return this.stripeRepository.GetUserSubscriptions(customerId);
        }

        public async Task<ResponseDto> RecordUsage(string subscriptionItemId, int quantity)
        {
            return await this.stripeRepository.RecordUsage(subscriptionItemId, quantity);
        }

        public async Task<ResponseDto> StripeWebhook(string requestBody)
        {
            return await this.stripeRepository.StripeWebhook(requestBody);
        }
        public async Task<ResponseDto> UpdateSubscription(string subscriptionId, List<string> subscriptionItemIds, List<string> newPriceIds)
        {
            return await this.stripeRepository.UpdateSubscription(subscriptionId,subscriptionItemIds, newPriceIds);
        }
    }
}
