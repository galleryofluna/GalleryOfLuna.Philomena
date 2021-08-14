using Integer = System.Numerics.BigInteger;

namespace GalleryOfLuna.Philomena.Views
{
    public sealed record Interaction
    {
        /// <summary>
        /// The image identifier of interaction which applied on.
        /// </summary>
        public Integer ImageId { get; init; }
        
        /// <summary>
        /// The type of interaction which applied on.
        /// </summary>
        public InteractionType InteractionType { get; init; }
        
        /// <summary>
        /// The user identifier of interaction which applied on.
        /// </summary>
        public Integer UserId { get; init; }

        /// <summary>
        ///     <para>
        ///         The value of interaction.
        ///     </para>
        ///     <remarks>
        ///         The possible values based on interactions.ex (11.08.2021): "up", "down", "" (empty string)
        ///     </remarks>
        ///     <seealso href="https://github.com/derpibooru/philomena/blob/master/lib/philomena/interactions.ex"/>
        /// </summary>
        public string Value { get; init; } = string.Empty;
    }
}