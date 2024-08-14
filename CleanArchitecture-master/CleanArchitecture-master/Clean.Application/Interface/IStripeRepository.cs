using Clean.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Interface
{
    public interface IStripeRepository
    {
        Task<ResponseDto> CheckOutSessionAsync(List<string> priceIds, int quantity);
        Task<ResponseDto> StripeWebhook(string requestBody);
        Task<ResponseDto> UpdateSubscription(string subscriptionId, List<string> subscriptionItemIds, List<string> newPriceIds);
        ResponseDto GetUserSubscriptions(string customerId);
        Task<ResponseDto> RecordUsage(string subscriptionItemId, int quantity);
    }
}
