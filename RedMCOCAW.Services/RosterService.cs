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

        public bool EditRoster(RosterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Rosters
                    .Single(e => e.MemberId == model.MemberId && e.ChampionId == model.ChampionId);

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
                            MemberName = e.Member.Name,
                            ChampionName = e.Champion.Name                           
                            
                        });
                return query.ToArray();
            }
        }

        public RosterListItem GetRosterByMemberIdAndChampId(int id, int champId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Rosters
                    .Single(e => e.MemberId == id && e.ChampionId == champId);
                return
                    new RosterListItem
                    {
                        MemberId = entity.MemberId,
                        ChampionId = entity.ChampionId,
                        NodeAssignmentId = entity.NodeAssignmentId,
                        IsAssigned = entity.IsAssigned,
                        MemberName = entity.Member.Name,
                        ChampionName = entity.Champion.Name                        
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

        // Check to see if champion exists by Id, if does return
        public bool DoesChampIdExist(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx
                    .Champions
                    .Any(e => e.ChampId == id);
            };
        }

        //Check to see if member exists by that Id
        public bool DoesMemberIdExist(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx
                    .Members
                    .Any(e => e.MemberId == id && e.OwnerId == _userId);
            };
        }

        // Check to see if this member already has that champion assigned
        public bool DoesMemberAlreadyHaveChampOnRoster(int memberId, int champId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx
                    .Rosters
                    .Any(e => e.MemberId == memberId && e.ChampionId == champId);
            };
        }
    }
}
