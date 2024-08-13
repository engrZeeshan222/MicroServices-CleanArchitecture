namespace Clean.Application.Dtos.Stripe
{
    public class UpdateSubscriptionDto
    {
        public string SubscriptionId { get; set; }
        public List<string> SubscriptionItemIds { get; set; }
        public List<string> NewPriceIds { get; set; }
    }
}
