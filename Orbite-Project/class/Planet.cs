using src.Obj;

namespace src.PlanetName
{
    public class Planet
    {
        private double _diameter;
        public double diameter
        {
            get => _diameter;
            set => _diameter = value;
        }

        private ObjectClass _obj;
        public ObjectClass obj
        {
            get => _obj;
            set => _obj = value;
        }

        // Constructeur de la classe
        public Planet(double diameter, ObjectClass obj)
        {
            this.diameter = diameter;
            this.obj = obj;
        }
    }
}