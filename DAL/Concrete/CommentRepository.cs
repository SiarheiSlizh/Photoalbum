using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;

namespace DAL.Concrete
{
    public class CommentRepository : ICommentRepository
    {
        public void Create(DalComment e)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalComment e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalComment> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalComment GetById(int key)
        {
            throw new NotImplementedException();
        }
    }
}
