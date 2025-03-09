namespace SAX.Domain;

public enum MediaType
{
    Image,
    Video,
    Document
}

public enum MovementType
{
    Inbound,
    Outbound,
    Adjustment
}

public enum LogLevel
{
    Information,
    Warning,
    Error,
    Debug
}

public enum OrderStatus
{
    Pending,
    Processing,
    Shipped,
    Completed,
    Cancelled
}

public enum PaymentStatus
{
    Pending,
    Approved,
    Rejected
}

public enum PromotionType
{
    Percentage,
    FixedAmount
}