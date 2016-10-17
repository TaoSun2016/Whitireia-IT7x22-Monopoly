namespace Monopoly
{

    /// <summary>
    /// Interface for games
    /// </summary>
    
    interface GameInterface
    {
        void initializeGame();
        void makePlay(int player);
        bool endOfGame();
        void printWinner();
        void playOneGame(int playersCount);
     }
}
