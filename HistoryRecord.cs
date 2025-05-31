using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITEDB_TEST {
    public class HistoryRecord {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Action { get; set; } // Added, Updated, Deleted
        public string ChangedField { get; set; } // Example: "Age"
        public string OldValue { get; set; } // Previous value (if updated)
        public string NewValue { get; set; } // Updated value
        public DateTime Timestamp { get; set; }
    }


}
