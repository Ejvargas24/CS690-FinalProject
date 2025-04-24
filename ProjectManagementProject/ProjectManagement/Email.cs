namespace ProjectManagement;
using System;
using System.IO;
 
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
    }

 }
