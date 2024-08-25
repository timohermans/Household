using Household.Web.Components.Pages;
using Household.Web.Data.Types;
using Household.Web.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data;
using System.Text.RegularExpressions;
using Home = Household.Web.Data.Types.Home;

namespace Household.Web.Data;

public class DataContext(DbContextOptions<DataContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Home> Homes { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        TransformModelsToSnakeCase(builder);

        foreach (var entity in builder.Model.GetEntityTypes())
        {
            System.Diagnostics.Debug.WriteLine(entity.GetType().Dump());
        }
    }

    private static void TransformModelsToSnakeCase(ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            // Replace table names
            entity.SetTableName(entity.GetTableName().ToSnakeCase());
            // Replace column names
            foreach (var property in entity.GetProperties())
            {
                var columnName = property.GetColumnName(StoreObjectIdentifier.Table(property.DeclaringType.GetTableName() ?? string.Empty));
                property.SetColumnName(columnName.ToSnakeCase());
            }
            foreach (var key in entity.GetKeys())
            {
                key.SetName(key.GetName().ToSnakeCase());
            }
            foreach (var key in entity.GetForeignKeys())
            {
                key.SetConstraintName(key.GetConstraintName().ToSnakeCase());
            }
            foreach (var index in entity.GetIndexes())
            {
                index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
            }
        }
    }
}

public static class DataContextExtensions
{
    public static string? ToSnakeCase(this string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        var startUnderscores = Regex.Match(input, @"^_+");
        return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
    }
}
