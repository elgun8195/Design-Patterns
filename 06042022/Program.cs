using Entities.Models;
using System;
using Utils.Exceptions;

namespace _06042022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game1 = new Game("Pubg",180,Utils.Enums.Platform.Pc);
            game1.Publisher = "Tencent";
            game1.DiscountPercent = 19;
            game1.ShowInfo();
            
            Game game2 = new Game("Fortnite", 120, Utils.Enums.Platform.Xbox);
            game2.Publisher = "SuperCell";
            game2.DiscountPercent = 21;
            game2.ShowInfo();

            Game game3 = new Game("HayDay", 150, Utils.Enums.Platform.PlayStation);
            game3.Publisher = "SuperCell";
            game3.DiscountPercent = 25;

            Store store = new Store();
            store.Name = "Apple";

            try
            {
                store.AddGame(game1);
                store.AddGame(game2);
                store.AddGame(game3);
                //store.FilterGamesByPrice(100, 200);
                //store.FilterGamesByDiscountPrice(18, 22);
                store.GetGameById(2).ShowInfo();
            }
            catch (AlreadyExistsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
