using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIContinuous.Rocket;

namespace Rocket 
{
    public class Rocket
    {
        public static double EmptyMass { get; set; } = 750;
        public static double FuelMass { get; set; } = 3500;
        public static double CurrentMass { get; set; } = EmptyMass + FuelMass;
        public static double Diameter { get; set; } = 0.6;
        public static double DragCoefficient { get; set; }
        public static double GasExhaustSpeed { get; set; }
        

        public static double Acceleration(double T, double D, double W, double m)
        {
            return (T + D + W) / m;
        }

        public static double Velocity(double a, double deltaT)
        {
            return a * deltaT;
        }

        public static double Altitude(double v, double deltaT)
        {
            return v * deltaT;
        }

        public static double ThrustForce(double Me, double Ve = 1916)
        {
            return Me * Ve;
        }

        public static double DragForce(double deltaT, double height, double vel, double vdir, double Cd = 0.8)
        {
            double density = Atmosphere.Density(height);

            double Area = Math.PI * Math.Pow(Diameter / 2, 2);

            return -(1/2) * Cd * density * Area * (vel * vel) * vdir;
        }

        public static double WeightForce(double currentMass, double currentHeight)
        {
            return -currentMass * Gravity.GetGravity(currentHeight);
        }

    }
}