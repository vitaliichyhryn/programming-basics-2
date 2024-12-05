namespace TestingSystem;

public class Test
{
    public string Name { get; set; }
    public List<Question> Questions { get; } = new ();
    public int QuestionCount => Questions.Count;
    public int TimeLimit { get; set; } = 120;
    public bool Taken { get; set; }
    private int CorrectAnswerCount => Questions.Sum(question => question.Answers.Count(answers => answers.Correct));
    public int GuessedAnswerCount { get; set; }
    public float Score => (float)GuessedAnswerCount / (float)CorrectAnswerCount;

    public Test(string name)
    {
        Name = name;
    }
    
    public void AddQuestion()
    {
        Console.Write("Question text: ");
        var text = Console.ReadLine();
        var question = new Question(text);
        question.AddAnswers();
        Questions.Add(question);
    }

    public void AddQuestions()
    {
        Console.Write("Number of questions: ");
        var number = int.Parse(Console.ReadLine());
        for (var i = 1; i <= number; i++)
        {
            Console.WriteLine($"Question {i}:");
            AddQuestion();
        }
    }

    public void RemoveQuestion()
    {
        var question = FindQuestionAt();
        Questions.Remove(question);
    }
    
    public void ManageQuestion()
    {
        var question = FindQuestionAt();
        var questionMenu = new QuestionMenu();
        do
        {
            Console.Write("Command: ");
            try
            {
                var command = QuestionMenu.GetCommand(Console.ReadLine());
                questionMenu.ExecuteCommand(command, question);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        } while (!questionMenu.ExitFlag);
    }

    public void EditName()
    {
        Console.Write("Name: ");
        var name = Console.ReadLine();
        Name = name;
    }
    
    public void EditTimeLimit()
    {
        Console.Write("Question time limit: ");
        var timeLimit = int.Parse(Console.ReadLine());
        TimeLimit = timeLimit;
    }
    
    public void ListQuestions()
    {
        for (var i = 0; i < Questions.Count; i++)
        {
            Console.WriteLine($"Question {i + 1}: {Questions[i].Text}");
        }
    }

    public Question FindQuestionAt()
    {
        ListQuestions();
        Console.Write("Question index: ");
        var index = int.Parse(Console.ReadLine());
        var question = Questions[index - 1];
        return question;
    }
}

public class Question
{
    public string Text { get; set; }
    public List<Answer> Answers { get; private set; } = new();

    public Question(string text)
    {
        Text = text;
    }

    public void EditText()
    {
        Console.Write("Question text: ");
        var text = Console.ReadLine();
        Text = text;
    }

    public void AddAnswer()
    {
        Console.Write("Answer text: ");
        var text = Console.ReadLine();
        var answer = new Answer(text);
        Console.Write("Correct? [y/n]: ");
        var correct = Console.ReadLine();
        answer.Correct = correct switch
        {
            "y" => true,
            "n" => false,
        };
        Answers.Add(answer);
    }
    
    public void AddAnswers()
    {
        Console.Write("Number of answers: ");
        var number = int.Parse(Console.ReadLine());
        for (var i = 1; i <= number; i++)
        {
            Console.WriteLine($"Answer {i}:");
            AddAnswer();
        }
    }
    
    public void RemoveAnswer()
    {
        var answer = FindAnswerAt();
        Answers.Remove(answer);
    }

    public void EditAnswer()
    {
        var answer = FindAnswerAt();
        Console.Write("Answer text: ");
        var text = Console.ReadLine();
        answer.Text = text;
        Console.Write("Correct? [y/n]: ");
        var correct = Console.ReadLine();
        answer.Correct = correct switch
        {
            "y" => true,
            "n" => false,
        };
    }
    
    public void ListAnswers()
    {
        for (var i = 0; i < Answers.Count; i++)
        {
            var answer = Answers[i];
            Console.WriteLine(answer.Checked
                ? $"[+] Answer {i + 1}: {answer.Text}"
                : $"[] Answer {i + 1}: {answer.Text}");
        }
    }
    
    private static void ListAnswersFromList(List<Answer> answers)
    {
        for (var i = 0; i < answers.Count; i++)
        {
            var answer = answers[i];
            Console.WriteLine(answer.Checked
                ? $"[+] Answer {i + 1}: {answer.Text}"
                : $"[] Answer {i + 1}: {answer.Text}");
        }
    }

    private Answer FindAnswerAt()
    {
        ListAnswers();
        Console.Write("Index of answer: ");
        var index = int.Parse(Console.ReadLine());
        var answer = Answers[index - 1];
        return answer;
    }

    public int EvaluateAnswer()
    {
        var submitted = false;
        var guessedAnswerCount = 0;
        var random = new Random();
        var shuffledAnswers = Answers.OrderBy(_ => random.Next()).ToList();
        do
        {
            ListAnswersFromList(shuffledAnswers);
            Console.Write("Index of correct answer: ");
            var index = int.Parse(Console.ReadLine());
            var guessedAnswer = shuffledAnswers[index - 1];
            guessedAnswer.Checked = true;
            ListAnswersFromList(shuffledAnswers);
            Console.Write("Submit? [y/n]: ");
            var submit = Console.ReadLine();
            if (submit == "y")
                submitted = true;
        } while (!submitted);
        foreach (var answer in shuffledAnswers)
        {
            if (answer.Checked && answer.Correct)
                guessedAnswerCount += 1;
            answer.Checked = false;
        }
        
        return guessedAnswerCount;
    }
}

public class Answer
{
    public string Text { get; set; }
    public bool Correct { get; set; }
    public bool Checked { get; set; }

    public Answer(string text)
    {
        Text = text;
    }
}