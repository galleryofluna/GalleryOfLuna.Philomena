// MIT License
// 
// Copyright (c) 2011-2021 Nemesis
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace GalleryOfLuna.Philomena
{
    public class ValueCollection<T> : Collection<T>, IEquatable<ValueCollection<T>>, IFormattable
    {
        private readonly IEqualityComparer<T> _equalityComparer;

        public ValueCollection() : this(new List<T>()) { }
        
        public ValueCollection(IEqualityComparer<T>? equalityComparer = null) : this(new List<T>(), equalityComparer) { }

        public ValueCollection(IList<T> list, IEqualityComparer<T>? equalityComparer = null) : base(list) =>
            _equalityComparer = equalityComparer ?? EqualityComparer<T>.Default;

        public bool Equals(ValueCollection<T>? other)
        {
            if (other is null) 
                return false;

            if (ReferenceEquals(this, other)) 
                return true;

            using var enumerator1 = this.GetEnumerator();
            using var enumerator2 = other.GetEnumerator();

            while (enumerator1.MoveNext())
                if (!enumerator2.MoveNext() || !(_equalityComparer!).Equals(enumerator1.Current, enumerator2.Current))
                    return false;

            return !enumerator2.MoveNext(); //both enumerations reached the end
        }

        public override bool Equals(object? obj) => obj is { } && (ReferenceEquals(this, obj) || obj is ValueCollection<T> coll && Equals(coll));

        public override int GetHashCode() =>
            unchecked(Items.Aggregate(0,
                (current, element) => (current * 397) ^ (element is null ? 0 : _equalityComparer.GetHashCode(element))
            ));

        public string ToString(string? format, IFormatProvider? formatProvider)
            => "[" + string.Join(", ", this.Select(e => FormatValue(e, formatProvider))) + "]";

        public override string ToString() => ToString(null, CultureInfo.CurrentCulture);

        private static string? FormatValue(object? value, IFormatProvider? formatProvider) =>
            value switch
            {
                null => "∅",
                bool b => b ? "true" : "false",
                string s => $"\"{s}\"",
                char c => $"\'{c}\'",
                DateTime dt => dt.ToString("o", formatProvider),
                IFormattable @if => @if.ToString(null, formatProvider),
                IEnumerable ie => "[" + string.Join(", ", ie.Cast<object>().Select(e => FormatValue(e, formatProvider))) + "]",
                _ => value.ToString()
            };
    }
}