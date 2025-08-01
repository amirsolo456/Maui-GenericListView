using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpanderCollectionView.Models.ExpanderHeader
{
    public class ExpanderHeader
    {
        public Dictionary<string, object> HeaderFields { get; set; } = new(); // شامل ID, Name, PendingState
        public Func<Dictionary<string, object>> LazyDetails { get; set; }     // فقط موقع نیاز ساخته می‌شه
    }

}
