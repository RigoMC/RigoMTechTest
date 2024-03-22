# RigoMTechTest
Technical test for MTech

# Features
- Persist Employees to a data store: 
The API can store data on In memory database, MySQL and SQL server

- Validate uniqueness of an employee (uniqueness is defined by RFC):  
The model have the conditions to emplement an index unique on RFC.

- Validate RFC Format and length:
The model have the restrictions to validate the length and format using a regex.

- Retrieve Employees sorted by born date and filtered optionally by name:
The API count with an endpoint for this porpuse, you just past and string with the name to get all
the employees who have a name that contains the string given.


# Technologies Used
- UI: Basic HTML, JS file.
- Backend: ASP.NET CORE WEB API
