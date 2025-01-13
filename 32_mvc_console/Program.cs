using System.Data.SQLite;

var db = new Database();
var view = new UserView(db);
var controller = new UserController(db, view);
controller.MainMenu();