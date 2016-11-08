using EntityInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackerEnabledDbContext.Common.Interfaces;

namespace TrackerEnabledDbContext.Common.Models
{
    /// <summary>
    ///     This model class is used to store the changes made in datbase values
    ///     For the audit purpose. Only selected tables can be tracked with the help of TrackChangesAttribute Attribute present
    ///     in the common library.
    /// </summary>
    public class AuditLog: IUnTrackable, IEntity, ITableFields
    {
        public AuditLog()
        {

            _id = null;
            AuditLogId = System.Guid.NewGuid().ToString();
            LogDetails = new List<AuditLogDetail>();
            DateCreated = DateTime.UtcNow;
        }

        long? _id;

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public string AuditLogId { get; set; }

        public string UserName { get; set; }

        [Required]
        public String EventDateUTC { get; set; }

        [Required]
        public String EventDateOffSet { get; set; }

        [Required]
        public EventType EventType { get; set; }

        [Required]
        [MaxLength(256)]
        public string TableName { get; set; }

        [Required]
        [MaxLength(512)]
        public string TypeFullName { get; set; }

        [Required]
        [MaxLength(256)]
        public string RecordId { get; set; }

        public virtual ICollection<AuditLogDetail> LogDetails { get; set; } = new List<AuditLogDetail>();

        public virtual ICollection<LogMetadata> Metadata { get; set; } = new List<LogMetadata>();
        public System.DateTime DateCreated { get; set; }
        public System.DateTime? DateUpdated { get; set; }

        public string GetTableIdValue()
        {
            return this.AuditLogId;
        }
    }
}