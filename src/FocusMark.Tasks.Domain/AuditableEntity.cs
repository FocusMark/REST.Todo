using System;

namespace FocusMark.Tasks.Domain
{
    public class AuditableEntity
    {
        public string UserId { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
