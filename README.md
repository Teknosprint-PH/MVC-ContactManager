# MVC-ContactManager

MVC Contact Manager

## Code Structure

### Controllers
- Responsible for generating the response to the browser request.
- In this project we have only one(1) controller present (HomeController.cs).

### Data
- Maps the .NET entities to database tables.
- Allows you to interact with the database using .NET objects, enabling object-relational mapping (ORM).
- Provides a way to perform Create, Read, Update, and Delete (CRUD) operations on the database.

### Migrations
- Contains migration files that track changes made to your database schema.
- Instead of manually writing SQL scripts, you define your data model in code, and migrations generate the necessary SQL to update the database.

### Models
- Define the structure of the data that your application works with.
- Contain validation logic to ensure that the data being handled meets certain criteria before it is processed or stored in the database.

### Views
- Take the data provided by the controller and render it as HTML to be displayed in the user's browser.

