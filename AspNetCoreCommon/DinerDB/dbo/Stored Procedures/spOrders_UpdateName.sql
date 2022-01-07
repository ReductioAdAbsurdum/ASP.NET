CREATE PROCEDURE [dbo].[spOrders_UpdateName]
	@Id int,
	@OrderName nvarchar(50)
AS	
begin

	set nocount on;

	update dbo.[Order]
	set [Order].OrderName = @OrderName
	where [Order].Id = Id;

end
