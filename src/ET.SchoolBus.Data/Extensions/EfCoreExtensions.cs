using System;
using System.Linq.Expressions;
using ET.SchoolBus.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace ET.SchoolBus.Data.Extensions;

public static class EfCoreExtensions
{
    public static void ApplySoftDeleteFilter<TBase>(this ModelBuilder modelBuilder)
    where TBase : BaseEntity
    {
        // Tüm entity türlerini al
        var entityTypes = modelBuilder.Model.GetEntityTypes();

        // BaseEntity'den türeyenleri filtrele
        var baseEntityTypes = entityTypes
            .Where(e => typeof(TBase).IsAssignableFrom(e.ClrType) && !e.ClrType.IsAbstract)
            .Select(e => e.ClrType)
            .ToList();

        foreach (var entityType in baseEntityTypes)
        {
            var method = typeof(ModelBuilder).GetMethods()
                .FirstOrDefault(x => x.IsGenericMethod && x.Name == "Entity")?
                .MakeGenericMethod(entityType);
            var entityBuilder = method.Invoke(modelBuilder, null);

            var hasQueryFilterMethod = entityBuilder.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == "HasQueryFilter");

            // Dinamik olarak doğru entity türüne göre Expression oluştur
            var parameter = Expression.Parameter(entityType, "x");
            var property = Expression.Property(parameter, nameof(BaseEntity.Status));
            var body = Expression.Equal(property, Expression.Constant(true));
            var lambda = Expression.Lambda(body, parameter);

            hasQueryFilterMethod.Invoke(entityBuilder, new[] { lambda });
        }
    }    
}
