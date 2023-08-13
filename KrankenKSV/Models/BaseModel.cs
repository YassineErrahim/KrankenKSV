using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrankenKSV.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public string CreatedFrom { get; set; } = String.Empty;

        public string UpdatedFrom { get; set; } = String.Empty;
    }
}
