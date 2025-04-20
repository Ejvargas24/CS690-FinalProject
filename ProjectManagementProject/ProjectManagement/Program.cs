namespace ProjectManagement;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

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
            Console.WriteLine("*********");
            Console.WriteLine("Reminders:");
            myToDo.ToDoView();
            //Console.WriteLine("\n");
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
        Console.WriteLine("2. View each email in categories");
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
            using (StreamWriter file = new StreamWriter("WebCat.txt",true)){
                file.WriteLine(emailWrite);
            }
        }
        if (labelAnswer == "2"){
            Console.WriteLine("Add the email here:");
            emailWrite = Console.ReadLine();
            using (StreamWriter file = new StreamWriter("InvCat.txt",true)){
            file.WriteLine(emailWrite);
            }
        }
         if (labelAnswer == "3"){
            Console.WriteLine("Add the email here:");
            emailWrite = Console.ReadLine();
            using (StreamWriter file = new StreamWriter("RevCat.txt",true)){
            file.WriteLine(emailWrite);
            }
        }

    }

    public void emailCategories(){
        Console.WriteLine("The emails in each category are:");
        Console.WriteLine("------------------------------");
        Console.WriteLine("Web Design:");
        try{
            string webCatEmails = File.ReadAllText("WebCat.txt");
            string[] result = webCatEmails.Split("\n");
            Console.WriteLine("------------------------------");
            foreach(var element in result) {
            Console.WriteLine(element);
         }
         Console.WriteLine("------------------------------");

        }catch(FileNotFoundException e){
            Console.WriteLine("There are no emails in this category");
        }
        Console.WriteLine("Invoices:");
        try{
            string invCatEmails = File.ReadAllText("InvCat.txt");
            string[] result = invCatEmails.Split("\n");
            Console.WriteLine("------------------------------");
            foreach(var element in result) {
            Console.WriteLine(element);
         }
         Console.WriteLine("------------------------------");
        }catch(FileNotFoundException e){
            Console.WriteLine("There are no emails in this category");
        }
        Console.WriteLine("Revisions:");
        try{
            string revCatEmails = File.ReadAllText("RevCat.txt");
            string[] result = revCatEmails.Split("\n");
            Console.WriteLine("------------------------------");
            foreach(var element in result) {
            Console.WriteLine(element);
         }
        }catch(FileNotFoundException e){
            Console.WriteLine("There are no emails in this category");
        }
        //Console.WriteLine("------------------------------");
    }

 }



 public class Project{

    public Project(){

    }
    
    public void ProjectOptionDisplay(){
        Console.WriteLine("Please choose an option:");
        Console.WriteLine("1. Add a project:");
        Console.WriteLine("2. View deadlines and income:");
        Console.WriteLine("3. Back");
    }

    public string ProjectOption(){
        string ProjectAnswer;
        ProjectAnswer = Console.ReadLine();
        return ProjectAnswer;
    }

    public void ProjectDisplay(){
        try{
            List<string> DeadLineTextStr = File.ReadLines("Deadline.txt").ToList();
            foreach(var element in DeadLineTextStr){
            Console.WriteLine(element);
        }
       
        }catch(FileNotFoundException e){
            Console.Write("There are no projects\n");
            using (File.Create("Deadline.txt")); 
        }
    }

    public void AddProject(){
        string projectName;
        string projectDeadline;
        string projectIncome;
        double totalIncome=0;

        Console.WriteLine("Please enter the name of the project:");
        projectName = Console.ReadLine();
        Console.WriteLine("Please enter the number of days for the deadline");
        projectDeadline = Console.ReadLine();
        Console.WriteLine("Please enter the amount income received for project completion");
        projectIncome = Console.ReadLine();
        
        if (File.Exists("Deadline.txt") == false){
            using (File.Create("Deadline.txt")); 
        }
        List<string> DeadLineTextStr = File.ReadLines("Deadline.txt").ToList();
        using (StreamWriter file = new StreamWriter("Deadline.txt")){
            if(DeadLineTextStr.Count>0){

                string totalStr = DeadLineTextStr[DeadLineTextStr.Count-1];
                string[] splitTotal = totalStr.Split(' ');
                double total = double.Parse(splitTotal[8]);
                totalIncome = total + double.Parse(projectIncome);
                DeadLineTextStr.RemoveAt(DeadLineTextStr.Count-1);
            }
            else{
                totalIncome = double.Parse(projectIncome);
            }
            DeadLineTextStr.Add(String.Format("Project: {0} || Days until deadline: {1} || Income awaiting: {2} dollars",projectName, projectDeadline,projectIncome));
            DeadLineTextStr.Add(String.Format("The total income from the projects would be: {0} dollars",totalIncome));
            foreach(var element in DeadLineTextStr){
                file.WriteLine(element);
            }
        }
        
        
        
    }

}

public class ToDo{

    string newTask;
    string contentsOfList;
    string taskToRemove;
    string ToDoAnswer;



    public ToDo(){

    }


    public void ToDoDisplay(){
        Console.WriteLine("Please choose an option:");
        Console.WriteLine("1. Add a task:");
        Console.WriteLine("2. Remove a task:");
        Console.WriteLine("3. View list");
        Console.WriteLine("4. Back");
    }

    public string ToDoOption(){
        ToDoAnswer = Console.ReadLine();
        return ToDoAnswer;
    }
    public void ToDoAdd(){
        Console.WriteLine("Task to add:");
        newTask = Console.ReadLine();
        File.AppendAllText("ToDo.txt",","+newTask);
    }

    public void ToDoRemove(){

        contentsOfList = File.ReadAllText("ToDo.txt");
        string[] result = contentsOfList.Split(",");
        foreach(var element in result) {
            Console.WriteLine(element);
        }
        List<string> listVersion = result.ToList();
        Console.WriteLine("Write which task to remove:");
        taskToRemove = Console.ReadLine();
        listVersion.Remove(taskToRemove);
        File.Delete("ToDo.txt");
        string concatenateRemove = String.Join(",", listVersion);
        Console.WriteLine("The new list of tasks:");
        Console.WriteLine(concatenateRemove);
        File.WriteAllText("ToDo.txt",concatenateRemove);
    }

    public void ToDoView(){
        try{
            contentsOfList = File.ReadAllText("ToDo.txt");
            string[] result = contentsOfList.Split(",");
            foreach(var element in result) {
                Console.WriteLine(element);
            }
        }catch(FileNotFoundException e){
            Console.WriteLine("The To-Do list is currently empty");
        }
        
    }

}

