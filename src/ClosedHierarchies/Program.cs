using AfterClosed;

static string Describe(OrderStatus status) => status switch
{
    Pending => "Waiting to be shipped",
    Shipped s => $"On the way: {s.TrackingNumber}",
    Delivered d => $"Delivered on {d.DeliveredAt:d}",
};