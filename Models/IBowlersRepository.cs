using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_13.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }

        public Bowler GetBowler(int bowlerid);
        public List<Bowler> GetTeam(int teamid);
        public void SaveBowler(Bowler b);
        public void CreateBowler(Bowler b);
        public void EditBowler(Bowler b);
        public void DeleteBowler(int bowlerid);
    }
}
