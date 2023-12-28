//Inits the main menu, which in turn runs the program. 

using Contactbook.Interfaces;
using Contactbook.Services;

IMenuServices menuService = new MenuServices();

menuService.ShowMainMenu();


