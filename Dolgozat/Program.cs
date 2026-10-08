using System.Collections.Generic;

namespace Dolgozat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Használd az alábbi listát, az adatokat helyetesen állítsd be:
            //Az adatok sorrendje : márka, típus, ár, értékelés, átlagfogyasztás, lóerő, tulajdonos

            List<Auto> autos = new List<Auto>()
            {
                new Auto("Toyota", "Corolla", 140, "Nagy Peter"){Rating = 8.7},
                new Auto("BMW", "330i", 245, "Kiss Adam") { Rating = 9.1 },
                new Auto("Tesla", "Model 3", 410, "Zsár Dániel") { Rating = 4.3 },
                new Auto("Honda", "Civic", 220, "Zsár Dániel") { Rating = 7.3 },
                new Auto("Toyota", "Camry", 218, "Kiss Adam") { Rating = 8.8 },
                new Auto("BMW", "520i", 208, "Szabo David") { Rating = 8.9 },
                new Auto("Ford", "Mustang", 450, "Szabo David") { Rating = 9.2 }
            };
            autos[0].SetPrice(9500000);
            autos[0].SetAverageConsumption(5.8);
            autos[1].SetPrice(18500000);
            autos[1].SetAverageConsumption(7.2);
            autos[2].SetPrice(9000000);
            autos[2].SetAverageConsumption(0.4);
            autos[3].SetPrice(200000);
            autos[3].SetAverageConsumption(10.2);
            autos[4].SetPrice(14500000);
            autos[4].SetAverageConsumption(6.4);
            autos[5].SetPrice(22500000);
            autos[5].SetAverageConsumption(6.8);
            autos[6].SetPrice(24000000);
            autos[6].SetAverageConsumption(10.5);


            // LINQ FELADATOK


            // 1.feladat
            // LINQ segítségével számold meg, hány Toyota márkájú autó található a listában!
            Console.WriteLine(autos.Where(x => x.Brand == "Toyota").Count());

            Console.WriteLine("--------------------------");
            // 2.feladat
            // LINQ segítségével számítsd ki az összes autó Price értékének összegét!
            Console.WriteLine(autos.Sum(x => x.GetPrice()));

            Console.WriteLine("--------------------------");
            // 3.feladat
            // LINQ segítségével számítsd ki a BMW márkájú autók átlagos teljesítményét (lóerő)!
            Console.WriteLine(autos.Where(x => x.Brand == "BMW").Average(x => x.HP));

            Console.WriteLine("--------------------------");
            // 4.feladat
            // LINQ segítségével keresd meg a legolcsóbb autónak a típusát!
            Console.WriteLine(autos.OrderBy(x => x.GetPrice()).Select(x => x.Type).First());

            Console.WriteLine("--------------------------");
            // 5.feladat
            // LINQ segítségével add meg az összes autómárkát!
            // Minden márka csak egyszer szerepeljen az eredményben!
            autos.Select(x => x.Brand).Distinct().ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("--------------------------");

            // 6.feladat
            // LINQ segítségével add vissza márkánként, hogy hány autó tartozik az adott márkához!

            foreach (KeyValuePair<string, int> item in autos.GroupBy(x => x.Brand).ToDictionary(x => x.Key, x => x.Count()))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.WriteLine("--------------------------");
            // 7.feladat
            // LINQ segítségével számítsd ki tulajdonosonként az autók árának értékeinek összegét!
            foreach (KeyValuePair<string, int> item in autos.GroupBy(x => x.Owner).ToDictionary(x => x.Key, x => x.Sum(x => x.GetPrice())))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.WriteLine("--------------------------");
            // 8.feladat
            // LINQ segítségével add vissza márkánként az autók átlagos értékelését!
            foreach (KeyValuePair<string, double> item in autos.GroupBy(x => x.Brand).ToDictionary(x => x.Key, x => x.Average(x => x.Rating)))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.WriteLine("--------------------------");
            // 9.feladat
            // LINQ segítségével add vissza márkánként a legjobb értékelésű autójának típusát!
            foreach (KeyValuePair<string, string> item in autos.OrderByDescending(x => x.Rating).GroupBy(x => x.Brand).ToDictionary(x => x.Key, x => x.Select(x => x.Type).First()))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.WriteLine("--------------------------");
            // 10.feladat
            // LINQ segítségével keresd meg minden tulajdonos legdrágább autójának típusát!

            foreach (KeyValuePair<string, string> item in autos.OrderByDescending(x => x.GetPrice()).GroupBy(x => x.Owner).ToDictionary(x => x.Key, x => x.Select(x => x.Type).First()))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.WriteLine("--------------------------");
            // 11..feladat
            // LINQ segítségével számítsd ki márkánként az autók átlagos árát, 
            // de csak azokat mentsd el, amelyek átlagos értékelése legalább 8.8!

            foreach (KeyValuePair<string, double> item in autos.Where(x => x.Rating >= 8.8).GroupBy(x => x.Brand).ToDictionary(x => x.Key, x => x.Average(x => x.GetPrice())))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.WriteLine("--------------------------");
            // 12.feladat
            // LINQ segítségével számítsd ki tulajdonosonként
            // az autók átlagos árát, majd keresd meg azt a tulajdonost, akinek az autói átlagosan a legdrágábbak!
            List<string> list1 = new List<string>();
            List<double> list2 = new List<double>();
            foreach (KeyValuePair<string, double> item in autos.GroupBy(x => x.Owner).OrderByDescending(x => x.Average(x => x.GetPrice())).ToDictionary(x => x.Key, x => x.Average(x => x.GetPrice())))
            {
               list1.Add(item.Key);
               list2.Add(item.Value);
            }
            Console.WriteLine($"{list1[0]} - {list2[0]}");

        }
    }
}
