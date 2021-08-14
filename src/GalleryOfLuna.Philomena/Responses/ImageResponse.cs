using GalleryOfLuna.Philomena.Views;

namespace GalleryOfLuna.Philomena.Responses
{
    public record ImageResponse(Image Image) : IPhilomenaResponse;
}