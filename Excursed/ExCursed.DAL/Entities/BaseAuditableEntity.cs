using System;

namespace ExCursed.DAL.Entities
{
    public class BaseAuditableEntity : BaseEntity
    {
        public DateTimeOffset Added { get; set; }

        public DateTimeOffset Modified { get; set; }
    }
}
