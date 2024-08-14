using Clean.Application;
using Clean.Application.Dtos;
using Clean.Application.Dtos.Stripe;
using Clean.Application.Interface;
using Newtonsoft.Json;
using Stripe;
using Stripe.BillingPortal;
using Stripe.Checkout;
using Stripe.FinancialConnections;

namespace Clean.Infrastructure.Repositories
{

    public class StripeRepository : IStripeRepository
    {


        public async Task<ResponseDto> CheckOutSessionAsync(List<string> priceIds, int quantity)
        {
            var response = new ResponseDto();
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51N2XwECTIdeS2WufO7o4OXZ4NztBtiLaODpvtjgROviDokgn3itCniC0p5ILrLjUNVDplHIK9U4jvr1mvdMnw5P3008qCAASyL";

                var lineItems = new List<SessionLineItemOptions>();

                foreach (var priceId in priceIds)
                {
                    lineItems.Add(new SessionLineItemOptions
                    {
                        Price = priceId,
                        Quantity = 1

                    });
                }

                var options = new Stripe.Checkout.SessionCreateOptions
                {
                    SuccessUrl = "http://localhost:4200/inform-register",
                    CancelUrl = "http://localhost:4200/register",
                    PaymentMethodTypes = new List<string> { "card" },
                    LineItems = lineItems,
                    Mode = "subscription",
                    ClientReferenceId = "1",
                    PaymentMethodCollection = "if_required"

                };

                // Create a new session
                var service = new Stripe.Checkout.SessionService();
                var session = await service.CreateAsync(options);
                response.Data = session.Url;
                response.Status = true;
                response.Message = "User Adedd SuccessFully";
            }
            catch (Exception ex)
            {
                response.Message = ex.InnerException?.Message;
            }
            return response;
        }
        public async Task<ResponseDto> RecordUsage(string subscriptionItemId, int quantity)
        {
            var response = new ResponseDto();
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51N2XwECTIdeS2WufO7o4OXZ4NztBtiLaODpvtjgROviDokgn3itCniC0p5ILrLjUNVDplHIK9U4jvr1mvdMnw5P3008qCAASyL";

                var options = new UsageRecordCreateOptions
                {
                    Quantity = quantity,
                    Timestamp = DateTime.UtcNow,
                    Action = "increment",
                };
                var service = new UsageRecordService();
                var usageRecord = service.Create(subscriptionItemId, options);
                response.Data = usageRecord;
                response.Status = true;
                response.Message = "User Adedd SuccessFully";
            }
            catch (Exception ex)
            {
                response.Message = ex.InnerException?.Message;
            }
            return response;
        }
        public async Task<ResponseDto> UpdateSubscription(string subscriptionId, List<string> subscriptionItemIds, List<string> newPriceIds)
        {
            var response = new ResponseDto();
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51N2XwECTIdeS2WufO7o4OXZ4NztBtiLaODpvtjgROviDokgn3itCniC0p5ILrLjUNVDplHIK9U4jvr1mvdMnw5P3008qCAASyL";

                var options = new SubscriptionUpdateOptions
                {
                    Items = new List<SubscriptionItemOptions>()
                };

                for (int i = 0; i < subscriptionItemIds.Count; i++)
                {
                    options.Items.Add(new SubscriptionItemOptions
                    {
                        Id = subscriptionItemIds[i],
                        Deleted = true
                    });
                }
                for (int i = 0; i < newPriceIds.Count; i++)
                {
                    options.Items.Add(new SubscriptionItemOptions
                    {
                        Price = newPriceIds[i]
                    });
                }
                var service = new SubscriptionService();
                var updatedSubscription = await service.UpdateAsync(subscriptionId, options);

                response.Data = updatedSubscription;
                response.Status = true;
                response.Message = "User Adedd SuccessFully";
            }
            catch (Exception ex)
            {
                response.Message = ex.InnerException?.Message;
            }
            return response;
        }
        public ResponseDto GetUserSubscriptions(string customerId)
        {
            var response = new ResponseDto();
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51N2XwECTIdeS2WufO7o4OXZ4NztBtiLaODpvtjgROviDokgn3itCniC0p5ILrLjUNVDplHIK9U4jvr1mvdMnw5P3008qCAASyL";
                var options = new SubscriptionListOptions { Customer = customerId };
                var service = new SubscriptionService();
                StripeList<Subscription> subscriptions = service.List(options);
                string ItemSubscriptionIds = "";
                string PriceIds = "";
                string SubscriptionId = "";
                foreach (var subscription in subscriptions.Data[0].Items)
                {
                    if (PriceIds == "" && ItemSubscriptionIds == "")
                    {
                        ItemSubscriptionIds += subscription.Id;
                        PriceIds += subscription.Price.Id;
                    }
                    else
                    {
                        ItemSubscriptionIds += "," + subscription.Id;
                        PriceIds += "," + subscription.Price.Id;
                    }

                    SubscriptionId = subscription.Subscription;
                }
                string ItemSubscriptionId = subscriptions.Data[0].Items.Data[0].Id;
                var priceId = subscriptions.Data[0].Items.Data[0].Price.Id;
                response.Data = new
                {
                    PriceIds = PriceIds,
                    ItemSubscriptionIds = ItemSubscriptionIds,
                    SubscriptionId = SubscriptionId
                };
                response.Status = true;
                response.Message = "User Adedd SuccessFully";
            }
            catch (Exception ex)
            {
                response.Message = ex.InnerException?.Message;
            }
            return response;
        }
        public async Task<ResponseDto> StripeWebhook(string requestBody)
        {
            var response = new ResponseDto();
            try
            {
                DeserializeStripeDTO myDeserializedClass = JsonConvert.DeserializeObject<DeserializeStripeDTO>(requestBody);
                int id = int.Parse(myDeserializedClass.data.@object.client_reference_id);
                var customerId = myDeserializedClass.data.@object.customer;
                response.Data = customerId;
                response.Status = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.InnerException?.Message ?? ex.Message;
            }
            return response;
        }

    }
}

