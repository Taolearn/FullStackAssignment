use Northwind 
go
/*1.List all cities that have both Employees and Customers.*/
SELECT DISTINCT c.City
FROM Customers c
JOIN Employees e 
ON c.City = e.City

/*2.  List all cities that have Customers but no Employee.
a.      Use sub-query
b.      Do not use sub-query     */
--A. Use Sub-query
SELECT DISTINCT c.City
FROM Customers c
WHERE c.City NOT IN (SELECT e.City FROM Employees e)
--B. No Sub-query
SELECT c.City
FROM Customers c
EXCEPT
SELECT e.City
FROM Employees e

/*3.List all products and their total order quantities throughout all orders.*/
SELECT p.ProductID, P.ProductName, SUM(od.Quantity) [Total Order quantities]
FROM Products p 
JOIN [Order Details] od
ON p.ProductID = od.ProductID
GROUP BY p.ProductID, p.ProductName
ORDER BY p.ProductID

/*4.List all Customer Cities and total products ordered by that city.*/
SELECT c.City, SUM(od.Quantity) [Total Products Quantities]
FROM Customers c 
JOIN Orders o 
ON c.CustomerID = o.CustomerID
JOIN [Order Details] od 
ON o.OrderID = od.OrderID
GROUP BY c.City

SELECT c.City, p.ProductName, SUM(od.Quantity) [Product Quantity]
FROM Customers c 
JOIN Orders o 
ON c.CustomerID = o.CustomerID
JOIN [Order Details] od 
ON o.OrderID = od.OrderID
JOIN Products p  
ON od.ProductID = p.ProductID
GROUP BY c.City,  p.ProductName
ORDER BY c.City

/*5.List all Customer Cities that have at least two customers.
a.      Use union
b.      Use sub-query and no union     */
--A. Use union
--a solution)
select city  
from Customers
EXCEPT
/*{*/ SELECT city  
from Customers 
GROUP BY City 
HAVING Count(city)=1 /*}*/

--b solution)
/*{*/ select distinct city  
from Customers /*}*/       --this column(all cities)
EXCEPT                     --except
/*{*/ SELECT distinct city  
from Customers
group by City  
HAVING Count(city)=1 /*}*/--this column (city only has one costumer)
/*all except only one-count cities left cities count equal and above 2*/

--B.Subquery ?
SELECT city FROM customers GROUP BY city HAVING COUNT(*) >= 2
--SELECT city FROM (select * from customers) GROUP BY city HAVING COUNT(*) >= 2

/*6.List all Customer Cities that have ordered at least two different kinds of products.*/
SELECT c.City
FROM Customers c
JOIN Orders o 
ON c.CustomerID = o.CustomerID
JOIN [Order Details] od 
ON od.OrderID = o.OrderID
GROUP BY c.City
HAVING COUNT(od.ProductID) >2

/*7.List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.*/
SELECT c.ContactName
FROM Customers c
JOIN Orders o  
ON o.CustomerID = c.CustomerID
WHERE c.City <> o.ShipCity

/*8.List 5 most popular products, their average price, and the customer city that ordered most quantity of it.*/
select top 5 p.ProductID, p.ProductName, c.City, avg(p.UnitPrice),sum(od.Quantity)
from Customers c
JOIN orders o  
ON c.CustomerID = o.CustomerID
JOIN [Order Details] od  
ON od.OrderID = o.OrderID
JOIN Products p 
ON p.ProductID = od.ProductID
GROUP By p.ProductID, p.ProductName, c.City
order by sum(od.Quantity) DESC

/*9.List all cities that have never ordered something but we have employees there.
a.      Use sub-query
b.      Do not use sub-query   */
--a.)Use subpuery
SELECT distinct c.City
FROM Customers c
WHERE c.City IN (
    SELECT distinct c.City
    FROM Customers c
    left JOIN Orders o
    ON o.CustomerID = c.CustomerID
    left JOIN Employees e 
    ON e.EmployeeID = o.EmployeeID
    WHERE c.City <> o.ShipCity
AND c.City = e.City 
)

--b.) No use of subpuery
SELECT distinct c.City
FROM Customers c
left JOIN Orders o
ON o.CustomerID = c.CustomerID
left JOIN Employees e 
ON e.EmployeeID = o.EmployeeID
WHERE c.City <> o.ShipCity
AND c.City = e.City 

/*10.List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, 
and also the city of most total quantity of products ordered from. (tip: join  sub-query)*/
--3 columns
SELECT top 1 c.City, COUNT(o.OrderID)[Total Orders], SUM(od.Quantity)[Total Quantities]
FROM Customers c
JOIN Orders o  
ON c.CustomerID = o.CustomerID
JOIN [Order Details] od  
ON od.OrderID = o.OrderID
GROUP BY c.City
ORDER BY COUNT(o.OrderID) DESC, SUM(od.Quantity) DESC

--only city column
SELECT tableDetail.City
FROM 
(SELECT top 1 c.City, COUNT(o.OrderID)[Total Orders], SUM(od.Quantity)[Total Quantities]
FROM Customers c
JOIN Orders o  
ON c.CustomerID = o.CustomerID
JOIN [Order Details] od  
ON od.OrderID = o.OrderID
GROUP BY c.City
ORDER BY COUNT(o.OrderID) DESC, SUM(od.Quantity) DESC) as tableDetail

/*11.How do you remove the duplicates record of a table?*/
--a.) use self join
--b.) use distinct statement
--c.) use CTE and row_number()
--d.) use rank function
