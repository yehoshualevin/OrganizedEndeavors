using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizedEndeavors.Data
{
    public class Endeavor
    {
        public int Id { get; set; }
        public string Endeavor1 { get; set; }
        public int? HandledBy { get; set; }
        public string Name { get; set; }
    }
}
