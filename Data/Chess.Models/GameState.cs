namespace Chess.Models
{
    public enum GameState
    {
        WaitingForSecondPlayer = 0,
        TurnWhitePlayer = 1,
        TurnBlackPlayer = 2,
        WonWhitePlayer = 3,
        WonBlackPlayer = 4,
        DrawGame = 5
    }
}
