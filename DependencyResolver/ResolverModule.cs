using DAL.Concrete;
using DAL.Interfacies.Repository;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using BLL.Interfacies.Services;
using BLL.Services;

namespace DependencyResolver
{
    public static class ResolverModule
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            Configure(kernel);
        }

        private static void Configure(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<DbContext>().To<PhotoalbumContext>().InRequestScope();

            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IPhotoService>().To<PhotoService>();

            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<IAlbumRepository>().To<AlbumRepository>();
            kernel.Bind<IPhotoRepository>().To<PhotoRepository>();
            kernel.Bind<ICommentRepository>().To<CommentRepository>();
            kernel.Bind<ILikeRepository>().To<LikeRepository>();
        }
    }
}