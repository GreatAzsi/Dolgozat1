using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozat
{
    internal record Auto(string Brand, string Type, int HP, string Owner)
    {
        private int _price {  get; set; }
        public double Rating { get; set; }
        private double AverageConsumption {  get ; set; }
        private string _owner { get; init; } = Owner;
        

        public double GetAverageConsumption()
        {
            return AverageConsumption;
        }
        public string GetOwner()
        {
            return _owner;
        }
        public int GetPrice()
        {
            return _price;
        }
        public void SetAverageConsumption(double newAverageConsumption)
        {
            AverageConsumption = newAverageConsumption;
        }


        public void SetPrice(int newPrice)
        {
            _price = newPrice;
        }
        // 1.feladat
        // Készíts egy public függvényt, amely eldönti, hogy az autó erősnek számít-e!
        // Egy autó akkor számít erősnek, ha legalább 200 lóerős.

        public bool IsCarStrong()
        {
            return HP >= 200;
        }

        // 2.feladat
        // Készíts egy public függvényt, amely eldönti, hogy az autó jó értékelésű-e!
        // Egy autó akkor számít jó értékelésűnek, ha a Rating legalább 8.5.

        public bool IsCarRatingGood()
        {
            return Rating >= 8.5;
        }

        // 3.feladat
        // Készíts egy public függvényt, amely paraméterként kap egy maximális árat!
        // A függvény döntse el, hogy az autó ára nem haladja-e meg a megadott összeget!

        public bool IsCarExpensive(int MaxPrice)
        {
            return _price <= MaxPrice;
        }

        // 4.feladat
        // Készíts egy public függvényt, amely paraméterként kap egy százalékos kedvezményt!
        // Ha a kedvezmény 1 és 30 százalék közé esik, csökkentse ennek megfelelően az autó Price értékét!

        public void DiscountIf(int discount)
        {
            _price *= discount <= 30 && discount >= 1 ? (100 - discount) / 100 : 1;
        }


        // 5.feladat
        // Készíts egy public függvényt, amely paraméterként kap egy megtett távolságot kilométerben!
        // A függvény számítsa ki, hogy az autó átlagosan hány liter üzemanyagot használna el a megadott távolság megtételéhez!
        // Az AverageConsumption érték 100km-re vonatkozik

        public double TripUsage(int TripDistance)
        {
            return TripDistance * (AverageConsumption / 100);
        }

        // 6.feladat
        // Készíts egy public függvényt, amely paraméterként kap egy üzemanyagárat és egy távolságot!
        // A függvény számítsa ki, hogy az adott távolság megtétele mennyibe kerülne az autóval!
        public int FuelPricePerTrip(int FuelPrice, int TripDistance)
        {
            return (int)(FuelPrice * TripUsage(TripDistance));
        }

        // 7.feladat
        // Készíts egy public függvényt, amely paraméterként kap egy új értékelést!
        // Ha az értékelés 1 és 10  közé esik, állítsa be az új értékelést, amúgy maradjon a régi.
        public void SetNewRating(double newRating)
        {
            Rating = newRating >= 1 && newRating <= 10 ? newRating : Rating; 
        }

        // 8.feladat
        // Készíts egy public függvényt, amely visszaadj egy szöveget, az alábbi példa alapján :
        // "Az autót a BMW cég gyártotta, ez a M5 Competition (F90) típusú, Kiss János a gazdája és 30000000 forintba került"

        public override string ToString()
        {
            return $"Az autót a {Brand} cég gyártotta, ez a {Type} típusú, {Owner} a gazdája és {_price} forintba került, es a ratingje {Rating}";
        }

        // Használd az alábbi listát, az adatokat helyetesen állítsd be:
        //Az adatok sorrendje : márka, típus, ár, értékelés, átlagfogyasztás, lóerő, tulajdonos




    }
}
