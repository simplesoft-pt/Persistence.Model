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
        /// Filters a collection of <see cref="IHaveDeletedMeta{TDeletedBy}"/> instances
        /// by deleted identifier.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TBy">Property type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> WhereWasDeletedBy<T, TBy>(this IEnumerable<T> items, TBy by)
            where T : class, IHaveDeletedMeta<TBy>
            where TBy : IEquatable<TBy>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => e.DeletedOn != null && by.Equals(e.DeletedBy));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveDeletedMeta{TDeletedBy}"/> instances
        /// by their string deleted identifier using a comparison type.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <param name="comparisonType">The comparison type</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> WhereWasDeletedBy<T>(this IEnumerable<T> items, string by, StringComparison comparisonType)
            where T : class, IHaveDeletedMeta<string>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => e.DeletedOn != null && by.Equals(e.DeletedBy, comparisonType));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveDeletedMeta{TDeletedBy}"/> instances
        /// by their deleted status.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TBy">Property type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="deleted">True to filter deleted, otherwise non deleted</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> WhereDeleted<T, TBy>(this IEnumerable<T> items, bool deleted)
            where T : class, IHaveDeletedMeta<TBy>
            where TBy : IEquatable<TBy>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            return deleted
                ? items.Where(e => e.DeletedOn != null)
                : items.Where(e => e.DeletedOn == null);
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveDeletedMeta{TDeletedBy}"/> instances
        /// by deleted identifier.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TBy">Property type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IQueryable<T> WhereWasDeletedBy<T, TBy>(this IQueryable<T> items, TBy by)
            where T : class, IHaveDeletedMeta<TBy>
            where TBy : IEquatable<TBy>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => e.DeletedOn != null && by.Equals(e.DeletedBy));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveDeletedMeta{TDeletedBy}"/> instances
        /// by their string deleted identifier using a comparison type.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <param name="comparisonType">The comparison type</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IQueryable<T> WhereWasDeletedBy<T>(this IQueryable<T> items, string by, StringComparison comparisonType)
            where T : class, IHaveDeletedMeta<string>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => e.DeletedOn != null && by.Equals(e.DeletedBy, comparisonType));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveDeletedMeta{TDeletedBy}"/> instances
        /// by their deleted status.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TBy">Property type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="deleted">True to filter deleted, otherwise non deleted</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IQueryable<T> WhereDeleted<T, TBy>(this IQueryable<T> items, bool deleted)
            where T : class, IHaveDeletedMeta<TBy>
            where TBy : IEquatable<TBy>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            return deleted
                ? items.Where(e => e.DeletedOn != null)
                : items.Where(e => e.DeletedOn == null);
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveDeletedLocalMeta{TDeletedBy}"/> instances
        /// by deleted identifier.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TBy">Property type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> WhereWasDeletedLocallyBy<T, TBy>(this IEnumerable<T> items, TBy by)
            where T : class, IHaveDeletedLocalMeta<TBy>
            where TBy : IEquatable<TBy>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => e.DeletedOn != null && by.Equals(e.DeletedBy));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveDeletedLocalMeta{TDeletedBy}"/> instances
        /// by their string deleted identifier using a comparison type.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <param name="comparisonType">The comparison type</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> WhereWasDeletedLocallyBy<T>(this IEnumerable<T> items, string by, StringComparison comparisonType)
            where T : class, IHaveDeletedLocalMeta<string>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => e.DeletedOn != null && by.Equals(e.DeletedBy, comparisonType));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveDeletedLocalMeta{TDeletedBy}"/> instances
        /// by their deleted status.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TBy">Property type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="deleted">True to filter deleted, otherwise non deleted</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> WhereDeletedLocally<T, TBy>(this IEnumerable<T> items, bool deleted)
            where T : class, IHaveDeletedLocalMeta<TBy>
            where TBy : IEquatable<TBy>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            return deleted
                ? items.Where(e => e.DeletedOn != null)
                : items.Where(e => e.DeletedOn == null);
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveDeletedLocalMeta{TDeletedBy}"/> instances
        /// by deleted identifier.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TBy">Property type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IQueryable<T> WhereWasDeletedLocallyBy<T, TBy>(this IQueryable<T> items, TBy by)
            where T : class, IHaveDeletedLocalMeta<TBy>
            where TBy : IEquatable<TBy>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => e.DeletedOn != null && by.Equals(e.DeletedBy));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveDeletedLocalMeta{TDeletedBy}"/> instances
        /// by their string deleted identifier using a comparison type.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="by">The identifier</param>
        /// <param name="comparisonType">The comparison type</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IQueryable<T> WhereWasDeletedLocallyBy<T>(this IQueryable<T> items, string by, StringComparison comparisonType)
            where T : class, IHaveDeletedLocalMeta<string>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return items.Where(e => e.DeletedOn != null && by.Equals(e.DeletedBy, comparisonType));
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveDeletedLocalMeta{TDeletedBy}"/> instances
        /// by their deleted status.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <typeparam name="TBy">Property type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="deleted">True to filter deleted, otherwise non deleted</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IQueryable<T> WhereDeletedLocally<T, TBy>(this IQueryable<T> items, bool deleted)
            where T : class, IHaveDeletedLocalMeta<TBy>
            where TBy : IEquatable<TBy>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            return deleted
                ? items.Where(e => e.DeletedOn != null)
                : items.Where(e => e.DeletedOn == null);
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveSoftDelete"/> instances
        /// by their deleted status.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="deleted">True to filter deleted, otherwise non deleted</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> WhereDeleted<T>(this IEnumerable<T> items, bool deleted)
            where T : class, IHaveSoftDelete
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            return items.Where(e => e.Deleted == deleted);
        }

        /// <summary>
        /// Filters a collection of <see cref="IHaveSoftDelete"/> instances
        /// by their deleted status.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="items">Collection to filter</param>
        /// <param name="deleted">True to filter deleted, otherwise non deleted</param>
        /// <returns>A collection of items filtered</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IQueryable<T> WhereDeleted<T>(this IQueryable<T> items, bool deleted)
            where T : class, IHaveSoftDelete
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            return items.Where(e => e.Deleted == deleted);
        }
    }
}
