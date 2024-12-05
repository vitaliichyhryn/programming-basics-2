using System.Globalization;

namespace TestingSystem;

public static class TestingSystem
{
    public static List<Test> Tests { get; } = new();

    public static void AddTest()
    {
        Console.Write("Test name: ");
        var name = Console.ReadLine();
        var test = new Test(name);
        test.AddQuestions();
        Tests.Add(test);
    }

    public static void RemoveTest()
    {
        var test = FindTest();
        Tests.Remove(test);
    }

    public static void ManageTest()
    {
        var test = FindTest();
        var testMenu = new TestMenu();
        do
        {
            Console.Write("Command: ");
            try
            {
                var command = TestMenu.GetCommand(Console.ReadLine());
                testMenu.ExecuteCommand(command, test);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        } while (!testMenu.ExitFlag);
    }

    public static void TakeTest()
    {
        var test = FindTest();
        test.GuessedAnswerCount = 0;
        Console.WriteLine($"Question time limit: {test.TimeLimit} seconds");
        var random = new Random();
        var shuffledQuestions = test.Questions.OrderBy(_ => random.Next()).ToList();
        for (var i = 0; i < shuffledQuestions.Count; i++)
        {
            var question = shuffledQuestions[i];
            Console.WriteLine($"Question {i + 1}: {question.Text}");
            test.GuessedAnswerCount += question.EvaluateAnswer();
            if (i != shuffledQuestions.Count - 1)
            {
                Console.Write("Proceed? [y/n]: ");
                var next = Console.ReadLine();
                if (next.Equals("n"))
                {
                    test.Taken = false;
                    test.GuessedAnswerCount = 0;
                    return;
                }
            }
        }
        test.Taken = true;
    }
    
    public static void ListTests()
    {
        for (var i = 0; i < Tests.Count; i++)
        {
            var test = Tests[i];
            Console.WriteLine(test.Taken
                ? $"Test {i + 1}: {test.Name} | Score: " + test.Score.ToString("P", CultureInfo.InvariantCulture)
                : $"Test {i + 1}: {test.Name}");
        }
    }

    private static Test FindTest()
    {
        ListTests();
        Console.Write("Test name: ");
        var name = Console.ReadLine();
        var test = Tests.Find(x => x.Name.Equals(name));
        return test;
    }
}