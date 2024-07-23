using Autofac;
using Autofac.Core;
using Para.Data.Domain;
using Para.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.DependencyResolvers.Autofac
{
    /// <summary>
    /// Bu sınıf, autofac modülüdür. Bu modül, projede kullanılacak olan tüm servisleri ve repositoryleri register eder.
    /// </summary>
    public class AutofacBusinessModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            
            builder.RegisterType<UnitOfWork<Customer>>().As<IUnitOfWork<Customer>>().SingleInstance();
            builder.RegisterType<UnitOfWork<CustomerDetail>>().As<IUnitOfWork<CustomerDetail>>().SingleInstance();
            builder.RegisterType<UnitOfWork<CustomerPhone>>().As<IUnitOfWork<CustomerPhone>>().SingleInstance();
            builder.RegisterType<UnitOfWork<CustomerAddress>>().As<IUnitOfWork<CustomerAddress>>().SingleInstance();

        }
    }
}
