using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackerEnabledDbContext.Common.Interfaces;

namespace TrackerEnabledDbContext.Common.Models
{
    [Table("LogMetadata")]
    public class LogMetadata : IUnTrackable
    {

        public LogMetadata()
        {

            _id = null;
        }

        long? _id;
        [Key]
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

        public virtual string AuditLogId { get; set; }

        [ForeignKey("AuditLogId")]
        public virtual AuditLog AuditLog { get; set; }
        
        public string Key { get; set; }

        public string Value { get; set; }
    }
}