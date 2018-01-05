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
        /// Filters a collection of <see cref="IHaveCreatedMeta{TCreatedBy}"/> instances
        /// by created identifier.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TBy">Property type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> WhereWasCreatedBy<T, TBy>(this IEnumerable<T> items, TBy by)
            where T : class, IHaveCreatedMeta<TBy>
            where TBy : IEquatable<TBy>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => by.Equals(e.CreatedBy));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveCreatedMeta{TCreatedBy}"/> instances
        /// by their string created identifier using a comparison type.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <param name="comparisonType">The comparison type</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> WhereWasCreatedBy<T>(this IEnumerable<T> items, string by, StringComparison comparisonType)
            where T : class, IHaveCreatedMeta<string>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => by.Equals(e.CreatedBy, comparisonType));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveCreatedMeta{TCreatedBy}"/> instances
        /// by created identifier.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TBy">Property type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IQueryable<T> WhereWasCreatedBy<T, TBy>(this IQueryable<T> items, TBy by)
            where T : class, IHaveCreatedMeta<TBy>
            where TBy : IEquatable<TBy>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => by.Equals(e.CreatedBy));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveCreatedMeta{TCreatedBy}"/> instances
        /// by their string created identifier using a comparison type.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <param name="comparisonType">The comparison type</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IQueryable<T> WhereWasCreatedBy<T>(this IQueryable<T> items, string by, StringComparison comparisonType)
            where T : class, IHaveCreatedMeta<string>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => by.Equals(e.CreatedBy, comparisonType));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveCreatedLocalMeta{TCreatedBy}"/> instances
        /// by created identifier.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TBy">Property type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> WhereWasCreatedLocallyBy<T, TBy>(this IEnumerable<T> items, TBy by)
            where T : class, IHaveCreatedLocalMeta<TBy>
            where TBy : IEquatable<TBy>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => by.Equals(e.CreatedBy));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveCreatedLocalMeta{TCreatedBy}"/> instances
        /// by their string created identifier using a comparison type.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <param name="comparisonType">The comparison type</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> WhereWasCreatedLocallyBy<T>(this IEnumerable<T> items, string by, StringComparison comparisonType)
            where T : class, IHaveCreatedLocalMeta<string>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => by.Equals(e.CreatedBy, comparisonType));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveCreatedLocalMeta{TCreatedBy}"/> instances
        /// by created identifier.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TBy">Property type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IQueryable<T> WhereWasCreatedLocallyBy<T, TBy>(this IQueryable<T> items, TBy by)
            where T : class, IHaveCreatedLocalMeta<TBy>
            where TBy : IEquatable<TBy>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => by.Equals(e.CreatedBy));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveCreatedLocalMeta{TCreatedBy}"/> instances
        /// by their string created identifier using a comparison type.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <param name="comparisonType">The comparison type</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IQueryable<T> WhereWasCreatedLocallyBy<T>(this IQueryable<T> items, string by, StringComparison comparisonType)
            where T : class, IHaveCreatedLocalMeta<string>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => by.Equals(e.CreatedBy, comparisonType));
        }
    }
}
