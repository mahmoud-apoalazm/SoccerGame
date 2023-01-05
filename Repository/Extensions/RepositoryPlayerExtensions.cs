using Entities.Models;
using Repository.Extensions.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class RepositoryPlayerExtensions
    {
        public static IQueryable<Player> FilterPlayers(this IQueryable<Player>
           players, uint minAge, uint maxAge) =>
             players.Where(p => (p.Age >= minAge && p.Age <= maxAge));
        //---------------------------------------------------------------------
        public static IQueryable<Player> Search(this IQueryable<Player> players,
       string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return players;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return players.Where(p => p.Name.ToLower().Contains(lowerCaseTerm));
        }
        //------------------------------------------------------------------------

        public static IQueryable<Player> Sort(this IQueryable<Player> players, string
           orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return players.OrderBy(e => e.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Player>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return players.OrderBy(e => e.Name);
            return players.OrderBy(orderQuery);
        }
    }
}
