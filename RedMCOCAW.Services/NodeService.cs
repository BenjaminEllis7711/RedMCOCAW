using RedMCOCAW.Data;
using RedMCOCAW.Models.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMCOCAW.Services
{
    public class NodeService
    {
        private readonly Guid _userId; 

        public NodeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateNode(NodeCreate model)
        {
            var entity = new Node()
            {
                OwnerId = _userId,
                NodeId = model.NodeId,
                Details = model.Details
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Nodes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool EditNode(NodeListItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Nodes
                    .Single(e => e.NodeId == model.NodeId);

                entity.NodeId = model.NodeId;
                entity.Details = model.Details;

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<NodeListItem> GetNodes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Nodes
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new NodeListItem
                        {
                            NodeId = e.NodeId,
                            Details = e.Details
                        });
                return query.ToArray();
            }
        }

        public NodeListItem GetNodeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Nodes
                    .Single(e => e.NodeId == id);
                return
                    new NodeListItem
                    {
                        NodeId = entity.NodeId,
                        Details = entity.Details
                    };
            }
        }

        public bool DeleteNode(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Nodes
                    .Single(e => e.NodeId == id);
                ctx.Nodes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}