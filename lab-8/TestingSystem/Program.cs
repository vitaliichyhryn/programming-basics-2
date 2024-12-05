namespace TestingSystem;

public class Program
{
    public static void Main()
    {
        var systemMenu = new TestingSystemMenu();
        do
        {
            Console.Write("Command: ");
            try
            {
                var command = TestingSystemMenu.GetCommand(Console.ReadLine());
                systemMenu.ExecuteCommand(command);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        } while (!systemMenu.ExitFlag);
    }
}