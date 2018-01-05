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

using System;

// ReSharper disable once CheckNamespace
namespace SimpleSoft.Persistence.Model
{
    public static partial class ModelExtensions
    {
        /// <summary>
        /// Fills all metadata of a given <see cref="IHaveUpdatedMeta{TUpdatedBy}"/>.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TBy">The identifier type</typeparam>
        /// <param name="entity">The entity to fill</param>
        /// <param name="by">Who updated the entity</param>
        /// <param name="on">The date and time when it last updated. If null <see cref="DateTimeOffset.Now"/> will be used.</param>
        /// <returns>The entity after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T UpdatedBy<T, TBy>(this T entity, TBy by, DateTimeOffset? on = null)
            where T : class, IHaveUpdatedMeta<TBy>
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            entity.UpdatedBy = by;
            entity.UpdatedOn = on ?? DateTimeOffset.Now;
            return entity;
        }

        /// <summary>
        /// Was the <see cref="IHaveUpdatedMeta{TUpdatedBy}"/> instance updated
        /// by the given identifier?
        /// </summary>
        /// <typeparam name="TBy">The identifier type</typeparam>
        /// <param name="entity">The entity to fill</param>
        /// <param name="by">Who updated the entity</param>
        /// <returns>True if updated, otherwise false</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool WasUpdatedBy<TBy>(this IHaveUpdatedMeta<TBy> entity, TBy by)
            where TBy : IEquatable<TBy>
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return by.Equals(entity.UpdatedBy);
        }

        /// <summary>
        /// Fills all metadata of a given <see cref="IHaveUpdatedLocalMeta{TUpdatedBy}"/>.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TBy">The identifier type</typeparam>
        /// <param name="entity">The entity to fill</param>
        /// <param name="by">Who updated the entity</param>
        /// <param name="on">The date and time when it last updated. If null <see cref="DateTimeOffset.Now"/> will be used.</param>
        /// <returns>The entity after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T UpdatedLocallyBy<T, TBy>(this T entity, TBy by, DateTime? on = null)
            where T : class, IHaveUpdatedLocalMeta<TBy>
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            entity.UpdatedBy = by;
            entity.UpdatedOn = on ?? DateTime.Now;
            return entity;
        }

        /// <summary>
        /// Was the <see cref="IHaveUpdatedLocalMeta{TUpdatedBy}"/> instance updated
        /// by the given identifier?
        /// </summary>
        /// <typeparam name="TBy">The identifier type</typeparam>
        /// <param name="entity">The entity to fill</param>
        /// <param name="by">Who updated the entity</param>
        /// <returns>True if updated, otherwise false</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool WasUpdatedLocallyBy<TBy>(this IHaveUpdatedLocalMeta<TBy> entity, TBy by)
            where TBy : IEquatable<TBy>
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return by.Equals(by);
        }
    }
}