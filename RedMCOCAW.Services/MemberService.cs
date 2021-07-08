using RedMCOCAW.Data;
using RedMCOCAW.Models.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMCOCAW.Services
{
    public class MemberService
    {
        private readonly Guid _userId;

        public MemberService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMember(MemberCreate model)
        {
            var entity = new Member()
            {
                OwnerId = _userId,                
                Name = model.Name,
                Notes = model.Notes
            };

            using (var ctx = new ApplicationDbContext())
            {
                var findAllianceId = ctx.Alliances.Single(e => e.AllianceTag == model.AllianceTag);
                entity.AllianceId = findAllianceId.AllianceId;
                ctx.Members.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool EditMember(MemberEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Members
                    .Single(e => e.MemberId == model.MemberId && e.OwnerId == _userId);

                entity.MemberId = model.MemberId;
                entity.Name = model.Name;
                entity.Notes = model.Notes;

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MemberListItem> GetMembers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Members
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new MemberListItem
                        {
                            MemberId = e.MemberId,
                            AllianceId = e.AllianceId,
                            Name = e.Name,
                            Notes = e.Notes

                        });
                return query.ToArray();
            }
        }

        public MemberDetail GetMemberById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Members
                    .Single(e => e.MemberId == id);
                return
                    new MemberDetail
                    {
                        MemberId = entity.MemberId,
                        AllianceId = entity.AllianceId,
                        Name = entity.Name,
                        Notes = entity.Notes                        
                    };
            }
        }

        public bool DeleteMember(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Members
                    .Single(e => e.MemberId == id && e.OwnerId == _userId);
                ctx.Members.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
