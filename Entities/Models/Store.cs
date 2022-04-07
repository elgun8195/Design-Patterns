using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Utils.Exceptions;

namespace Entities.Models
{
    public class Store:IEnumerable
    {
        private static int _id;
        public int Id { get; }
        public string Name { get; set; }
         List<Game> _Game { get; set; }
        public Store()
        {
            _id++;
            _Game = new List<Game>();
            Id = _id;
        }

        public void AddGame(Game game)
        {
            Game gam = _Game.Find(g=> g.Name==game.Name&& g.IsDeleted);
            if (gam != null)
            {
                throw new AlreadyExistsException("Artiq var");
            }
            _Game.Add(game);
        }

        
        public Game GetGameById(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException("Id null ola bilmez");
            }
            Game gam = _Game.Find(g => g.Id == id && g.IsDeleted);
            return gam;
        }

        public void RemoveById(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException("Id null ola bilmez");
            }
            Game gam = _Game.Find(g => g.Id == id && g.IsDeleted);
            _Game.Remove(gam);
            return;
        }

        public List<Game> FilterGamesByPrice(double minPrice,double maxPrice)
        {
            return _Game.FindAll(g=> !g.IsDeleted && g.Price>minPrice && g.Price<maxPrice);
        }

        public List<Game> FilterGamesByDiscountPrice(double minDisCountPrice, double maxDisCountPrice)
        {
            return _Game.FindAll(g => !g.IsDeleted && g.Price > minDisCountPrice && g.Price < maxDisCountPrice);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Game item in _Game)
            {
                yield return item;
            }
        }
    }
}
