namespace ProjectManagement;
using System;
using System.IO;
class Program
{
    string userSelection;
    string writtenEmail;
    
    
    static void Main(string[] args)
    {
      
        Email myEmail = new Email();
        Project myProject = new Project();
        ToDo myToDo = new ToDo();

        //emailSaver emailSaver = new emailSaver("emails.txt");

        string userSelection;
        do{
            Console.WriteLine("***THIS IS FOR THE REMINDERS");
            Console.WriteLine("Please select a feature:");
            Console.WriteLine("1. Email");
            Console.WriteLine("2. Project");
            Console.WriteLine("3. To-Do List");
            Console.WriteLine("4. Exit");
            userSelection = Console.ReadLine();
        
            if(userSelection=="1"){
                myEmail.Display();
                string result = myEmail.emailOption();
                if(result == "1"){
                    myEmail.labelEmail();}
                else if(result == "2"){
                    myEmail.emailCategories();}
            }

            else if(userSelection=="2"){
                myProject.ProjectOptionDisplay();
                string result = myProject.ProjectOption();
                if(result == "1"){
                    myProject.ProjectDeadLineAdd();
                }
                else if(result == "2"){
                    myProject.ProjectIncomeAdd();
                }
                else if(result == "3"){
                    myProject.ProjectDeadlineDisplay();
                }
                else if(result == "4"){
                    myProject.ProjectIncomeDisplay();
                }
            }

            else if (userSelection=="3"){
                myToDo.ToDoDisplay();
            }

        }while(userSelection !="4");
        
    }
}
 public class Email{
    string emailAnswer;
    string emailWrite;
    string labelAnswer;
    List<string> WebList = new List<string>();
    List<string> RevisionsList = new List<string>();
    List<string> InvoicesList = new List<string>();
    public Email(){
    }

    public void Display(){
        Console.WriteLine("Please choose an option:");
        Console.WriteLine("1. Add Email");
        Console.WriteLine("2. View Categories");
        Console.WriteLine("3. Back");
    }
    public string emailOption(){
        emailAnswer = Console.ReadLine();
        return emailAnswer;
    }

    public void labelEmail(){
        Console.WriteLine("Please choose a category for the email:");
        Console.WriteLine("1. Web Design");
        Console.WriteLine("2. Invoices");
        Console.WriteLine("3. Revisions");
        labelAnswer = Console.ReadLine();
        if (labelAnswer == "1"){
            Console.WriteLine("Add the email here:");
            emailWrite = Console.ReadLine();
            WebList.Add(emailWrite);
        }
        if (labelAnswer == "2"){
            Console.WriteLine("Add the email here:");
            emailWrite = Console.ReadLine();
            InvoicesList.Add(emailWrite);
        }
         if (labelAnswer == "3"){
            Console.WriteLine("Add the email here:");
            emailWrite = Console.ReadLine();
            RevisionsList.Add(emailWrite);
        }

    }

    public void emailCategories(){
        Console.WriteLine("The emails in each category are:");
        Console.WriteLine("Web Design:");
        foreach(var element in WebList){
            Console.WriteLine(element);
        }
        Console.WriteLine("------------------------------");
        Console.WriteLine("Invoices:");
        foreach(var element in InvoicesList){
            Console.WriteLine(element);
        }
        Console.WriteLine("------------------------------");
        Console.WriteLine("Revisions:");
        foreach(var element in RevisionsList){
            Console.WriteLine(element);
        }
        Console.WriteLine("------------------------------");
    }

 }



 public class Project{
    string projectName;
    string projectDeadline;
    string projectIncome;
    string ProjectAnswer;

    string textString = "";

    //List<string> DeadlineList = new List<string>();
    Dictionary<string, string> DeadLineDict = new Dictionary<string, string>();
    Dictionary<string, string> IncomeDict = new Dictionary<string, string>();
    //List<string> IncomeList = new List<string>();
    public Project(){

    }
    
    public void ProjectOptionDisplay(){
        Console.WriteLine("Please choose an option:");
        Console.WriteLine("1. Add a project and deadline:");
        Console.WriteLine("2. Add a project and income:");
        Console.WriteLine("3. View project deadlines");
        Console.WriteLine("4. View income from projects");
        Console.WriteLine("5. Back");
    }

    public string ProjectOption(){
        ProjectAnswer = Console.ReadLine();
        return ProjectAnswer;
    }

    public void ProjectDeadLineAdd(){
        Console.WriteLine("Please enter the name of the project:");
        projectName = Console.ReadLine();
        Console.WriteLine("Please enter the number of days for the deadline");
        projectDeadline = Console.ReadLine();
        DeadLineDict.Add(projectName, projectDeadline);
        //Code to get the text file to work
        //using (StreamWriter file = new StreamWriter("Deadline.txt"))
        //foreach(var element in DeadLineDict){
        //    file.WriteLine("[{0} {1}]",element.Key, element.Value);
    
    } 

    public void ProjectIncomeAdd(){
        Console.WriteLine("Please enter the name of the project:");
        projectName = Console.ReadLine();
        Console.WriteLine("Please enter the amount income received for project completion");
        projectIncome = Console.ReadLine();
        IncomeDict.Add(projectName, projectIncome);
    }

    public void ProjectDeadlineDisplay(){
        //Code to get the text file to print
        //string contentsOfTheFile = File.ReadAllText("Deadline.txt");
        //string[] result = contentsOfTheFile.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        //while((textString = File.ReadLine()) != null){
        //   Console.WriteLine(textString);
        foreach(var element in DeadLineDict){
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine($"Project: {element.Key} || Deadline: {element.Value} days");
            Console.WriteLine("----------------------------------------------------------");
            }
    }

    public void ProjectIncomeDisplay(){
        foreach(var element in IncomeDict){
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine($"Project: {element.Key} || Income: {element.Value} dollars");
            Console.WriteLine("----------------------------------------------------------");
            }

    }    
}

public class ToDo{

    public ToDo(){

    }


    public void ToDoDisplay(){
        Console.WriteLine("Please choose an option:");
        Console.WriteLine("1. Add a task:");
        Console.WriteLine("2. Remove a task:");
        Console.WriteLine("3. View list");
        Console.WriteLine("4. Save list");
        Console.WriteLine("5. Back");
    }





}