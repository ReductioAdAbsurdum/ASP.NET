CREATE PROCEDURE [dbo].[spFood_All]
AS
begin
	
	set nocount on;

	select [Id], [Title], [Decription], [Price]
	from dbo.Food;

end
