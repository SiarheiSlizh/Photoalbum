using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.PagingModels
{
    public class BllCommentsPaging
    {
        public IEnumerable<BllComment> BllComments { get; set; }
        public BllPageInfo BllPageInfo { get; set; }
    }
}