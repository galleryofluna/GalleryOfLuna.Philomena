using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GalleryOfLuna.Philomena.Parameters;
using GalleryOfLuna.Philomena.Responses;
using Integer = System.Numerics.BigInteger;

namespace GalleryOfLuna.Philomena
{
    public partial class PhilomenaClient
    {
        public Task<ImageSearchResponse> SearchImagesAsync(
            string? query = null,
            PagingOptions? pagingOptions = null,
            Integer? filterId = null,
            SortDirection sortDirection = SortDirection.Descending,
            SortField.Images sortField = SortField.Images.Id,
            CancellationToken? cancellationToken = default)
        {
            var queryBuilder = new QueryBuilder()
                .Add(QueryParameters.Key, ApiKey)
                .Add(QueryParameters.Query, query)
                .Add(QueryParameters.Page, pagingOptions?.Page ?? PagingOptions.Default.Page)
                .Add(QueryParameters.PerPage, pagingOptions?.PerPage ?? PagingOptions.Default.PerPage)
                .Add(QueryParameters.SortDirection, sortDirection)
                .Add(QueryParameters.SortField, sortField)
                .Add(QueryParameters.FilterId, filterId?.ToString());

            var requestUriBuilder = new UriBuilder(_baseUri);
            requestUriBuilder.Path = "/api/v1/json/search/images";
            requestUriBuilder.Query = queryBuilder.ToString();

            return SendRequestAsync<ImageSearchResponse>(
                requestUriBuilder.ToString(), 
                HttpMethod.Get,
                cancellationToken ?? CancellationToken.None);
        }

        public Task<ImageResponse> GetImageAsync(Integer id, CancellationToken cancellationToken = default)
        {
            var queryBuilder = new QueryBuilder()
                .Add(QueryParameters.Key, ApiKey);

            var requestUriBuilder = new UriBuilder(_baseUri);
            requestUriBuilder.Path = $"/api/v1/json/images/{id}";
            requestUriBuilder.Query = queryBuilder.ToString();

            return SendRequestAsync<ImageResponse>(
                requestUriBuilder.ToString(), 
                HttpMethod.Get,
                cancellationToken);
        }
    }
}