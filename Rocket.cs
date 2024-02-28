using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIContinuous.Nuenv;
using AIContinuous.Rocket;

namespace Rocket
{
    public class Rocket
    {
        public static double DryMass { get; set; }
        public static double Area { get; set; }
        public static double Ve { get; set; }
        public static double Cd0 { get; set; }
        public static double Height { get; set; }
        public static double Velocity { get; set; }
        public static double Mass { get; set; }
        public double[] TimeData { get; set; }
        public double[] MassFlowData { get; set; }
        public double Time { get; set; }

        public Rocket(
            double dryMass,
            double area,
            double ve,
            double cd0,
            double[] timeData,
            double[] massFlowData
            )
        {
            DryMass = dryMass;
            Area = area;
            Ve = ve;
            Cd0 = cd0;
            TimeData = (double[])timeData.Clone();
            MassFlowData = (double[])massFlowData.Clone();

            Time = 0.0;

            Mass = DryMass + Integrate.Romberg(TimeData, MassFlowData);
        }

        public double CalculateMassFlow(double t)
            => (t > TimeData[^1]) ? DryMass : Interp1D.Linear(TimeData, MassFlowData, t);

        public static double CalculateGravity(double h, double m)
            => -1.0 * m * Gravity.GetGravity(h);


        public double CalculateDrag(double height, double v)
        {
            var temperature = Atmosphere.Temperature(height);
            var cd = Drag.Coefficient(v, temperature, Cd0);
            var density = Atmosphere.Density(height);

            return -0.5 * cd * density * Area * (v * v) * Math.Sign(v);
        }

        public double CalculateThrustForce(double t)
            => (t > TimeData[^1]) ? 0.0 : CalculateMassFlow(t) * Ve;

        public double Momentum(double t)
        {
            var thrust = CalculateThrustForce(t);
            var drag = CalculateDrag(Velocity, Height);
            var weight = CalculateGravity(Height, Mass);

            return (thrust + drag + weight) / Mass;
        }

        public void UpdateVelocity(double t, double dt)
        {
            var accel = Momentum(t);
            Velocity = accel * dt;
        }

        public void UpdateHeight(double dt)
        {
            Height += Velocity * dt;
        }

        public void UpdateMass(double t, double dt)
        {
            Mass -= 0.5 * dt * (CalculateMassFlow(t) + CalculateMassFlow(t + dt));
        }

        public void FlyALittleBit(double dt)
        {
            UpdateVelocity(Time, dt);
            UpdateHeight(dt);
            UpdateMass(Time, dt);

            Time += dt;
        }

        public double Launch(double time, double dt = 1e-1)
        {
            for (double t = 0; t < time; t += dt)
                FlyALittleBit(dt);

            return Height;
        }

        public double LaunchUntilMax(double dt = 1e-1)
        {
            do FlyALittleBit(dt);
            while (Velocity > 0.0);

            return Height;
        }

        public double LaunchUntilGround(double dt = 1e-1)
        {
            do FlyALittleBit(dt);
            while (Height > 0.0);

            return Height;
        }
    }
}