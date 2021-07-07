using RedMCOCAW.Data;
using RedMCOCAW.Models.Champion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMCOCAW.Services
{
    public class ChampionService
    {
        private readonly Guid _userId; // Field to hold guid from logged in user

        public ChampionService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateChampion(ChampionCreate model)
        {
            var entity = new Champion()
            {
                OwnerId = _userId,
                ChampId = model.ChampId,
                Name = model.Name
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Champions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool EditChampion(ChampionListItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Champions
                    .Single(e => e.ChampId == model.ChampId && e.OwnerId == _userId);

                entity.ChampId = model.ChampId;
                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ChampionListItem> GetChampions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Champions
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ChampionListItem
                        {
                            ChampId = e.ChampId,
                            Name = e.Name
                        });
                return query.ToArray();
            }
        }

        public ChampionListItem GetChampionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Champions
                    .Single(e => e.ChampId == id);
                return
                    new ChampionListItem
                    {
                        ChampId = entity.ChampId,
                        Name = entity.Name
                    };
            }
        }

        public bool DeleteChampion(int allianceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Champions
                    .Single(e => e.ChampId == allianceId);
                ctx.Champions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
