namespace TestingSystem;

public class TestingSystemMenu : Menu
{
    public enum Commands
    {
        Help,
        AddTest,
        RemoveTest,
        ManageTest,
        TakeTest,
        ListTests,
        Quit
    }
    
    private static void ListCommands()
    {
        Console.WriteLine($"List of commands:\n" +
                          $"\tHelp\n" +
                          $"\tAddTest\n" +
                          $"\tRemoveTest\n" +
                          $"\tManageTest\n" +
                          $"\tTakeTest\n" +
                          $"\tListTests\n" +
                          $"\tQuit");
    }
    
    public static Commands GetCommand(string command)
    {
        return command switch
        {
            "Help" => Commands.Help,
            "AddTest" => Commands.AddTest,
            "RemoveTest" => Commands.RemoveTest,
            "ManageTest" => Commands.ManageTest,
            "TakeTest" => Commands.TakeTest,
            "ListTests" => Commands.ListTests,
            "Quit" => Commands.Quit,
            _ => throw new ArgumentException($"Command \"{command}\" is not defined")
        };
    }
    
    public void ExecuteCommand(Commands commands)
    {
        switch (commands)
        {
            case Commands.Help:
                ListCommands();
                break;
            
            case Commands.AddTest:
                TestingSystem.AddTest();
                break;
            
            case Commands.RemoveTest:
                TestingSystem.RemoveTest();
                break;
            
            case Commands.ManageTest:
                TestingSystem.ManageTest();
                break;
            
            case Commands.TakeTest:
                TestingSystem.TakeTest();
                break;
            
            case Commands.ListTests:
                TestingSystem.ListTests();
                break;
            
            case Commands.Quit:
                ExitFlag = true;
                break;
        }
    }
}