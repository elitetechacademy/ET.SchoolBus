using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.SchoolBus.Application.DTOs.Request
{
    public class SchoolUpdateDto
    {
        public int SchoolId { get; set; } //Primary Key
        public string SchoolName { get; set; }
        public int StudentCount { get; set; }
        public int StartYear { get; set; }
    }
}
