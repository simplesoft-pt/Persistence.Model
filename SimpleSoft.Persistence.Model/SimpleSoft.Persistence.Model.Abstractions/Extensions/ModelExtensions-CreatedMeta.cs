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
        /// Fills all metadata of a given <see cref="IHaveCreatedMeta{TCreatedBy}"/>.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TBy">The created by type</typeparam>
        /// <param name="entity">The entity to fill</param>
        /// <param name="by">Who created the entity</param>
        /// <param name="on">The date and time when it was created. If null <see cref="DateTimeOffset.Now"/> will be used.</param>
        /// <returns>The entity after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T CreatedBy<T, TBy>(this T entity, TBy by, DateTimeOffset? on = null)
            where T : class, IHaveCreatedMeta<TBy>
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            entity.CreatedBy = by;
            entity.CreatedOn = on ?? DateTimeOffset.Now;
            return entity;
        }

        /// <summary>
        /// Was the <see cref="IHaveCreatedMeta{TCreatedBy}"/> instance created
        /// by the given identifier?
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TBy">The created by type</typeparam>
        /// <param name="entity">The entity to fill</param>
        /// <param name="by">Who created the entity</param>
        /// <returns>True if created, otherwise false</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool WasCreatedBy<T, TBy>(this T entity, TBy by)
            where T : class, IHaveCreatedMeta<TBy>
            where TBy : IEquatable<TBy>
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return entity.CreatedBy == null ? by == null : entity.CreatedBy.Equals(by);
        }

        /// <summary>
        /// Fills all metadata of a given <see cref="IHaveCreatedLocalMeta{TCreatedBy}"/>.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TBy">The created by type</typeparam>
        /// <param name="entity">The entity to fill</param>
        /// <param name="by">Who created the entity</param>
        /// <param name="on">The date and time when it was created. If null <see cref="DateTime.Now"/> will be used.</param>
        /// <returns>The entity after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T CreatedLocallyBy<T, TBy>(this T entity, TBy by, DateTime? on = null)
            where T : class, IHaveCreatedLocalMeta<TBy>
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            entity.CreatedBy = by;
            entity.CreatedOn = on ?? DateTime.Now;
            return entity;
        }

        /// <summary>
        /// Was the <see cref="IHaveCreatedLocalMeta{TCreatedBy}"/> instance created
        /// by the given identifier?
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TBy">The created by type</typeparam>
        /// <param name="entity">The entity to fill</param>
        /// <param name="by">Who created the entity</param>
        /// <returns>True if created, otherwise false</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool WasCreatedLocallyBy<T, TBy>(this T entity, TBy by)
            where T : class, IHaveCreatedLocalMeta<TBy>
            where TBy : IEquatable<TBy>
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return entity.CreatedBy == null ? by == null : entity.CreatedBy.Equals(by);
        }
    }
}