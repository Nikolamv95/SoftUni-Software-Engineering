using P03_FootballBetting.Data;
using System;
using System.Linq;

namespace P03_FootballBetting
{
    class StartUp
    {
        static void Main(string[] args)
        {
            FootballBettingContext context = new FootballBettingContext();

            var users = context.Users.Select(x => new
            {
                UserName = x.Username,
                Email = x.Email,
                Name = x.Name == null ? ("No name") : x.Name,
                Balance = x.Balance
            });

            foreach (var x in users)
            {
                Console.WriteLine($"{x.UserName} -> {x.Email} {x.Name} {x.Balance:f2}");
            }
        }
    }
}
