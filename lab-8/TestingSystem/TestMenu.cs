namespace TestingSystem;

public class TestMenu : Menu
{
    public enum Commands
    {
        Help,
        EditName,
        EditTimeLimit,
        AddQuestion,
        RemoveQuestion,
        ManageQuestion,
        ListQuestions,
        Quit
    }
    
    private static void ListCommands()
    {
        Console.WriteLine($"List of commands:\n" +
                          $"\tHelp\n" +
                          $"\tEditName\n" +
                          $"\tEditTimeLimit\n" +
                          $"\tAddQuestion\n" +
                          $"\tRemoveQuestion\n" +
                          $"\tManageQuestion\n" +
                          $"\tListQuestions\n" +
                          $"\tQuit");
    }
    
    public static Commands GetCommand(string command)
    {
        return command switch
        {
            "Help" => Commands.Help,
            "EditName" => Commands.EditName,
            "EditTimeLimit" => Commands.EditTimeLimit,
            "AddQuestion" => Commands.AddQuestion,
            "RemoveQuestion" => Commands.RemoveQuestion,
            "ManageQuestion" => Commands.ManageQuestion,
            "ListQuestions" => Commands.ListQuestions,
            "Quit" => Commands.Quit,
            _ => throw new ArgumentException($"Command \"{command}\" is not defined")
        };
    }

    public void ExecuteCommand(Commands command, Test test)
    {
        switch (command)
        {
            case Commands.Help:
                ListCommands();
                break;
            
            case Commands.EditName:
                test.EditName();
                break;
            
            case Commands.EditTimeLimit:
                test.EditTimeLimit();
                break;
            
            case Commands.AddQuestion:
                test.AddQuestion();
                break;

            case Commands.RemoveQuestion:
                test.RemoveQuestion();
                break;
            
            case Commands.ManageQuestion:
                test.ManageQuestion();
                break;
            
            case Commands.ListQuestions:
                test.ListQuestions();
                break;

            case Commands.Quit:
                ExitFlag = true;
                break;
        }
    }
}