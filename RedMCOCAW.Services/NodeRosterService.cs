using RedMCOCAW.Data;
using RedMCOCAW.Models.NodeRoster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMCOCAW.Services
{
    public class NodeRosterService
    {
        private readonly Guid _userId;

        public NodeRosterService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateNodeRoster(NodeRosterModel model)
        {
            var entity = new NodeRoster()
            {
                NodeId = model.NodeId,
                NodeAssignmentId = model.NodeAssignmentId

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.NodeRosters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool EditNodeRoster(NodeRosterModel model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .NodeRosters
                    .Single(e => e.NodeId == model.NodeId);

                entity.NodeId = model.NodeId;
                entity.NodeAssignmentId = model.NodeAssignmentId;
                
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<NodeRosterModel> GetNodeRosters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .NodeRosters                    
                    .Select(
                        e =>
                        new NodeRosterModel
                        {
                            NodeId = e.NodeId,
                            NodeAssignmentId = e.NodeAssignmentId
                        });
                return query.ToArray();
            }
        }

        public NodeRosterModel GetNodeRosterById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .NodeRosters
                    .Single(e => e.NodeId == id);
                return
                    new NodeRosterModel
                    {
                        NodeId = entity.NodeId,
                        NodeAssignmentId = entity.NodeAssignmentId
                    };
            }
        }

        public bool DeleteNodeRoster(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .NodeRosters
                    .Single(e => e.NodeId == id);
                ctx.NodeRosters.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
