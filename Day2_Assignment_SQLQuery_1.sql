/*1. How many products can you find in the Production.Product table?*/
use AdventureWorks2019
go

SELECT distinct p.Name
FROM Production.Product p 

/*2. Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. 
The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.*/
SELECT p.Name
FROM Production.Product p
WHERE p.ProductSubcategoryID IS NOT NULL

/*3.How many Products reside in each SubCategory? Write a query to display the results with the following titles.
ProductSubcategoryID CountedProducts*/
SELECT p.ProductSubcategoryID, COUNT(p.Name) [CountedProducts]
FROM Production.Product p
WHERE p.ProductSubcategoryID IS NOT NULL
GROUP BY p.ProductSubcategoryID

/*4.How many products that do not have a product subcategory.*/
SELECT COUNT(p.ProductSubcategoryID) [Products with No Subcategory]
FROM Production.Product p

/*5.Write a query to list the sum of products quantity in the Production.ProductInventory table.*/
SELECT SUM(p.Quantity) [Total Quantity]
FROM Production.ProductInventory p 

/*6.Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to 
include just the ProductIds that have less than 100 total in sum.
              ProductID    TheSum     */

SELECT p.ProductID, sum(p.Quantity) [TheSum]
FROM Production.ProductInventory p 
WHERE p.LocationID = 40
GROUP BY p.ProductID
HAVING sum(p.Quantity) <= 100

/*7. Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and 
LocationID set to 40 and include the ProductIds that have less than 100 total in sum.
    Shelf      ProductID    TheSum     */
SELECT p.Shelf, p.ProductID, sum(p.Quantity) [TheSum]
FROM Production.ProductInventory p 
WHERE p.LocationID = 40
GROUP BY p.Shelf, p.ProductID
HAVING sum(p.Quantity) <= 100

/*8.Write the query to list the average quantity for products where column LocationID has the value of 10 
from the table Production.ProductInventory table.*/
SELECT avg(p.Quantity) [TheAvg]
FROM Production.ProductInventory p 
WHERE p.LocationID = 10

/*9.Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory
    ProductID   Shelf      TheAvg     */
SELECT p.ProductID, p.Shelf, AVG(p.Quantity) [TheAvg]
FROM Production.ProductInventory p
GROUP BY p.Shelf, p.ProductID

/*10. Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A 
in the column Shelf from the table Production.ProductInventory
    ProductID   Shelf      TheAvg    */
SELECT p.ProductID, p.Shelf, AVG(p.Quantity) [TheAvg]
FROM Production.ProductInventory p
WHERE p.Shelf <> 'N/A'
GROUP BY p.Shelf, p.ProductID

/*11.List the members (rows) and average list price in the Production.Product table. 
This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.
    Color                        Class              TheCount          AvgPrice     */
SELECT p.Color, p.Class, COUNT(P.ProductID)[TheCount], AVG(p.ListPrice)[AvgPrice]
FROM Production.Product p 
WHERE p.Color IS NOT NULL AND p.Class IS NOT NULL
GROUP BY p.Color, p.Class

/*12.Joins.Write a query that lists the country and province names from person.CountryRegion and person.StateProvince tables. 
Join them and produce a result set similar to the following.
    Country                        Province     */
SELECT a.Name [Country], b.Name [Province]
FROM Person.CountryRegion a 
JOIN Person.StateProvince b 
ON a.CountryRegionCode = b.CountryRegionCode

/*13.Write a query that lists the country and province names from person.CountryRegion and person.StateProvince tables 
and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.
 
    Country                        Province     */
SELECT a.Name [Country], b.Name [Province]
FROM Person.CountryRegion a 
JOIN Person.StateProvince b 
ON a.CountryRegionCode = b.CountryRegionCode
WHERE a.Name IN ('Germany', 'Canada')
ORDER BY Country

--Use Northwinds
/*14.List all Products that has been sold at least once in last 25 years.*/
USE Northwind
Go

SELECT distinct p.ProductName
FROM dbo.Products p 
JOIN dbo.[Order Details] od
ON p.ProductID = od.ProductID
JOIN dbo.Orders o 
ON od.OrderID = o.OrderID
WHERE DATEDIFF(YEAR, o.OrderDate, GetDate()) <25
ORDER BY p.ProductName

/*15.  List top 5 locations (Zip Code) where the products sold most.*/
SELECT TOP 5 o.ShipPostalCode, sum(od.Quantity) [Quantities Sold]
FROM dbo.[Order Details] od JOIN dbo.Orders o ON od.OrderID = o.OrderID
WHERE o.ShipPostalCode IS NOT NULL
GROUP BY o.ShipPostalCode
ORDER BY 2 DESC

/*16.  List top 5 locations (Zip Code) where the products sold most in last 25 years.*/
SELECT TOP 5 o.ShipPostalCode, sum(od.Quantity) [Quantities Sold]
FROM dbo.[Order Details] od JOIN dbo.Orders o ON od.OrderID = o.OrderID
WHERE o.ShipPostalCode IS NOT NULL AND DATEDIFF(year, o.OrderDate, GETDATE())< 25
GROUP BY o.ShipPostalCode
ORDER BY 2 DESC

