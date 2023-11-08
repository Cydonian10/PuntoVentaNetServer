INSERT INTO [dbo].[Categories]
           ([Id]
           ,[Name]
           ,[Description])
     VALUES
			('8B3F30B6-D0D5-4CD7-AB3D-15B93854C5CB', 'Cat 1', 'bla bla bla'),
			('1B622A8D-FE98-472D-A7E8-44BB918F38E6', 'Cat 2', 'bla bla bla'),
			('5D3A5FD5-7512-428E-9584-7A9F6E297AF2', 'Cat 3', 'bla bla bla');
			

INSERT INTO [dbo].[Products]
           ([Id]
           ,[CategoryId]
           ,[Name]
           ,[Price]
           ,[Stock]
           ,[Description]
           ,[Image]
           ,[Igv]
           ,[FechaCreacion]
           ,[UnitMeasurement])
     VALUES
          ('CF0107F7-B7C0-409D-88AA-E7A77FAB4D42','8B3F30B6-D0D5-4CD7-AB3D-15B93854C5CB','Product1',5.50,12,'bla bla bla','avatar.url',0.18,GETDATE(), 'Kilogramo'),
		  (NEWID(),'1B622A8D-FE98-472D-A7E8-44BB918F38E6','Product2',6.50,12,'bla bla bla','avatar.url',0.18,GETDATE(), 'Unidades'),
		  (NEWID(),'8B3F30B6-D0D5-4CD7-AB3D-15B93854C5CB','Product3',7.50,12,'bla bla bla','avatar.url',0.18,GETDATE(), 'Kilogramo'),
		  ('CBC0DF72-B00F-4477-950E-4711412D60B7','5D3A5FD5-7512-428E-9584-7A9F6E297AF2','Product4',8.50,12,'bla bla bla','avatar.url',0.18,GETDATE(), 'Unidades');


INSERT INTO [dbo].[Role] ([Id], [Name])
	  VALUES 
            ('C93ACD5E-D9CD-4F24-9E77-2F813E962FB0','Admin'),
            ('8DB0C210-B2A6-4C88-A1A5-D38596E5CFFD','Employed');


INSERT INTO [dbo].[Users]
           ([Id]
           ,[RoleId]
           ,[Name]
           ,[Email]
           ,[Phone]
           ,[Avatar])
     VALUES
           ('72ecba84-5204-430d-b5e3-e3f62442e53a', 'C93ACD5E-D9CD-4F24-9E77-2F813E962FB0','Gabriel','depelos@hotmail.com','182838','avartar.url'),
		   ('0fed29cf-4028-4cff-b289-884ead8faeba', '8DB0C210-B2A6-4C88-A1A5-D38596E5CFFD','Mabel','depelos@hotmail.com','182838','avartar.url')


INSERT INTO [dbo].[Cutomers]
           ([Id]
           ,[Name]
           ,[LastName]
           ,[Phone])
     VALUES
           ('56ad2b18-4468-4b42-9f47-885b07c135e3','Pancho','Cabrera','123456789'),
           ('16923d82-8280-4883-81c6-706b8eff97ac','Pancho','Cabrera','123456789');

create type OrderItemList as table
(
	ProductId uniqueidentifier,
	Quantity decimal(4,2),
	UnitPrice decimal(4,2),
	UnitMeasurement varchar(50)
);

create procedure CrearOrder
	@Pay bit,
	@TotalAmount decimal(4,2),
	@OrderDate date,
	@UserId uniqueidentifier,
	@CustomerId uniqueidentifier,
	@CashDrawerId uniqueidentifier, -- esto esta cambiando añdiendo
    @OrderItems AS dbo.OrderItemList READONLY,
	@NewOrderID uniqueidentifier OUTPUT
as
begin
	begin try
		begin transaction;
		
		declare @OrderId uniqueidentifier;
		SET @OrderId = NEWID();
		SET	@NewOrderID = @OrderId;

		insert into dbo.Orders (Id, Pay, TotalAmount, OrderDate, UserId,CustomerId)
		values (@OrderId, @Pay, @TotalAmount, @OrderDate, @UserId,@CustomerId);

		insert into OrderItems (Id, ProductId, OrderId, Quantity, UnitPrice, UnitMeasurement)
		select NEWID(),ProductId,@OrderId, Quantity, UnitPrice, UnitMeasurement from @OrderItems;

		IF EXISTS (
			SELECT 1
			FROM Products p
			INNER JOIN @OrderItems oi ON p.Id = oi.ProductId
			WHERE p.Stock - oi.Quantity < 0
		)
		BEGIN 		
			-- Rollback si la actualización resultaría en un stock negativo
			rollback;
			print 'Stock fallo';
			-- Puedes lanzar una excepción u ofrecer un mensaje de error aquí si lo deseas
		END
		ELSE 
		BEGIN
			-- Declaro mi total price
			DECLARE @TotalPrice DECIMAL(10, 2);
			SELECT @TotalPrice = SUM(Quantity * UnitPrice) from OrderItems WHERE OrderId = @OrderId;

			-- Actulizo  products stock
			update Products
			set Stock = Stock - (Select SUM(Quantity) FROM @OrderItems where ProductId = Products.Id  )
			WHERE Id IN (SELECT ProductId FROM @OrderItems);
			
			--Actualizo el total price en Orders y CashDrawers
			update Orders SET TotalAmount = (
				@TotalPrice
			) WHERE Id  = @OrderId;

			update CashDrawers SET TotalSale = TotalSale + @TotalPrice WHERE Id =@CashDrawerId;
			commit;
		END
	end try
	begin catch
		rollback;
		THROW;
	end catch
end;

USE [Store]
GO

DECLARE @RC int
DECLARE @Pay bit = 0
DECLARE @TotalAmount decimal(4,2) = 12.12
DECLARE @OrderDate date = getdate()
DECLARE @UserId uniqueidentifier = '72ecba84-5204-430d-b5e3-e3f62442e53a'
DECLARE @CashDrawerId uniqueidentifier = '3A480DA7-546A-4E3E-B39F-FA4CD7ABE43A'
DECLARE @CustomerId uniqueidentifier = '56ad2b18-4468-4b42-9f47-885b07c135e3'
declare @OrderItems as dbo.OrderItemList;

insert into @OrderItems ( ProductId, Quantity, UnitPrice, UnitMeasurement)
	values 
		('CF0107F7-B7C0-409D-88AA-E7A77FAB4D42',1.0,1.4,'Unidades'),
		('CBC0DF72-B00F-4477-950E-4711412D60B7',1.0,1.2,'Unidades');

-- TODO: Set parameter values here.
DECLARE @IDResult uniqueidentifier;

EXEC [dbo].[CrearOrder] 
   @Pay
  ,@TotalAmount
  ,@OrderDate
  ,@UserId
  ,@CustomerId
  ,@CashDrawerId
  ,@OrderItems
  ,@IDResult output;
