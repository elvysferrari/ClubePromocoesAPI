using Autofac;
using ClubePromocoesAPI.Commands.PromocaoModule.Command;
using ClubePromocoesAPI.Dapper.Repositories;
using ClubePromocoesAPI.Data.Repository.Base;
using ClubePromocoesAPI.Domain.Interfaces;
using ClubePromocoesAPI.Reads.PromocaoModule.Queries;
using MediatR;
using System.Reflection;

namespace ClubePromocoesAPI.IOC.IOC
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(AdicionarPromocaoCommand).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(ObterPromocaoPorIdQuery).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(PromocaoQuery).GetTypeInfo().Assembly).Where(t => t.Name.EndsWith("Query")).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(Repository<>).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRepository<>));

            

            base.Load(builder);
        }
    }
}
