using MovieApi.Application.Features.CQRSDesingPattern.Queries.CategoryQueries;
using MovieApi.Application.Features.CQRSDesingPattern.Results.CategoryResults;
using MovieApi.Persistence.Context;

public class GetCategoryByIdQueryHandler
{
    private readonly MovieContext _context;

    public GetCategoryByIdQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
    {
        var value = await _context.Categories.FindAsync(query.CategoryId);
        return new GetCategoryByIdQueryResult
        {
            CategoryId = value.CategoryId,
            CategoryName = value.CategoryName
        };
    }
}
