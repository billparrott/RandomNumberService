using RandomNumberService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RandomNumberService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RandomNumberGenerator" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RandomNumberGenerator.svc or RandomNumberGenerator.svc.cs at the Solution Explorer and start debugging.
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
            NumberModel IRandomNumberGenerator.GetRandomNumbers()
            {
                var random = new Random();

                var numbermodel = new NumberModel
                {
                    RandomNumber1 = random.Next(-500, 1000),
                    RandomNumber2 = random.Next(-500, 1000),
                    RandomNumber3 = random.Next(-500, 1000),
                };

                return numbermodel;
            }

        int[] IRandomNumberGenerator.RollDice(int NumberOfDice, int NumberOfPips, bool Total)
        {
            var random = new Random();
            int diceTotal = 0, dr;
            List<int> diceList = new List<int>();

            for(int i = 0; i < NumberOfDice; i++)
            {
                dr = random.Next(1, NumberOfPips);
                diceList.Add(dr);
                diceTotal += dr;
            }

            if (Total) { diceList.Add(diceTotal); }

            return diceList.ToArray();
        }
    }
}
