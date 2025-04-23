namespace ProjectManagement;
using System;
using System.IO;

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
            var orderedlist = DeadLineTextStr.OrderBy(x => int.Parse(x.Split(' ')[6])).ToList();
            orderedlist.Add(String.Format("The total income from the projects would be: {0} dollars",totalIncome));
            foreach(var element in orderedlist){
                file.WriteLine(element);
            }
        }
        
        
    }

}