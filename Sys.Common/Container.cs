using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Common
{
    public class Container
    {
        /// <summary>
        /// IOC 容器
        /// </summary>
        private static IContainer container = null;

        private static void SetContainer()
        {
            try
            {
                if (container == null)
                {
                    Initialise();
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("IOC实例化出错!" + ex.Message);
            }
           
        }
        /// <summary>
        /// 获取接口的实例化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            SetContainer();
            return container.Resolve<T>();
        }
        /// <summary>
        /// 获取接口的实例化对象
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Resolve(Type type)
        {
            SetContainer();
            return container.Resolve(type);
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialise()
        {
            var builder = new ContainerBuilder();
            Assembly serviceAssembly = Assembly.Load("Sys.Service");
            builder.RegisterTypes(serviceAssembly.GetTypes()).AsImplementedInterfaces();
            //格式：builder.RegisterType<xxxx>().As<Ixxxx>().InstancePerLifetimeScope();
            //builder.RegisterType<AccountService>().As<IAccountService>().InstancePerLifetimeScope();
            //builder.RegisterType<MenusService>().As<IMenusService>().InstancePerLifetimeScope();
            //builder.RegisterType<RoleService>().As<IRoleService>().InstancePerLifetimeScope();
            //builder.RegisterType<Role_AccountService>().As<IRole_AccountService>().InstancePerLifetimeScope();
            //builder.RegisterType<OperateService>().As<IOperateService>().InstancePerLifetimeScope();
            container = builder.Build();
        }
    }
}
