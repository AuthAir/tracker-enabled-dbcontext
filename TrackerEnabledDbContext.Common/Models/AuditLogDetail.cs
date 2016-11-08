using EntityInterfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackerEnabledDbContext.Common.Interfaces;

namespace TrackerEnabledDbContext.Common.Models
{
    public class AuditLogDetail : IUnTrackable, IEntity, ITableFields
    {
        public AuditLogDetail()
        {

            _id = null;
            AuditLogDetailId = System.Guid.NewGuid().ToString();
            DateCreated = DateTime.UtcNow;
        }
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        long? _id;
        public long? Id
        {
            get
            {
                if (_id == 0) return null;
                return _id;
            }
            set
            {
                if (value == 0)
                    _id = null;
                else
                    _id = value;
            }
        }

        [Key]
        public string AuditLogDetailId { get; set; }

        [Required]
        [MaxLength(256)]
        public string ColumnName { get; set; }

        [Required]
        [MaxLength(256)]
        public string PropertyName { get; set; }

        public string OriginalValue { get; set; }

        public string NewValue { get; set; }

        public virtual string AuditLogId { get; set; }

        [ForeignKey("AuditLogId")]
        public virtual AuditLog Log { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string GetTableIdValue()
        {
            return this.AuditLogDetailId;
        }
    }
}