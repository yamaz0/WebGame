using System.ComponentModel.DataAnnotations;
using WebGame.Domain.Common;

namespace WebGame.Entities.Items
{

    public class ItemBase : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
    }
}
