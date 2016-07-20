using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class Solution
{
    static short NumberOfScenarios = 0;

    static void Main(string[] args)
    {
        //NumberOfScenarios = short.Parse(Console.ReadLine());
        NumberOfScenarios = 1;

        for (var i = 0; i < NumberOfScenarios; i++)
        {
            var cities = ParseCityData();
            Console.WriteLine(SolveScenario(cities));
        }
    }

    static City[] ParseCityData()
    {
        //return new City[]
        //{
        //    new City(1, 10),
        //    new City(3, 20),
        //    new City(6, 30),
        //};

        return new City[]
        {
            new City(5, 3333),
            new City(55, 333),
            new City(555, 333),
            new City(55555, 33),
            new City(555555 , 35),
        };

        ///////////////////////////////////////////

        City[] cities = new City[int.Parse(Console.ReadLine())];

        string[] line2 = Console.ReadLine().Split(' '),
            line3 = Console.ReadLine().Split(' ');

        for (var j = 0; j < cities.Length; j++)
            cities[j] = new City(int.Parse(line2[j]), int.Parse(line3[j]));

        return cities;
    }

    static long SolveScenario(City[] cities)
    {
        long sum = 0;
        for (var i = 0; i < cities.Length; i++)
        {
            City startCity = cities[i];
            for (var j = i + 1; j < cities.Length; j++)
            {
                City targetCity = cities[j];
                int distance = (int)Math.Abs(startCity.Coordinate - targetCity.Coordinate);
                sum += distance * Math.Max(startCity.Population, targetCity.Population);
            }
        }
        return sum;
    }

    static int GetPeopleCombinations(City city1, City city2)
    {
        if(city1.Population > city2.Population)
        {
            BigInteger highFactorial = Factorial(city1.Population),
                lowFactorial = city2.Population * Factorial(city1.Population - city2.Population);
            //int population = 0; // city1.Population;
            BigInteger result = highFactorial / lowFactorial;
            return (int)result;
        }
        else
        {
            BigInteger highFactorial = Factorial(city2.Population),
                lowFactorial = city1.Population * Factorial(city2.Population - city1.Population);
            //int population = 0; // city2.Population;
            BigInteger result = highFactorial / lowFactorial;
            return (int)result;
        }
    }

    static Dictionary<int, BigInteger> KnownFactorials = new Dictionary<int, BigInteger>();
    static BigInteger Factorial(int num)
    {
        if (num <= 1)
            return 1;
        if (KnownFactorials.ContainsKey(num))
            return KnownFactorials[num];
        var result = (ulong)num * Factorial(num - 1);
        KnownFactorials[num] = result;
        return result;
    }

    struct City
    {
        public int Coordinate { get; set; }
        public int Population { get; set; }

        public City(int coordinate, int population)
            : this()
        {
            Coordinate = coordinate;
            Population = population;
        }
    }
}