# SalesHistory
Use Case: A sales person wants to see historical data regarding the sale of a part, parent part (assembly), or payment details on an order. 

This application is a .NET MVC sales order search application. No database is attached; therefore, there is no data driving the application. The .NET backend uses Entity Framework for ORM and MS SQL connection strings for the database. The app is a single page application with three views: a part, parent part, and order search. Each screen contains a text input like parent part search. Text is entered and multiple search options are available. For example, the user can search a part by Part Number or by Part Description. The asp form specifies the type of search, and the search is implemented in the controller. The front-end is barebones JS/HTML/CSS. Cookies are implemented using Session Storage. The results are printed in a table that supports filtering and export to excel. The table is an open source project called Datatables. The database utilizes stored procedures that are invoked by the controllers. The tabs at the top of the page correspond to views that are dynamically rendered in the body of the SPA. 

**Server**

.NET MVC on IIS

**Database**

MS SQL

**Front-End**

Razor

JS/HTML/CSS

**Table supporting search and excel export**

https://datatables.net/

**ORM**

Entity Framework

**State Management**

Session Storage










