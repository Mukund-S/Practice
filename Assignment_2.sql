use AdventureWorks2019
-- 1. How many products can you find in the Production.Product table?
select count(ProductID) as NumOfProducts from Production.Product

-- 2. Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
select Count(*) as NumOfProducts from Production.Product where ProductSubCategoryId is not null

-- 3. How many Products reside in each SubCategory? Write a query to display the results with the following titles.
-- ProductSubcategoryID CountedProducts
-- -------------------- ---------------
select ProductSubcategoryID, count(ProductId) as CountedProducts from Production.Product
where ProductSubcategoryID is not null
group by ProductSubcategoryID

-- 4. How many products that do not have a product subcategory.
select Count(*) as NumOfProducts from Production.Product where ProductSubCategoryId is  null

-- 5.  Write a query to list the sum of products quantity in the Production.ProductInventory table.
select ProductID,SUM(Quantity) as TotalProducts from Production.ProductInventory
group by ProductID

-- 6. Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.
--               ProductID    TheSum
--               -----------        ----------
select ProductID, SUM(Quantity) as TheSum from Production.ProductInventory 
where LocationID=40
group by ProductID
having SUM(Quantity)<100

-- 7.    Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100
--     Shelf      ProductID    TheSum
--     ----------   -----------        -----------
select Shelf,ProductID, SUM(Quantity) as TheSum from Production.ProductInventory 
where LocationID=40
group by ProductID,Shelf
having SUM(Quantity)<100

-- 8. Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.
select ProductId, AVG(Quantity) as Average from Production.ProductInventory where LocationID=10
group by ProductID

-- 9.    Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory
--     ProductID   Shelf      TheAvg
--     ----------- ---------- -----------
select ProductID, Shelf, AVG(Quantity) as TheAvg from Production.ProductInventory
group by ProductID, Shelf

-- 10.  Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory
--     ProductID   Shelf      TheAvg
--     ----------- ---------- -----------
select ProductID, Shelf, AVG(Quantity) as TheAvg from Production.ProductInventory
where Shelf!='N/A'
group by ProductID, Shelf

-- 11.  List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.
--     Color                        Class              TheCount          AvgPrice
--     -------------- - -----    -----------            ---------------------
select Color, Class, count(*) AS TheCount, AVG(ListPrice) AS AvgPrice FROM Production.Product
WHERE color IS NOT NULL AND class IS NOT NULL
GROUP BY color, class;

-- Joins:

-- 12.   Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following.
--     Country                        Province
--     ---------                          ----------------------
select cr.Name as Country, sp.Name as Province from person.CountryRegion cr
join person.StateProvince sp ON cr.CountryRegionCode = sp.CountryRegionCode;


-- 13.  Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.
--     Country                        Province
--     ---------                          ----------------------
select cr.Name as Country, sp.Name as Province from person.CountryRegion cr
join person.StateProvince sp on cr.CountryRegionCode = sp.CountryRegionCode
where cr.Name in ('Germany', 'Canada');


--  Using Northwnd Database: (Use aliases for all the Joins)
use Northwind


-- 14.  List all Products that has been sold at least once in last 25 years.
select p.ProductName, o.OrderDate from Products p 
join [Order details] od on p.ProductId = od.ProductId 
join orders o on o.OrderID = od.OrderID
where o.orderDate>DATEADD(YEAR, -27, GETDATE())
order by o.OrderDate

-- 15.  List top 5 locations (Zip Code) where the products sold most.
select TOP 5 ShipPostalCode as ZipCode, COUNT(ShipPostalCode) as Sold from Orders
group by ShipPostalCode
order by count(ShipPostalCode) DESC


-- 16.  List top 5 locations (Zip Code) where the products sold most in last 25 years.
select TOP 5 ShipPostalCode as ZipCode, COUNT(ShipPostalCode) as Sold from Orders
where DATEDIFF(year,orderDate,GETDATE())<27
group by ShipPostalCode
order by count(ShipPostalCode) desc

-- 17.   List all city names and number of customers in that city.     
select City, Count(CustomerID) as NoOfCustomers from Customers
group by City

-- 18.  List city names which have more than 2 customers, and number of customers in that city
select City, Count(CustomerID) as NoOfCustomers from Customers
group by City
having Count(CustomerID)>2

-- 19.  List the names of customers who placed orders after 1/1/98 with order date.
select c.ContactName, o.OrderDate from Customers c join Orders o on o.CustomerID=c.CustomerID
where o.OrderDate>'1/1/98'

-- 20.  List the names of all customers with most recent order dates
select c.ContactName, o.OrderDate from Customers c join Orders o on o.CustomerID=c.CustomerID
order by o.OrderDate desc

-- 21.  Display the names of all customers  along with the  count of products they bought
select c.ContactName, COUNT(od.ProductID) as ProductCount from Customers c join Orders o on o.CustomerID=c.CustomerID join [Order Details] od on od.OrderID=o.OrderID
GROUP by c.ContactName


-- 22.  Display the customer ids who bought more than 100 Products with count of products.
select c.ContactName, COUNT(od.ProductID) as ProductCount from Customers c join Orders o on o.CustomerID=c.CustomerID join [Order Details] od on od.OrderID=o.OrderID
group by c.ContactName
having COUNT(od.ProductID)>100

-- 23.  List all of the possible ways that suppliers can ship their products. Display the results as below

--     Supplier Company Name                Shipping Company Name

--     ---------------------------------            ----------------------------------

select DISTINCT su.CompanyName as Supplier,s.CompanyName as Shipper from Suppliers su 
join Products p on su.SupplierID=p.SupplierID 
join [Order Details] od on p.ProductID=od.ProductID
join Orders o on od.OrderID=o.OrderID
join Shippers s on o.ShipVia=s.ShipperID


-- 24.  Display the products order each day. Show Order date and Product Name.
select o.OrderDate, p.ProductName from Products p
join [Order Details] od on p.ProductID = od.ProductID
join Orders o on od.OrderID = o.OrderID
order by o.OrderDate, p.ProductName;



-- 25.  Displays pairs of employees who have the same job title.
select e1.FirstName,e2.FirstName, e1.Title from Employees e1 
join Employees e2 on e1.Title = e2.Title and e1.Firstname < e2.Firstname

-- 26.  Display all the Managers who have more than 2 employees reporting to them.
SELECT  e.FirstName FROM Employees e
INNER JOIN  (select ReportsTo, COUNT(ReportsTo) as 'Number of Employees' from Employees
group by ReportsTo
having COUNT(ReportsTo)>2) dt
ON e.EmployeeID=dt.ReportsTo

-- 27.  Display the customers and suppliers by city. The results should have the following columns
-- City
-- Name
-- Contact Name,
-- Type (Customer or Supplier)
with Cte
as(
    select 
        City,
        CompanyName as Name,
        ContactName,
        'Customer' AS Type
    from 
        Customers
    UNION ALL
    select 
        City,
        CompanyName as Name,
        ContactName,
        'Supplier' as Type
    from 
        Suppliers
)
select * from Cte

