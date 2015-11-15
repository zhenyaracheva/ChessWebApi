namespace Chess.Models
{
    using Data.Common;
    using System;
    using System.Collections.Generic;

    public class Board
    {
        private ICollection<Position> positions;
        private ICollection<Figure> figures;

        public Board()
        {
            this.figures = new HashSet<Figure>();
            this.positions = new HashSet<Position>();
        }
        
        public int Id { get; set; }

        public virtual ICollection<Position> Positions
        {
            get { return this.positions; }
            set { this.positions = value; }
        }

        public virtual ICollection<Figure> Figures
        {
            get { return this.figures; }
            set { this.figures = value; }
        }

       // private  void InitializeStartGameBoard()
       // {
       //     var figureIndex = 0;
       //     var firstPlayerRow = GlobalConstants.StandatdBoardGameSize -GlobalConstants.InitialRowsWithFigures + 1;
       // 
       //     for (int secondPlayerRow = 0; secondPlayerRow <2; secondPlayerRow++)
       //     {
       //         for (int col = 0; col < 8; col++)
       //         {
       //             var currentFigureType = GlobalConstants.StartFigureOrderStandartGame[figureIndex];
       //             this.SetFigure(new Position(firstPlayerRow, col), (IFigure)Activator.CreateInstance(currentFigureType, FigureColor.White));
       //             this.SetFigure(new Position(secondPlayerRow, col), (IFigure)Activator.CreateInstance(currentFigureType, FigureColor.Black));
       //             figureIndex++;
       //         }
       // 
       //         firstPlayerRow--;
       //     }
       // }
    }
}
