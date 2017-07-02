using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.PagingModels
{
    public class BllPhotosPaging
    {
        public IEnumerable<BllPhoto> BllPhotos { get; set; }
        public BllPageInfo BllPageInfo { get; set; }
    }
}