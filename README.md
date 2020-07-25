# InventoryApplication
Inventory Application - MVC , Asp.Net Web APIs ,ORM - Entity Framework ,MSSQL DB

Architecture:- The inventory application is developed on the latest architecture which is mentioned below.

Front End Client: The front end is developed with the idea to make application fully responsive by using Bootstrap classes and
Asp.Net MVC views which uses Asynchronous client side AJAX calls to consume the Web APIs and makes the user interface responsive.

Backend Server: The application is developed by using RESTful Web APIs in the backend which internally implements Entity Framework ORM.
Database: The application uses relational database which is designed by using MSSQL server.

Note: In the Master thread application itself is devided into three parts UI , APIs , database which contains appropriate code.
dbShopBridge folder contains queries for creating database.

/* Changes to run the deliverables */
1. Go to git\InventoryApplication\ >> dbShopBridge Folder >> Either execute the queries in the database or Restore the dbShopBridgeInventory_Backup file 

2. Go to git\InventoryApplication\apisShopBridge\apisShopBridge>> Web.Config >> 
	2.1 open the web.config file and search for << dbShopBridgeInventoryEntities >> and delete the whole connectionstring.
3. go to git\InventoryApplication\apisShopBridge\apisShopBridge\EntityModel right click and delete the old entity model
4. After deleting old entity model add new Entity Model from your DB and do not forget the write the connection string name as << dbShopBridgeInventoryEntities >>.
	4.1 For adding new EntityModel please refer https://www.c-sharpcorner.com/article/asp-net-mvc5-entity-framework-database-first-approach/ 
	4.2 and start from Step 2 (Note: Kindly put the folder name as <<EntityModel>> ).
	4.3 In Step5 please fill in "Save connection settings in Web.Config as:" << dbShopBridgeInventoryEntities >>
	
5. Next Go to git\InventoryApplication\uiShopBridge\uiShopBridge\Scripts >>	InventoryOperations.js
	5.1 Open the file and update the variable << apiURL >> with your Web APIs localhost path.
6. Next Go to git\InventoryApplication\uiShopBridge\uiShopBridge\Views\Items and open ItemDetails.cshtml
	6.1 Update the variable <<apiURL>> value with your WebAPIs localhost URL.


Its Done Hope it works successfully fine in your system too.
If you face any type of inconvinience you can contact me on below mentioned details.

Name 		Jalaj Varshney
Whatsapp	8868859143
Email		jalaj.v801@gmail.com

Thanks