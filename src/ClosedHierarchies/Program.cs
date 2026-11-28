static string Describe(OrderStatus status) => status switch
{
    Pending => "Waiting to be shipped",
    Shipped s => $"On the way: {s.TrackingNumber}",
    Delivered d => $"Delivered on {d.DeliveredAt:d}",
};

public closed record OrderStatus;
public record Pending : OrderStatus;
public record Shipped(string TrackingNumber) : OrderStatus;
public record Delivered(DateTime DeliveredAt) : OrderStatus;