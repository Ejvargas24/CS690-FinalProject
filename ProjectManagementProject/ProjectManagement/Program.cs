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
            //myEmail.labelEmail();
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
        Console.WriteLine("3. Exit");
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
