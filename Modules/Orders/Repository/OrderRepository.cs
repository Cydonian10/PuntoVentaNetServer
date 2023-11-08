using ApiStore.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ApiStore.Modules.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _context;

        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }

        async public Task<Guid> CreateFullOrderItems(CreateFullOrderDto dto)
        {
           
                var orderItemsParametrers = new SqlParameter("@OrderItems", SqlDbType.Structured)
                {
                    TypeName = "dbo.OrderItemList",
                    Value = ConvertUtil.OrdersItemsToDataTable(dto.CreateOrderItems)
                };

                var parametrerId = new SqlParameter("@Id", SqlDbType.UniqueIdentifier);
                parametrerId.Direction = ParameterDirection.Output;

                await _context.Database
                        .ExecuteSqlInterpolatedAsync($@"EXEC [CrearOrder] 
                                @Pay = {dto.Pay}, @TotalAmount = {dto.TotalAmount},
                                @OrderDate = {dto.OrderDate}, @UserId = {dto.UserId},
                                @CashDrawerId = {dto.CashDrawerId},
                                @CustomerId = {dto.CustomerId},
                                @OrderItems = {orderItemsParametrers},
                                @NewOrderId = {parametrerId} output
                                ");
                Guid newOrderId = (Guid)parametrerId.Value;

                return newOrderId;
                  
        }

        public Task<string> UpdateOrder(UpdateOrderDto dto)
        {
            throw new NotImplementedException();
        }


    }
}
