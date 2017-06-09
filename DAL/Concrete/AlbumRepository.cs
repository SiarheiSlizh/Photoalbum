using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;

namespace DAL.Concrete
{
    public class AlbumRepository : IAlbumRepository
    {
        public void Create(DalAlbum e)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalAlbum e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalAlbum> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalAlbum GetById(int key)
        {
            throw new NotImplementedException();
        }
    }
}
