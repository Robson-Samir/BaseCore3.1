using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Base.Infrastructure.Data.Contexts
{
    public static class EntityConfigExtensions
    {
        public static void ApplyAssemblyConfiguration(this ModelBuilder modelBuilder)
        {
            var assembly = typeof(EntityConfigExtensions).Assembly;
            var configurations = assembly
                .GetExportedTypes()
                .Where(x =>
                    (x.GetTypeInfo().IsClass) &&
                    (!x.GetTypeInfo().IsAbstract) &&
                    (x.GetInterfaces().Any(y =>
                        (y.GetTypeInfo().IsGenericType) &&
                        (y.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    ))
                ).Select(Activator.CreateInstance);

            foreach (dynamic configuration in configurations)
            {
                modelBuilder.ApplyConfiguration(configuration);
            }
        }
    }
}
