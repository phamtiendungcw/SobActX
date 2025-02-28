using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Domain.Entities;

namespace SAX.Persistence.Repositories;

public static class SpecificationEvaluator<T> where T : BaseEntity
{
    public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
    {
        var query = inputQuery;

        // Apply criteria
        if (specification.Criteria != null) query = query.Where(specification.Criteria);

        // Apply includes
        query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

        // Apply to include strings
        query = specification.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));

        // Apply ordering
        if (specification.OrderBy != null)
            query = query.OrderBy(specification.OrderBy);
        else if (specification.OrderByDescending != null) query = query.OrderByDescending(specification.OrderByDescending);

        // Apply paging if enabled
        if (specification.IsPagingEnabled)
            query = query.Skip(specification.Skip)
                .Take(specification.Take);

        return query;
    }
}