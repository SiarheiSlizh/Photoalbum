using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Entities
{
    public class BllComment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateOfSending { get; set; }
        public int UserId { get; set; }
        public int PhotoId { get; set; }
    }
}
