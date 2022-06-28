using HalloEfCore.Contracts;
using HalloEfCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloEfCore.Logic
{
    internal class MitarbeiterLogic
    {
        internal static double GetAverageAgeOfAllMyMitarbeiter(IRepository repo)
        {

            if (repo == null)
                throw new ArgumentNullException("repo");

            return repo.Query<Mitarbeiter>()
                       .ToList()
                       .Average(x => CalcAge(x.GebDatum));
        }



        internal static int CalcAge(DateTime gebDatum)
        {
            return CalcAge(gebDatum, DateTime.Today);
        }

        internal static int CalcAge(DateTime gebDatum, DateTime today)
        {
            // Calculate the age.
            var age = today.Year - gebDatum.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (gebDatum.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}
