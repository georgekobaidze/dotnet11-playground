namespace BeforeClosed;

public abstract record OrderStatus;
public record Pending : OrderStatus;
public record Shipped(string TrackingNumber) : OrderStatus;
public record Delivered(DateTime DeliveredAt) : OrderStatus;