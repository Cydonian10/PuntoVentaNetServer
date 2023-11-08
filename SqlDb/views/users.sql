-- Crear un trigger AFTER INSERT en la tabla Auth
 --migrationBuilder.Sql(@"
             CREATE TRIGGER dbo.CreateUserOnAuth
                ON Auths
                AFTER INSERT
                AS
                BEGIN
                    INSERT INTO Users (Id, Name, Email)
                    SELECT
                        i.Id, i.Name, i.Email
                    FROM inserted i;
                END;
                ENABLE TRIGGER dbo.CreateUserOnAuth ON Auths;   
            --);

--// using ApiStore.Configuration;
--// using Microsoft.AspNetCore.Mvc;
--// using Microsoft.Data.SqlClient;
--// using Newtonsoft.Json;
--// using System.Data;


--// namespace ApiStore;


--// [ApiController]
--// [Route("api/products")]
--// public class ProductController : ControllerBase
--// {
--//     public string _coneccion;

--//     public ProductController(DBConexion dBConexion)
--//     {
--//         _coneccion = dBConexion.GetConnectionString();
--//     }

--//     [HttpGet]
--//     public IActionResult GetAll()
--//     {
--//         List<ProductModel> products = new();

--//         using (SqlConnection connection = new(_coneccion))
--//         {
--//             connection.Open();

--//             using (SqlCommand command = new("GetProducts", connection))
--//             {
--//                 command.CommandType = CommandType.StoredProcedure;

--//                 SqlDataReader reader = command.ExecuteReader();

--//                 while (reader.Read())
--//                 {
--//                     ProductModel product = new ProductModel()
--//                     {
--//                         Id = Guid.Parse(reader["Id"].ToString()!),
--//                         Nombre = reader["Nombre"].ToString()!,
--//                         Cantidad = Convert.ToInt32(reader["Cantidad"]),
--//                         Precio = Convert.ToDecimal(reader["Precio"]),
--//                         Description = reader["Description"].ToString()!,
--//                         FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"].ToString()),
--//                     };

--//                     products.Add(product);
--//                 }
--//             }
--//         }

--//         return Ok(new
--//         {
--//             message = "List products",
--//             data = products
--//         });
--//     }
--// }
