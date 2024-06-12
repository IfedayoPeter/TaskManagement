<h1 align="center">Task Management-Application</h1>
<h3 align="center">This is a backend C# application created with .Net8. The application allows users to create, read, update and delete task.</h3>

# Features
1. Create users
2. Login users
3. Manage Task through CRUD operations (Create, Read, Update, Delete).
4. Utilize MySQL database for data storage.
5. User authentication using JWT tokens
6. Swagger for Api documentation 

# Technologies Used
1. C#
2. .NET 8
3. MySQL Database
4. JWT auth
5. Swagger

# Prerequisites
Before running the application, make sure you have the following software installed:

.Net 8
<br/>
Visual studio
<br/>
Mysql server
<br/>
Microsoft sql management studio

# Getting Started
To get started with the Task management Application, follow these steps:

Clone the repository:
git clone https://github.com/IfedayoPeter/TaskManagement

using cmd navigave to project folder and run dotnet build to install the necessary dependencies

bash Copy code dotnet restore

Install wscat:
npm install -g wscat

run your project with visual studio

using cmd, connect to web socket to stream data created in real time:
wscat -c ws://localhost:5259/ws

Access the application in your web browser:
http://localhost:5259/swagger/index.html

# Configuration
The application uses the default configuration provided by .Net. However, if you need to modify any settings, you can do so in the application.json file located in the root folder of the project.

# Database
The application utilizes MySQL database. You can access the database from Microsoft sql management studio.
On MSSMS run the database script(TaskManagement_db_script) file located in the root folder of the project to setup database. 

# API Endpoints
http://localhost:5259/swagger/index.html
The following API endpoints are available for interacting with the application:

POST /createuser: create user account.
<br>
POST /UserLogin: login with email and password to generate bearer token for authorization on Task endpoints.
<br>
GET /getAllTask
<br/>
GET /getAllTaskById
<br/>
POST /createTask
<br/>
PUT /updateTask
<br/>
DELETE /deleteTask

Please refer to the source code for more details on the API implementation.
