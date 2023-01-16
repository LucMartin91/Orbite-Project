using src.SimulationName;
using src.PlanetName;
using src.Obj;
using src.PositionName;
// ici on appelle toutes les sources nécessiares

namespace src.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialisation des variables pour la simulation en passant par des inputs
            Console.WriteLine("Please entrer the weight of your object :");
            var objWeightinput = Console.ReadLine();
            if (!double.TryParse(objWeightinput, out double number))
            {
                Console.WriteLine("Please entrer A VALID WEIGHT FOR YOUR OBJECT :");
                objWeightinput = Console.ReadLine();
            }
            Console.WriteLine("Please entrer the X position of your object :");
            var objXPos = Console.ReadLine();
            if (!double.TryParse(objXPos, out double number2))
            {
                Console.WriteLine("Please entrer A VALID X POSITION FOR YOUR OBJECT :");
                objXPos = Console.ReadLine();
            }
            Console.WriteLine("Please entrer the Y position of your object :");
            var objYPos = Console.ReadLine();
            if (!double.TryParse(objYPos, out double number3))
            {
                Console.WriteLine("Please entrer A VALID Y POSITION FOR YOUR OBJECT :");
                objYPos = Console.ReadLine();
            }
            Console.WriteLine("Please entrer the speed (KM/S) of your object :");
            var speedinput = Console.ReadLine();
            if (!double.TryParse(speedinput, out double number4))
            {
                Console.WriteLine("Please entrer A VALID SPEED FOR YOUR OBJECT :");
                speedinput = Console.ReadLine();
            }
            Console.WriteLine("Please entrer the Throw angle of your object (180 MAX):");
            var throwinput = Console.ReadLine();
            if (int.Parse(throwinput) > 180 || int.Parse(throwinput) <= 0)
            {
                Console.WriteLine("Please entrer A VALID ANGLE FOR YOUR OBJECT :");
                throwinput = Console.ReadLine();
            }

            // Convertion du tout en doubles ( j'aurais pu éviter cette phase mais je trouve ça plus clair)
            double objWeight = double.Parse(objWeightinput);
            double objX = double.Parse(objXPos);
            double objY = double.Parse(objYPos);
            double planetDiameter = 10000;
            double speed = double.Parse(speedinput);
            double throwingAngle = double.Parse(throwinput);

            // Initialisation des classes utilisées pour la simulation
            var objPosition = new Position(objX, objY);
            var obj = new ObjectClass(objWeight, objPosition);
            var planet = new Planet(planetDiameter, obj);
            var simulation = new Simulation();

            // Lancement de la simulation qui agit en arrière plan dans Simulation.cs
            simulation.constructorSimulation(planet, objPosition, speed, throwingAngle);
        }
    }
}