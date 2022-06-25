using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.Json.Serialization;
using Integer = System.Numerics.BigInteger;

// TODO: Consider which props can be null
#nullable disable

namespace GalleryOfLuna.Philomena.Views
{
    public sealed record Image
    {
        /// <summary>
        /// The image's ID.
        /// </summary>
        public Integer Id { get; init; }
        
        /// <summary>
        /// The creation time, in UTC, of the image.
        /// </summary>
        public DateTime CreatedAt { get; init; }
        
        /// <summary>
        /// The time, in UTC, the image was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; init; }
        
        /// <summary>
        /// The time, in UTC, the image was first seen (before any duplicate merging).
        /// </summary>
        public DateTime FirstSeenAt { get; init; }
        
        /// <summary>
        /// The image's width, in pixels.
        /// </summary>
        public Integer Width { get; init; }
        
        /// <summary>
        /// The image's height, in pixels.
        /// </summary>
        public Integer Height { get; init; }
        
        /// <summary>
        ///     <para>The MIME type of this image.</para>
        ///     <remarks>
        ///         One of "image/gif", "image/jpeg", "image/png", "image/svg+xml", "video/webm".
        ///     </remarks>
        /// </summary>
        public string MimeType { get; init; }
        
        /// <summary>
        /// The number of bytes the image's file contains.
        /// </summary>
        public Integer Size { get; init; }
        
        /// <summary>
        /// The number of seconds the image lasts, if animated, otherwise .04f.
        /// </summary>
        public float Duration { get; init; }
        
        /// <summary>
        /// Whether the image is animated.
        /// </summary>
        public bool Animated { get; init; }
        
        /// <summary>
        /// The file extension of the image.
        /// </summary>
        public ImageFormat Format { get; init; }
        
        /// <summary>
        /// The image's width divided by its height.
        /// </summary>
        public float AspectRatio { get; init; }
        
        /// <summary>
        /// The filename that the image was uploaded with.
        /// </summary>
        public string Name { get; init; }
        
        /// <summary>
        /// The SHA512 hash of the image as it was originally uploaded.
        /// </summary>
        public string OrigSha512Hash { get; init; }
        
        /// <summary>
        /// A list of tag names the image contains.
        /// </summary>
        public ValueCollection<string> Tags { get; init; }
        
        /// <summary>
        /// A list of tag IDs the image contains.
        /// </summary>
        public IReadOnlyList<Integer> TagIds { get; init; }
        
        /// <summary>
        /// The image's uploader.
        /// </summary>
        public string Uploader { get; init; }
        
        /// <summary>
        /// The ID of the image's uploader. null if uploaded anonymously.
        /// </summary>
        public Integer? UploaderId { get; init; }
        
        /// <summary>
        /// The lower bound of the Wilson score interval for the image, based on its upvotes and downvotes, given a z-score corresponding to a confidence of 99.5%.
        /// </summary>
        public float WilsonScore { get; init; }
        
        /// <summary>
        /// Optional object of internal image intensity data for deduplication purposes. May be null if intensities have not yet been generated.
        /// </summary>
        public dynamic Intensities { get; init; }
        
        /// <summary>
        /// The image's number of upvotes minus the image's number of downvotes.
        /// </summary>
        public Integer Score { get; init; }
        
        /// <summary>
        /// The number of upvotes the image has.
        /// </summary>
        public Integer Upvotes { get; init; }
        
        /// <summary>
        /// The number of downvotes the image has.
        /// </summary>
        public Integer Downvotes { get; init; }
        
        /// <summary>
        /// The number of faves the image has.
        /// </summary>
        public Integer Faves { get; init; }

        /// <summary>
        /// The number of comments made on the image.
        /// </summary>
        public Integer CommentCount { get; init; }
        
        /// <summary>
        /// The number of tags present on the image.
        /// </summary>
        public Integer TagCount { get; init; }

        /// <summary>
        /// The image's description.
        /// </summary>
        public string Description { get; init; } 
        
        /// <summary>
        /// The current source URL of the image.
        /// </summary>
        public Uri SourceUrl { get; init; }
        
        /// <summary>
        /// The image's view URL, including tags.
        /// </summary>
        public Uri ViewUrl { get; init; }
        
        /// <summary>
        ///     <para>
        ///         A mapping of representation names to their respective URLs.
        ///     </para>
        ///     <remarks>
        ///         Contains the keys "full", "large", "medium", "small", "tall", "thumb", "thumb_small", "thumb_tiny".
        ///     </remarks>
        /// </summary>
        public IReadOnlyDictionary<string, Uri> Representations { get; init; }
        
        /// <summary>
        ///     <para>
        ///         Whether the image has finished thumbnail generation.
        ///     </para>
        ///     <remarks>
        ///         Do not attempt to load images from view_url or representations if this is false.
        ///     </remarks>
        /// </summary>
        public bool ThumbnailsGenerated { get; init; }
        
        /// <summary>
        /// Whether the image has finished optimization.
        /// </summary>
        public bool Processed { get; init; }
        
        /// <summary>
        ///     <para>
        ///         The hide reason for the image, or null if none provided.
        ///     </para>
        ///     <remarks>
        ///         This will only have a value on images which are deleted for a rule violation.
        ///     </remarks>
        /// </summary>
        public bool? DeletionReason { get; init; }
        
        /// <summary>
        ///     <para>
        ///         The ID of the target image, or null if none provided.
        ///     </para>
        ///     <remarks>
        ///         This will only have a value on images which are merged into another image.
        ///     </remarks>
        /// </summary>
        public Integer? DuplicateOf { get; init; }
        
        /// <summary>
        ///     <para>
        ///         Whether the image is hidden.
        ///     </para>
        ///     <remarks>
        ///         An image is hidden if it is merged or deleted for a rule violation.
        ///     </remarks>
        /// </summary>
        public bool HiddenFromUsers { get; init; }
    }
}