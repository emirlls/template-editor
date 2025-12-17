using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using TemplateEditor.Constants;
using TemplateEditor.Filtering;

namespace TemplateEditor.Extensions;

public static class FilteringExtension
{
    public static IQueryable<T> ApplyFilters<T, TFilters>(
        this IQueryable<T> query, 
        TFilters filters) 
        where T : class
        where TFilters : IQueryFilters
    {
        foreach (var filterModel in filters.Filters)
        {
            if (filterModel.IsFilled)
            {
                var propertyName = filterModel.Prop;
                var propertyType = filterModel.ParsedFieldType; 
                
                string dynamicQuery = "";
                object[] dynamicArgs = null;

                switch (filterModel.Strategy)
            {
                case FilterStrategies.Equal:
                case FilterStrategies.NotEqual:
                case FilterStrategies.GreaterThan:
                case FilterStrategies.GreaterAndEqualThan:
                case FilterStrategies.LessThan:
                case FilterStrategies.LessAndEqualThan:
                    if (filterModel.Values.Count >= 1)
                    {
                        dynamicQuery = $"{propertyName} {filterModel.Strategy} @0";
                        dynamicArgs = new object[] { ConvertValue(filterModel.Values.First(), propertyType) };
                    }
                    break;
                
                case FilterStrategies.Contains:
                    if (propertyType == typeof(string) && filterModel.Values.Count >= 1)
                    {
                        dynamicQuery = $"{propertyName}.Contains(@0)";
                        dynamicArgs = new object[] { filterModel.Values.First() };
                    }
                    break;
                
                case FilterStrategies.NotContains:
                    if (propertyType == typeof(string) && filterModel.Values.Count >= 1)
                    {
                        dynamicQuery = $"!{propertyName}.Contains(@0)";
                        dynamicArgs = new object[] { filterModel.Values.First() };
                    }
                    break;

                case FilterStrategies.Between:
                    if (filterModel.Values.Count >= 2)
                    {
                        dynamicQuery = $"{propertyName} >= @0 && {propertyName} <= @1";
                        dynamicArgs = new object[]
                        {
                            ConvertValue(filterModel.Values[0], propertyType),
                            ConvertValue(filterModel.Values[1], propertyType)
                        };
                    }
                    break;

                case FilterStrategies.WhereIn:
                    if (filterModel.Values.Any())
                    {
                        dynamicQuery = $"{propertyName} in @0";
                        var convertedValues = filterModel.Values
                            .Select(v => ConvertValue(v, propertyType))
                            .ToList();
                        dynamicArgs = new object[] { convertedValues }; 
                    }
                    break;
                
                default:
                    continue;
            }

                if (!string.IsNullOrEmpty(dynamicQuery))
                {
                    query = query.Where(dynamicQuery, dynamicArgs);
                }
            }
        }

        query = query
            .Skip((filters.Page - 1) * filters.PageSize)
            .Take(filters.PageSize);
            
        return query;
    }

    private static object ConvertValue(string value, Type targetType)
    {
        try
        {
            if (targetType == typeof(Guid))
            {
                return Guid.Parse(value);
            }

            if (targetType == typeof(bool))
            {
                return bool.Parse(value.ToLower());
            }

            if (targetType.IsPrimitive || targetType == typeof(string) || targetType.IsClass)
            {
                return Convert.ChangeType(value, targetType);
            }
        }
        catch (Exception)
        {
            throw;
        }

        return value;
    }
}