#region License
// The MIT License (MIT)
// 
// Copyright (c) 2018 Simplesoft.pt
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
#endregion

using System.Collections.Generic;
using SimpleSoft.Persistence.Model;

// ReSharper disable once CheckNamespace
namespace System.Linq
{
    public static partial class LinqEntityExtensions
    {
        /// <summary>
        /// Finds and entity from a collection of <see cref="IEntity{TId}"/> instances 
        /// by their unique identifier. It will throw an exception if more than one items
        /// with the given id are found.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TId">The identity type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="id">The unique identifier</param>
        /// <returns>The entity or null of not found</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static T GetById<T, TId>(this IEnumerable<T> items, TId id)
            where T : class, IEntity<TId>
            where TId : IEquatable<TId>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (id == null) throw new ArgumentNullException(nameof(id));

            return items.SingleOrDefault(e => id.Equals(e.Id));
        }

        /// <summary>
        /// Checks if the collection of <see cref="IEntity{TId}"/> instances contains
        /// the given id.
        /// </summary>
        /// <typeparam name="TId">The identity type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="id">The unique identifier</param>
        /// <returns>True if found, otherwise false</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool ContainsId<TId>(this IEnumerable<IEntity<TId>> items, TId id)
            where TId : IEquatable<TId>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (id == null) throw new ArgumentNullException(nameof(id));

            return items.Any(e => id.Equals(e.Id));
        }

        /// <summary>
        /// Filters a collection of <see cref="IEntity{TId}"/> instances by their unique identifier. 
        /// It should result into a collection of 1 or 0 items.
        /// This may be helpful to use before <code>SingleOrDefaultAsync</code>, <code>AnyAsync</code> or their
        /// sync counterparts in generic repositories.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TId">The identity type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="id">The unique identifier</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IQueryable<T> WhereId<T, TId>(this IQueryable<T> items, TId id)
            where T : class, IEntity<TId>
            where TId : IEquatable<TId>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (id == null) throw new ArgumentNullException(nameof(id));

            return items.Where(e => id.Equals(e.Id));
        }
    }
}
