using System.Data;

namespace ApiStore.Modules.Orders
{
    public class ConvertUtil
    {
        public static DataTable OrdersItemsToDataTable(ICollection<CreateOrderItemDto> orderItems)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductId", typeof(Guid));
            dt.Columns.Add("Quantity", typeof(decimal));
            dt.Columns.Add("UnitPrice", typeof(decimal));
            dt.Columns.Add("UnitMeasurement", typeof(string));

            foreach (var item in orderItems)
            {
                dt.Rows.Add(item.ProductId, item.Quantity, item.UnitPrice, item.UnitMeasurement);
            }

            return dt;
        }
    }
}
