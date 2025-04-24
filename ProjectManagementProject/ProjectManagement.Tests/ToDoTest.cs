namespace ProjectManagement.Tests;

using ProjectManagement;


public class ToDoTest
{
    ToDo TDTest;
    string TestFileName;
    public ToDoTest(){
        TDTest = new ToDo();
        TestFileName = "doc.txt";
    }


    [Fact]
    public void TestAdd()
    {
        TDTest.ToDoAdd();
        string testwrite = "Add this to the file";
        File.AppendAllText(TestFileName, "," + testwrite);
        Assert.Equal(testwrite, File.ReadAllText(TestFileName));

    }
}
