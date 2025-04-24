namespace ProjectManagement;
using System;

public class ConsoleUI{


    string writtenEmail;
    string userSelection;

    public ConsoleUI(){
        Email myEmail = new Email();
        Project myProject = new Project();
        ToDo myToDo = new ToDo();
        do{
            Console.WriteLine("*********");
            Console.WriteLine("Reminders:");
            myToDo.ToDoView();
            Console.WriteLine("*********");
            Console.WriteLine("Please select a feature:");
            Console.WriteLine("1. Email");
            Console.WriteLine("2. Project");
            Console.WriteLine("3. To-Do List");
            Console.WriteLine("4. Exit");
            userSelection = Console.ReadLine();
        while(true){
            if(userSelection =="1"){
                myEmail.Display();
                string result = myEmail.emailOption();
                if(result == "1"){
                    myEmail.labelEmail();}
                else if(result == "2"){
                    myEmail.emailCategories();}
                else if(result == "3"){
                    break;
                }
            }

            else if(userSelection == "2"){
                myProject.ProjectOptionDisplay();
                string result = myProject.ProjectOption();
                if(result == "1"){
                    myProject.AddProject();
                }
                else if(result == "2"){
                    myProject.ProjectDisplay();
                }
                else if(result == "3"){
                    break;
                }
            }

            else if (userSelection == "3"){
                myToDo.ToDoDisplay();
                string result = myToDo.ToDoOption();
                if(result == "1"){
                    myToDo.ToDoAdd();
                }
                else if(result == "2"){
                    myToDo.ToDoRemove();
                }
                else if(result == "3"){
                    myToDo.ToDoView();
                }
                else if(result == "4"){
                    break;
                }
            }
            else{
                break;
            }
        }
            
        }while(userSelection !="4");
        Console.WriteLine("Goodbye!");
    }
}