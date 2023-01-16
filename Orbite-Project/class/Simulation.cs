using src.PlanetName;
using src.Obj;
using src.PositionName;
using src.Constante;

namespace src.SimulationName
{
    public class Simulation
    {
        //La vitesse qu'on va définir au départ de notre programme
        private double _speed;
        public double speed
        {
            get => _speed;
            set => _speed = value;
        }
        //L'angle que l'on va set par la suite de la même façon
        private double _throwingAngle;
        public double throwingAngle
        {
            get => _throwingAngle;
            set => _throwingAngle = value;
        }

        //ici une fonction d'affichage de résultat que l'on va appeller à chaque tour de boucle
        public void showResult(double time, double distance, double posx, double posy)
        {
            Console.WriteLine("---------------------------------------------------------------------------\n" + "Position x : " + posx + "         Position y : " + posy + "\n");
            Console.WriteLine("time: " + time + " seconds\n");
            Console.WriteLine("heigth: " + distance + "\n");
        }

        // Là on rentre dans la boucle de fonctionnement du coeur de notre programme
        public void constructorSimulation(Planet planet, Position pos, double speed, double throwingAngle)
        {
            var constMethods = new Const(); // Une variable qui récupère tous les calculs de notre classe Const 
            this.speed = speed; // Une vitesse de départ définie en paramètres
            this.throwingAngle = throwingAngle; // Un angle de tir de départ, qui va nous servir pour le vecteur de direction à chaque tour de boucle

            Console.WriteLine("\nSimulation started with speed = " + speed + " and throwing angle = " + throwingAngle + "degrees \n");

            var t = 0; // On initialise la variable temps
            while (pos.y > 0) // Tant que la position y (verticale) de l'objet n'a pas atteint 0 (donc le sol ici), on continue.
            {
                //Ici on effectue tous les calculs de notre classe constante pour pouvoir mettre à jour nos positions x et y à chaque tour de boucle
                double distance = constMethods.generateDistance(pos.x, pos.y, planet.diameter, planet.obj.position.x, planet.obj.position.y);
                (double vectorX, double vectorY) = constMethods.GenerateVectorDirection(throwingAngle, speed);
                double gravityStrength = constMethods.generateGravityStrength(planet.obj.weight, Math.Pow(5.972 * 10, 24), distance);
                double gravityComponsantX = constMethods.CalculateGravityComposantX(gravityStrength, pos.x, planet.obj.position.x, distance);
                double gravityComponsantY = constMethods.CalculateGravityComposantX(gravityStrength, pos.y, planet.obj.position.y, distance);
                (double accelerationX, double accelerationY) = constMethods.CalculateAcceleration(gravityComponsantX, gravityComponsantY, planet.obj.weight);
                (double posX, double posY) = constMethods.CalculatePosition(pos.x, pos.y, vectorX, vectorY, t, constMethods.gravity, accelerationX, accelerationY);
                pos.x = posX;
                pos.y = posY;
                //si la position y est supérieure à 0 alors je refais un tour et j'affiche les résultats actuels
                if (pos.y > 0)
                    showResult(t, pos.y, pos.x, pos.y);
                // Sinon j'écris un message pour dire que c'est fini.
                else
                    Console.WriteLine("BOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOMMMM !!!!!!!!!\nDepth of hole : " + pos.y + "\n1s later than last screen");
                Thread.Sleep(1000); // On force les tours de boucle à se faire secondes par secondes (1000ms)
                t++;
            }
        }
    }
}