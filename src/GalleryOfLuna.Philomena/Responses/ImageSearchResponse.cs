using System.Collections.Generic;
using GalleryOfLuna.Philomena.Views;

using Integer = System.Numerics.BigInteger;

namespace GalleryOfLuna.Philomena.Responses
{
    public record ImageSearchResponse(IEnumerable<Image> Images, IEnumerable<Interaction> Interactions, Integer Total) 
        : IPhilomenaResponse;
}