namespace ApiStore.Data;

public class CashDrawer
{
    public Guid Id { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public decimal InitSale { get; set; }
    public decimal TotalSale { get; set; }
    public bool Open { get; set; }
}
