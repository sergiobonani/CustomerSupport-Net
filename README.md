# CustomerSupport-Net

# Backend: .Net 6 (core) e SQL Server

It was implemented a CRUD structure. The idea was follow development patterns, so this project is separated in layers, trying to isolate each part and their responsibilities.

The database used is SQL Server, but we can change if it needs. I prefered to follow with EF and migration, so this part is almost all automated.

##### Backend Progress
- Create, Update, Delete and List are usable
- Initial validation 
- Swagger can be used, just use localhost:PORT/ 
- There is a project called "Resource", the idea is put all words the words there. If need, next step would be the internationalization. This way is easier to put another language without change everything in the projects.

##### What do need to finish?
Tests: to implement tests using XUnit. Validate fields, and validate CRUD
Review

# Frontend (Angular)

It was implemented a CRUD structure. The idea was follow patterns as create components, separeted fields, rules and tests.
The language used is Angular 14.* and Agular Material 14.*.

##### Frontend progress
- Grid (customer list)
- Add/Update/Delete
- Initial field validations 
- Initial Alerts/popup about informations (errors, sucess, etc)

##### What do need to finish?
Tests: First tests was done, but it needs to implement more and specifics tests (main about field validation)
Alerts/popup: To improve this part, making it clearer
Style

# Requirements to use
- Visual Studio (or Docker)
- SQL Server
- Node


# How to use Backend?
- If you need, change the DB connection string in CustomerSupport.API/appsettings.json
- By default the migrations are automatic (if you prefer to run manual just comment startup.cs lines 75 to 79), so you need just run the application in VS.

- Or if you prefer, you can run with docker. 
	In this case the Dockerfile is in CustomerSupport file.
	You need run *docker-compose build*, after that *docker-compose up*. That's it, the app and DB are ready!	
	Maybe you need to change the connection string in CustomerSupport.API/appsettings.json, because by default the user is *sa* and password *Your_password123* (same password in docker-compose)
	If you want to use with frontEnd, check *apiUrl* in environment. If need to change the port.

# How to use Frontend?
- The project is CustomerSupport.Client. This project is not linked to the backend, this is you can use separeted.
	Check *apiUrl* in environment. If need to change the port. 
- Just run with 'npm run'
