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
    public static partial class LinqExtensions
    {
        /// <summary>
        /// Filters a collection of <see cref="IHaveUpdatedMeta{TUpdatedBy}"/> instances
        /// by updated identifier.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TBy">Property type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> WhereWasUpdatedBy<T, TBy>(this IEnumerable<T> items, TBy by)
            where T : class, IHaveUpdatedMeta<TBy>
            where TBy : IEquatable<TBy>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => by.Equals(e.UpdatedBy));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveUpdatedMeta{TUpdatedBy}"/> instances
        /// by their string updated identifier using a comparison type.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <param name="comparisonType">The comparison type</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> WhereWasUpdatedBy<T>(this IEnumerable<T> items, string by, StringComparison comparisonType)
            where T : class, IHaveUpdatedMeta<string>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => by.Equals(e.UpdatedBy, comparisonType));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveUpdatedMeta{TUpdatedBy}"/> instances
        /// by updated identifier.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TBy">Property type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IQueryable<T> WhereWasUpdatedBy<T, TBy>(this IQueryable<T> items, TBy by)
            where T : class, IHaveUpdatedMeta<TBy>
            where TBy : IEquatable<TBy>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => by.Equals(e.UpdatedBy));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveUpdatedMeta{TUpdatedBy}"/> instances
        /// by their string updated identifier using a comparison type.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <param name="comparisonType">The comparison type</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IQueryable<T> WhereWasUpdatedBy<T>(this IQueryable<T> items, string by, StringComparison comparisonType)
            where T : class, IHaveUpdatedMeta<string>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => by.Equals(e.UpdatedBy, comparisonType));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveUpdatedLocalMeta{TUpdatedBy}"/> instances
        /// by updated identifier.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TBy">Property type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> WhereWasUpdatedLocallyBy<T, TBy>(this IEnumerable<T> items, TBy by)
            where T : class, IHaveUpdatedLocalMeta<TBy>
            where TBy : IEquatable<TBy>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => by.Equals(e.UpdatedBy));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveUpdatedMeta{TUpdatedBy}"/> instances
        /// by their string updated identifier using a comparison type.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <param name="comparisonType">The comparison type</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> WhereWasUpdatedLocallyBy<T>(this IEnumerable<T> items, string by, StringComparison comparisonType)
            where T : class, IHaveUpdatedLocalMeta<string>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => by.Equals(e.UpdatedBy, comparisonType));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveUpdatedLocalMeta{TUpdatedBy}"/> instances
        /// by updated identifier.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TBy">Property type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IQueryable<T> WhereWasUpdatedLocallyBy<T, TBy>(this IQueryable<T> items, TBy by)
            where T : class, IHaveUpdatedLocalMeta<TBy>
            where TBy : IEquatable<TBy>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => by.Equals(e.UpdatedBy));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveUpdatedMeta{TUpdatedBy}"/> instances
        /// by their string updated identifier using a comparison type.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <param name="comparisonType">The comparison type</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IQueryable<T> WhereWasUpdatedLocallyBy<T>(this IQueryable<T> items, string by, StringComparison comparisonType)
            where T : class, IHaveUpdatedLocalMeta<string>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => by.Equals(e.UpdatedBy, comparisonType));
        }
    }
}
