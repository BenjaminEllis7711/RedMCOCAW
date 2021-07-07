using RedMCOCAW.Data;
using RedMCOCAW.Models.Roster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMCOCAW.Services
{
    public class RosterService
    {
        private readonly Guid _userId;

        public RosterService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRoster(RosterCreate model)
        {
            var entity = new Roster()
            {
                MemberId = model.MemberId,
                ChampionId = model.ChampionId,
                NodeAssignmentId = null,
                OwnerId = _userId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Rosters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool EditRoster(RosterDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Rosters
                    .Single(e => e.MemberId == model.MemberId);

                entity.MemberId = model.MemberId;
                entity.ChampionId = model.ChampionId;
                entity.NodeAssignmentId = model.NodeAssignmentId;

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RosterListItem> GetRosters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Rosters
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new RosterListItem
                        {
                            MemberId = e.MemberId,
                            ChampionId = e.ChampionId,
                            NodeAssignmentId = e.NodeAssignmentId,
                            IsAssigned = e.IsAssigned
                        });
                return query.ToArray();
            }
        }

        public RosterListItem GetRosterByMemberId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Rosters
                    .Single(e => e.MemberId == id);
                return
                    new RosterListItem
                    {
                        MemberId = entity.MemberId,
                        ChampionId = entity.ChampionId,
                        NodeAssignmentId = entity.NodeAssignmentId,
                        IsAssigned = entity.IsAssigned
                    };
            }
        }

        public bool DeleteRosterByNodeAssignmentId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Rosters
                    .Where(e => e.OwnerId == _userId)
                    .Single(e => e.NodeAssignmentId == id);
                ctx.Rosters.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
