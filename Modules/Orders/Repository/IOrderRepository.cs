namespace ApiStore.Modules.Orders
{
    public interface IOrderRepository
    {
        Task<string> UpdateOrder(UpdateOrderDto dto);
        Task<Guid> CreateFullOrderItems(CreateFullOrderDto dto);
    }
}
