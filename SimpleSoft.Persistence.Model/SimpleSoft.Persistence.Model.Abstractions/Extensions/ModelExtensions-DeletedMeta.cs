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
        /// Fills all metadata of a given <see cref="IHaveDeletedMeta{TDeletedBy}"/>.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TBy">The identifier type</typeparam>
        /// <param name="entity">The entity to fill</param>
        /// <param name="by">Who deleted the entity</param>
        /// <param name="on">The date and time when it soft deleted. If null <see cref="DateTimeOffset.Now"/> will be used.</param>
        /// <returns>The entity after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T DeletedBy<T, TBy>(this T entity, TBy by, DateTimeOffset? on = null)
            where T : class, IHaveDeletedMeta<TBy>
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            entity.DeletedBy = by;
            entity.DeletedOn = on ?? DateTimeOffset.Now;
            return entity;
        }

        /// <summary>
        /// Was the <see cref="IHaveDeletedMeta{TDeletedBy}"/> instance deleted
        /// by the given identifier?
        /// </summary>
        /// <typeparam name="TBy">The identifier type</typeparam>
        /// <param name="entity">The entity to fill</param>
        /// <param name="by">Who deleted the entity</param>
        /// <returns>True if deleted, otherwise false</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool WasDeletedBy<TBy>(this IHaveDeletedMeta<TBy> entity, TBy by)
            where TBy : IEquatable<TBy>
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return by.Equals(entity.DeletedBy);
        }

        /// <summary>
        /// Is the entity soft deleted?
        /// </summary>
        /// <param name="entity">The entity to check</param>
        /// <returns>True if deleted, otherwise false</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsDeleted(this IHaveDeletedMeta<string> entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return entity.DeletedBy != null;
        }

        /// <summary>
        /// Is the entity soft deleted?
        /// </summary>
        /// <param name="entity">The entity to check</param>
        /// <returns>True if deleted, otherwise false</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsDeleted(this IHaveDeletedMeta<int?> entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return entity.DeletedBy != null;
        }

        /// <summary>
        /// Is the entity soft deleted?
        /// </summary>
        /// <param name="entity">The entity to check</param>
        /// <returns>True if deleted, otherwise false</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsDeleted(this IHaveDeletedMeta<long?> entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return entity.DeletedBy != null;
        }

        /// <summary>
        /// Fills all metadata of a given <see cref="IHaveDeletedLocalMeta{TDeletedBy}"/>.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TBy">The identifier type</typeparam>
        /// <param name="entity">The entity to fill</param>
        /// <param name="by">Who deleted the entity</param>
        /// <param name="on">The date and time when it soft deleted. If null <see cref="DateTimeOffset.Now"/> will be used.</param>
        /// <returns>The entity after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T DeletedLocallyBy<T, TBy>(this T entity, TBy by, DateTime? on = null)
            where T : class, IHaveDeletedLocalMeta<TBy>
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            entity.DeletedBy = by;
            entity.DeletedOn = on ?? DateTime.Now;
            return entity;
        }

        /// <summary>
        /// Was the <see cref="IHaveDeletedLocalMeta{TDeletedBy}"/> instance deleted
        /// by the given identifier?
        /// </summary>
        /// <typeparam name="TBy">The identifier type</typeparam>
        /// <param name="entity">The entity to fill</param>
        /// <param name="by">Who deleted the entity</param>
        /// <returns>True if deleted, otherwise false</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool WasDeletedLocallyBy<TBy>(this IHaveDeletedLocalMeta<TBy> entity, TBy by)
            where TBy : IEquatable<TBy>
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (by == null) throw new ArgumentNullException(nameof(by));

            return by.Equals(by);
        }

        /// <summary>
        /// Is the entity soft deleted?
        /// </summary>
        /// <param name="entity">The entity to check</param>
        /// <returns>True if deleted, otherwise false</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsDeleted(this IHaveDeletedLocalMeta<string> entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return entity.DeletedBy != null;
        }

        /// <summary>
        /// Is the entity soft deleted?
        /// </summary>
        /// <param name="entity">The entity to check</param>
        /// <returns>True if deleted, otherwise false</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsDeleted(this IHaveDeletedLocalMeta<int?> entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return entity.DeletedBy != null;
        }

        /// <summary>
        /// Is the entity soft deleted?
        /// </summary>
        /// <param name="entity">The entity to check</param>
        /// <returns>True if deleted, otherwise false</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsDeleted(this IHaveDeletedLocalMeta<long?> entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return entity.DeletedBy != null;
        }
    }
}