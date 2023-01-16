using System;
namespace src.Constante
{
    public class Const
    {
        //Ici on déclare la gravité (là 9.81 car c'est celle de la terre 9.81 m/s)
        private const double _gravity = 9.81;
        public double gravity
        {
            get => _gravity;
        }
        // Ici on a le calcul du vecteur pour l'angle dans lequel l'objet va
        public (double, double) GenerateVectorDirection(double angle, double speed)
        {
            double angleRad = angle * Math.PI / 180;
            double x = speed * Math.Cos(angleRad);
            double y = speed * Math.Sin(angleRad);
            return (x, y);
        }
        //Ici on calcule la distance entre l'objet et le sol de notre planète
        public double generateDistance(double x1, double y1, double planetDiameter, double x2, double y2)
        {
            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)) - (planetDiameter / 2);
            return distance;
        }
        // Ici notre force gravitationnelle qui va agir sur la chute de l'objet
        public double generateGravityStrength(double objWeight, double planetWeight, double distance)
        {
            double gravity = (planetWeight * objWeight) / Math.Pow(distance, 2);
            return gravity;
        }
        // ici le calcul qu'on va utiliser deux fois pour les composants gravitationnels de x et de y
        public double CalculateGravityComposantX(double gravity, double objX, double planetX, double distance)
        {
            double gravityX = (gravity * (planetX - objX)) / distance;
            return gravityX;
        }
        // Là on a l'accélération de l'objet grâce aux composants gravitationnels X et Y calculés grâce à la méthode du dessus
        public (double, double) CalculateAcceleration(double gravityX, double gravityY, double objweight)
        {
            double accelerationX = gravityX / objweight;
            double accelerationY = gravityY / objweight;
            return (accelerationX, accelerationY);
        }

        // cette métode nous permet d'obtenir la position de l'objet en fonction du temps, grâce auc calculs effectués au dessus.
        public (double, double) CalculatePosition(double objX, double objY, double vectorX, double vectorY, double t, double gravity, double accelerationX, double accelerationY)
        {
            double posX = objX + vectorX * t + 0.5 * accelerationX * Math.Pow(t, 2);
            double posY = objY + vectorY * t + 0.5 * accelerationY * Math.Pow(t, 2) - 0.5 * gravity * Math.Pow(t, 2);
            return (posX, posY);
        }
    }
}