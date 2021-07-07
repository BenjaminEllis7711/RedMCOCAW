using RedMCOCAW.Data;
using RedMCOCAW.Models.Alliance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMCOCAW.Services
{
    public class AllianceService
    {
        private readonly Guid _userId; // Field to hold guid from logged in user

        public AllianceService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateAlliance(AllianceCreate model)
        {
            var entity = new Alliance()
            {
                OwnerId = _userId,
                AllianceTag = model.AllianceTag,
                Notes = model.Notes
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Alliances.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool EditAlliance(AllianceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Alliances
                    .Single(e => e.AllianceId == model.AllianceId && e.OwnerId == _userId);

                entity.AllianceTag = model.AllianceTag;
                entity.Notes = model.Notes;                              

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AllianceListItem> GetAlliances()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Alliances
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new AllianceListItem
                        {
                            AllianceId = e.AllianceId,
                            AllianceTag = e.AllianceTag,
                            Notes = e.Notes,
                            MemberCount = e.Members.Count() + 1
                        }) ;
                return query.ToArray();
            }
        }

        public AllianceDetail GetAllianceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Alliances
                    .Single(e => e.AllianceId == id && e.OwnerId == _userId);
                return
                    new AllianceDetail
                    {
                        AllianceId = entity.AllianceId,
                        AllianceTag = entity.AllianceTag,
                        Notes = entity.Notes
                        // Members
                    };
            }
        }

        public bool DeleteAlliance(int allianceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Alliances
                    .Single(e => e.AllianceId == allianceId && e.OwnerId == _userId);
                ctx.Alliances.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

