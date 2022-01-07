/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF NOT EXISTS (SELECT * FROM dbo.Food)
begin
    insert into dbo.Food(Title, [Decription], Price)
    values('Cheeseburger Meal','A cheeseburger that ate all other burgers', 5.95),
          ('Cili Dog Meal','A dog that is cold', 4.15),
          ('Vegan Meal','To trigger your conservative parents', 69.42);
end