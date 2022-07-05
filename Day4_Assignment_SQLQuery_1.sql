USE Northwind
GO
/*1. Create a view named “view_product_order_[your_last_name]”, list all products and total ordered quantity for that product.*/
CREATE VIEW view_product_order_Wang AS
SELECT p.ProductID, p.ProductName, SUM(od.Quantity)[Total Ordered Quantity]
FROM Products p 
JOIN [Order Details] od 
ON od.ProductID = p.ProductID
GROUP BY p.ProductID, p.ProductName

SELECT * FROM view_product_order_Wang

/*2. Create a stored procedure “sp_product_order_quantity_[your_last_name]” that accept product id as an input and total quantities 
of order as output parameter.*/
CREATE PROCEDURE sp_product_order_quantity_wang @id INT
AS
SELECT p.ProductID, SUM(od.Quantity) [Quantity]
FROM Products p 
JOIN [Order Details] od  
ON p.ProductID = od.ProductID
WHERE p.ProductID = @id
GROUP BY p.ProductID
GO

EXEC sp_product_order_quantity_wang @id = 11

DROP PROCEDURE DBO.sp_product_order_quantity_wang

/*Drop Procedure
DROP PROCEDURE sp_product_order_quantity_wang
Refresh*/

/*3. Create a stored procedure “sp_product_order_city_[your_last_name]” that accept product name as an input and top 5 cities that 
ordered most that product combined with the total quantity of that product ordered from that city as output.*/
CREATE PROCEDURE sp_product_order_city_wang @product_name VARCHAR(30)
AS
SELECT top 5 p.ProductName, o.ShipCity, sum(od.Quantity)[Total Quantites]
FROM Products p 
JOIN [Order Details] od
ON od.ProductID = p.ProductID
JOIN Orders o  
ON od.OrderID = o.OrderID
WHERE P.ProductName = @product_name
GROUP BY p.ProductName, o.ShipCity
ORDER BY sum(od.Quantity) DESC


EXEC sp_product_order_city_wang @product_name = "tofu"

drop PROCEDURE sp_product_order_city_wang

/*4.Create 2 new tables “people_your_last_name” “city_your_last_name”. City table has two records: 
{Id:1, City: Seattle}, {Id:2, City: Green Bay}. People has three records: 
{id:1, Name: Aaron Rodgers, City: 2}, {id:2, Name: Russell Wilson, City:1}, {Id: 3, Name: Jody Nelson, City:2}. 
Remove city of Seattle.If there was anyone from Seattle, put them into a new city “Madison”. 
Create a view “Packers_your_name” lists all people from Green Bay. If any error occurred, no changes should be made to DB. 
(after test) Drop both tables and view.*/

--create city_wang
CREATE TABLE city_wang (
    id INT IDENTITY(1,1),
    city VARCHAR(20)
)

SET IDENTITY_INSERT city_wang ON

INSERT city_wang 
(id, city)
VALUES
(1, 'Seattle'),
(2, 'Green Bay')

SELECT * FROM city_wang

DROP TABLE city_wang

--create people_wang
CREATE TABLE people_wang 
(
    id INT IDENTITY(1,1),
    Name VARCHAR(25),
    City INT FOREIGN KEY REFERENCES city_wang(id)
)

INSERT people_wang 
(Name, City)
VALUES
('Aaron Rodgers', 2),
('Russell Wilson', 1),
('Jody Nelson', 2)

SELECT * FROM people_wang

DROP TABLE people_wang

--remove Seattle to Madison
update city_wang 
SET city = 'Madison'
WHERE city = 'Seattle'

SELECT * FROM city_wang


--Create a view “Packers_your_name” lists all people from Green Bay. If any error occurred, no changes should be made to DB. 
--(after test) Drop both tables and view.*/
create VIEW Packers_Wang 
AS
SELECT pw.Name
FROM people_wang pw
JOIN city_wang cw  
on pw.city = cw.id
WHERE cw.city = 'Green Bay'

select * FROM Packers_Wang

drop view Packers_Wang


/*5. Create a stored procedure “sp_birthday_employees_[you_last_name]” that creates a new table “birthday_employees_your_last_name” and 
fill it with all employees that have a birthday on Feb. (Make a screen shot) drop the table. Employee table should not be affected.*/
create PROCEDURE sp_birthday_employees_wang
AS
BEGIN
CREATE TABLE birthday_employees_wang
(SELECT e.FirstName + ' ' + e.LastName [Full Name], e.BirthDate
FROM Employees e
WHERE month(BirthDate) = 2)
END

CREATE TABLE birthday_employees_wang
as
(SELECT *
FROM Employees e
WHERE month(BirthDate) = 2)
--error: Incorrect syntax near '('.

EXEC sp_birthday_employees_wang

drop table birthday_employees_wang


/*6. How do you make sure two tables have the same data?*/
/*
1. An inner join to pick up the rows where the primary key exists in both tables, 
but there is a difference in the value of one or more of the other columns. 
This would pick up changed rows in original.

2. A left outer join to pick up the rows that are in the original tables, 
but not in the backup table (i.e. a row in original has a primary key that does not exist in backup). 
This would return rows inserted into the original.

3. A right outer join to pick up the rows in backup which no longer exist in the original. 
This would return rows that have been deleted from the original.
*/



