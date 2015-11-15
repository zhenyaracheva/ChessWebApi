namespace Chess.Models
{
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
    }
}
