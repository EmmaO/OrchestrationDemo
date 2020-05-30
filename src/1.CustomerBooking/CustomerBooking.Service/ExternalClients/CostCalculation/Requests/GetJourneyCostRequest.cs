namespace CustomerBooking.Service.ExternalClients.CostCalculation.Requests
{
    public class GetJourneyCostRequest
    {
        public string PickupPostcode { get; set; }
        public string DestinationPostcode { get; set; }
    }
}