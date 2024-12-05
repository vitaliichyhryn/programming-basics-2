namespace TestingSystem;

public class QuestionMenu : Menu
{
    public enum Commands
    {
        Help,
        EditText,
        AddAnswer,
        RemoveAnswer,
        EditAnswer,
        ListAnswers,
        Quit
    }
    
    private static void ListCommands()
    {
        Console.WriteLine($"List of commands:\n" +
                          $"\tHelp\n" +
                          $"\tEditText\n" +
                          $"\tAddAnswer\n" +
                          $"\tRemoveAnswer\n" +
                          $"\tEditAnswer\n" +
                          $"\tManageAnswer\n" +
                          $"\tListAnswers\n" +
                          $"\tQuit");
    }
    
    public static Commands GetCommand(string command)
    {
        return command switch
        {
            "Help" => Commands.Help,
            "EditText" => Commands.EditText,
            "AddAnswer" => Commands.AddAnswer,
            "RemoveAnswer" => Commands.RemoveAnswer,
            "EditAnswer" => Commands.EditAnswer,
            "ListAnswers" => Commands.ListAnswers,
            "Quit" => Commands.Quit,
            _ => throw new ArgumentException($"Command \"{command}\" is not defined")
        };
    }

    public void ExecuteCommand(Commands command, Question question)
    {
        switch (command)
        {
            case Commands.Help:
                ListCommands();
                break;
            
            
            case Commands.EditText:
                question.EditText();
                break;
            
            case Commands.AddAnswer:
                question.AddAnswer();
                break;

            case Commands.RemoveAnswer:
                question.RemoveAnswer();
                break;
            
            case Commands.EditAnswer:
                question.EditAnswer();
                break;
            
            case Commands.ListAnswers:
                question.ListAnswers();
                break;

            case Commands.Quit:
                ExitFlag = true;
                break;
        }
    }
}