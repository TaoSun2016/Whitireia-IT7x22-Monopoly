namespace Monopoly
{
    /// <summary>
    /// Main class for the program
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Monopoly();
            game.initializeGame();    
        }
    }
}
