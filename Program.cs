using AIContinuous.Nuenv;
using AIContinuous.Rocket;
using Desafio_Foguete.Search;
using Optimize;

// int numberOfPoints = 51;
// var timeData = Space.Geometric(1.0, 1001.0, numberOfPoints).Select(x => x - 1.0).ToArray();

// double Simulate(double[] massFlowData)
// {
//     var rocket = new Rocket.Rocket(
//         750.0,
//         Math.PI * 0.6 * 0.6 / 4.0,
//         1916.0,
//         0.8,
//         timeData,
//         massFlowData
//     );

//     return rocket.LaunchUntilMax(1e-3);
// }

// double FitnessDiffEvol(double[] x) => -1.0 * Simulate(x);

// double FitnessGD(double[] x)
// {
//     var combTotal = Integrate.Romberg(timeData, x);
//     double penalty = Math.Pow(combTotal - 3500.0, 2);
//     var minimize = -1.0 * Simulate(x);

//     return minimize + penalty;
// }

// double Restriction(double[] x)
//     => Integrate.Romberg(timeData, x) - 3500.0;

// var bounds = new List<double[]>(numberOfPoints);
// for (int i = 0; i < numberOfPoints; i++)
//     bounds.Add(new double[] { 0.0, 1000.0 });

// var diffEvol = new DiffEvolution(FitnessDiffEvol, bounds, 15 * numberOfPoints, Restriction);
// var sol = diffEvol.Optimize(10000);

// foreach (var s in sol)
//     Console.WriteLine(s);

// Console.WriteLine($"Altitude maxima: {Simulate(sol)}");

var list = new List<int> { 1, 2, 3, 5, 7, 8, 9 };

var sol = Desafio_Foguete.Search.Search.BinarySearch(list, 81);

Console.WriteLine(sol);