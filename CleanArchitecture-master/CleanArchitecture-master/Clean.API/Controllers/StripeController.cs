using Clean.Application.Dtos;
using Clean.Application.Dtos.Stripe;
using Clean.Application.Services.Stripes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stripe;
using System.Numerics;

namespace Clean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : Controller
    {
        private readonly IStripeService stripeService;

        public StripeController(IStripeService stripeService)
        {
            this.stripeService = stripeService;
        }

        [HttpPost("checkout")]
        public async Task<ResponseDto> CheckOutSessionAsync(List<string> priceIds, int quantity)
        {
            return await this.stripeService.CheckOutSessionAsync(priceIds, quantity);

        }
        [HttpPost("completedWebhook")]
        public async Task<ResponseDto> StripeWebhook(string requestBody)
        {
            return await this.stripeService.StripeWebhook(requestBody);

        }
        [HttpGet("GetUserSubscriptions")]
        public ResponseDto GetUserSubscriptions(string customerId)
        {
            return this.stripeService.GetUserSubscriptions(customerId);
        }
        [HttpPost("UpdateSubscription")]
        public async Task<ResponseDto> UpdateSubscription(UpdateSubscriptionDto updateSubscription)
        {
            return await this.stripeService.UpdateSubscription(updateSubscription.SubscriptionId, updateSubscription.SubscriptionItemIds, updateSubscription.NewPriceIds);
        }
        [HttpPost("CancelSubscription")]
        public async Task CancelSubscription(string subscriptionId)
        {
            StripeConfiguration.ApiKey = "sk_test_51N2XwECTIdeS2WufO7o4OXZ4NztBtiLaODpvtjgROviDokgn3itCniC0p5ILrLjUNVDplHIK9U4jvr1mvdMnw5P3008qCAASyL";
            var service = new SubscriptionService();
            var data = service.Cancel(subscriptionId);
        }
        [HttpPost("RecordUsage")]
        public async Task<ResponseDto> RecordUsage(string subscriptionItemId, int quantity)
        {
            return await this.stripeService.RecordUsage(subscriptionItemId,quantity);
        }
        [HttpPost("ReactivateSubscription")]
        public async Task ReactivateSubscription(string customerId, string priceId)
        {
            // Set your API key
            StripeConfiguration.ApiKey = "sk_test_51N2XwECTIdeS2WufO7o4OXZ4NztBtiLaODpvtjgROviDokgn3itCniC0p5ILrLjUNVDplHIK9U4jvr1mvdMnw5P3008qCAASyL";

            // Retrieve the subscription
            var service = new SubscriptionService();

            var options = new SubscriptionCreateOptions
            {
                Customer = customerId,
                Items = new List<SubscriptionItemOptions>
                {
                    new SubscriptionItemOptions
                    {
                        Price = priceId,
                    }
                }
            };

            var subscription = service.Create(options);
        }
    }
}
