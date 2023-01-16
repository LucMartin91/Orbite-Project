using src.PositionName;

namespace src.Obj
{
    public class ObjectClass
    {
        private double _weight;
        public double weight
        {
            get => _weight;
            set => _weight = value;
        }

        private Position _position;
        public Position position
        {
            get => _position;
            set => _position = value;
        }

        // Constructeur de la classe
        public ObjectClass(double weight, Position position)
        {
            this.weight = weight;
            this.position = position;
        }
    }
}