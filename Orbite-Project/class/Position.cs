using System;

namespace src.PositionName
{
    public class Position
    {
        private double _x;
        public double x
        {
            get => _x;
            set => _x = value;
        }

        private double _y;
        public double y
        {
            get => _y;
            set => _y = value;
        }

        // Constructeur de la classe
        public Position(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

    }
}