/*17. List all city names and number of customers in that city. */
SELECT c.City, Count(c.CustomerID)[Customer Counts] 
FROM Customers c
GROUP BY c.City

/*18.List city names which have more than 2 customers, and number of customers in that city*/
SELECT c.City, Count(c.CustomerID)[Customer Counts] 
FROM Customers c
GROUP BY c.City
HAVING Count(c.CustomerID) > 2

/*19.List the names of customers who placed orders after 1/1/98 with order date.*/
SELECT c.ContactName, o.OrderDate
FROM Customers c
JOIN Orders o 
on c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1998-01-01'

/*20.List the names of all customers with most recent order dates*/
SELECT c.ContactName, MAX(o.OrderDate)
FROM Customers c
JOIN Orders o 
on c.CustomerID = o.CustomerID
GROUP BY c.ContactName

/*21.Display the names of all customers  along with the  count of products they bought.*/
SELECT c.ContactName, isnull(sum(od.Quantity),0)[Total Products Bought]
FROM Customers c
LEFT JOIN [Orders] o 
ON c.CustomerID = o.CustomerID
LEFT JOIN [Order Details] od 
on o.OrderID = od.OrderID
GROUP BY c.ContactName
ORDER BY 2 DESC

/*22.Display the customer ids who bought more than 100 Products with count of products.*/
SELECT c.ContactName, isnull(sum(od.Quantity),0)[Total Products Bought]
FROM Customers c
LEFT JOIN [Orders] o 
ON c.CustomerID = o.CustomerID
LEFT JOIN [Order Details] od 
on o.OrderID = od.OrderID
GROUP BY c.ContactName
HAVING sum(od.Quantity) > 100
ORDER BY 2 DESC

/*23.List all of the possible ways that suppliers can ship their products. Display the results as below
    Supplier Company Name                Shipping Company Name     */
SELECT sp.CompanyName [Supplier Company Name], sh.CompanyName
FROM Suppliers sp
CROSS JOIN Shippers sh 

/*24.Display the products order each day. Show Order date and Product Name.*/
SELECT o.OrderDate, p.ProductName
FROM Products p
JOIN [Order Details] od 
ON p.ProductID = od.ProductID
JOIN Orders o 
ON od.OrderID = o.OrderID

/*25.Displays pairs of employees who have the same job title.*/
SELECT e1.FirstName + '' + e1.LastName [Employee A Name], e2.FirstName + '' + e2.LastName [Employee B Name], e1.Title
FROM Employees e1
JOIN Employees e2
ON e1.Title = e2.Title
WHERE e1.EmployeeID <> e2.EmployeeID

/*26.Display all the Managers who have more than 2 employees reporting to them.*/
SELECT 
sup.employeeid, 
sup.firstname, 
sup.lastname, 
COUNT (sub.employeeid) AS number_of_employees
FROM Employees sub
JOIN Employees sup
ON sub.ReportsTo = sup.employeeid
GROUP BY sup.employeeid, sup.firstname, sup.lastname;

/* First part
SELECT 
sup.employeeid{table1.columnA},
sup.firstname, 
sup.lastname
FROM Employees sub
JOIN Employees sup
ON sup.employeeid{table1.columnA} = sub.ReportsTo{table2.columnB}
*/


/* experienmets
SELECT e1.EmployeeID, e1.FirstName
FROM Employees e1, Employees e2
WHERE e2.ReportsTo = e1.EmployeeID

select e2.FirstName, count(e2.EmployeeID)[Employee Numbers]
from Employees e2
HAVING COUNT(e2.EmployeeID) >2


select e2.FirstName, e2.LastName, e2.ReportsTo, count(e2.EmployeeID)[Employee Numbers]
from Employees e2
RIGHT JOIN employees e1
on e1.reportsto = e2.EmployeeID --e2.reportsto = e1.EmployeeID is wrong
group by e2.FirstName, e2.LastName, e2.ReportsTo, e2.ReportsTo
HAVING COUNT(e2.EmployeeID) >2


SELECT e2.EmployeeID, e2.FirstName, e2.LastName, count(e1.ReportsTo) as number_of_employees
from Employees e1
join Employees e2
on e1.ReportsTo = e2.EmployeeID
group by e2.EmployeeID, e2.FirstName, e2.LastName


SELECT 
sub.employeeid,
    sub.firstname,
    sub.lastname,
    COUNT (sub.employeeid) AS number_of_employees
FROM Employees sub
JOIN Employees sup
ON sub.ReportsTo = sup.employeeid
GROUP BY sub.employeeid, sub.firstname, sub.lastname;


select b.EmployeeID, b.FirstName, b.LastName
from Employees a
join Employees b
on a.EmployeeID = b.ReportsTo

select b.EmployeeID, b.FirstName, b.LastName
from Employees a
join Employees b
on b.EmployeeID = a.ReportsTo*/


/*27.Display the customers and suppliers by city. The results should have the following columns
City Name [Contact Name] [Type (Customer or Supplier)]*/
select c.City, c.CompanyName [Name], c.ContactName [Contact Name], 'Customer' as [Type]
from Customers c
union 
select s.City, s.CompanyName, s.ContactName, 'Supplier'
FROM Suppliers s
ORDER BY City ASC
