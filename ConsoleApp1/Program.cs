using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public List<Engineer> GetEngineersWhoLikeCallOfDuty(City city)
        {
            using (var ctx = new EmployeeContext())
            {
                var list = ctx.Employees.Where(e => e is Engineer && e.CityId == city.Id)
                        .Select(e => e as Engineer)
                        .Where(e => e.FavoriteVideogame.Contains("Call Of Duty"))
                        .ToList();

                return list;
            }
        }


        static void Main(string[] args)
        {

        }
    }
}
