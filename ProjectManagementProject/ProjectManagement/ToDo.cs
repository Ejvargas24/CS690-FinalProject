namespace ProjectManagement;
using System;
using System.IO;

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