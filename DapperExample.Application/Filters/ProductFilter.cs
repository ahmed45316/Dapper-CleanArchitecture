namespace DapperExample.Application.Filters
{
    public record ProductFilter(int? id = null, string? name = null, decimal? price = null);
}
