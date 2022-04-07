using System;
using System.Collections.Generic;
using System.Text;
using Utils.Enums;

namespace Entities.Models
{
    public class Game
    {
        private static int _id;
        public int Id { get; }
        public string Name { get; set; }
        public Platform Platform { get; set; }
        public double Price { get; set; }
        public double DiscountPercent { get; set; }
        public string Publisher { get; set; }
        public bool IsDeleted { get; set; }


        public Game(string name,double price,Platform platform)
        {
            _id++;
            Name = name;
            Id = _id;
            Price = price;
            Platform = platform;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Id: {Id} - Name: {Name} - Platform: {Platform} - Price: {Price} -DisPercent: {DiscountPercent}");
            Console.WriteLine($"Publisher: {Publisher} - Isdeleted: {IsDeleted}");
        }

       
        public void GetDiscountPrice()
        {
            Console.WriteLine(Price-((Price * DiscountPercent/100)));            
        }
    }
}
