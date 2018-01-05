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
    /// <summary>
    /// Represents an entity that has an unique identifier, created, updated and deleted metadata
    /// </summary>
    /// <typeparam name="TId">The identifier type</typeparam>
    /// <typeparam name="TCreated">The created by type</typeparam>
    /// <typeparam name="TUpdated">The updated by type</typeparam>
    /// <typeparam name="TDeleted">The deleted by type</typeparam>
    public abstract class EntityWithAllMeta<TId, TCreated, TUpdated, TDeleted> : 
        Entity<TId>, IHaveCreatedMeta<TCreated>, IHaveUpdatedMeta<TUpdated>, IHaveDeletedMeta<TDeleted>
        where TId : IEquatable<TId>
    {
        private DateTimeOffset _createdOn;
        private DateTimeOffset _updatedOn;

        /// <summary>
        /// Creates a new instance
        /// </summary>
        protected EntityWithAllMeta()
        {
            _createdOn = _updatedOn = DateTimeOffset.Now;
        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="id">The unique identifier</param>
        protected EntityWithAllMeta(TId id) : base(id)
        {
            _createdOn = _updatedOn = DateTimeOffset.Now;
        }

        /// <inheritdoc />
        public virtual DateTimeOffset CreatedOn
        {
            get => _createdOn;
            set => _createdOn = value;
        }

        /// <inheritdoc />
        public virtual TCreated CreatedBy { get; set; }

        /// <inheritdoc />
        public virtual DateTimeOffset UpdatedOn
        {
            get => _updatedOn;
            set => _updatedOn = value;
        }

        /// <inheritdoc />
        public virtual TUpdated UpdatedBy { get; set; }

        /// <inheritdoc />
        public virtual DateTimeOffset? DeletedOn { get; set; }

        /// <inheritdoc />
        public virtual TDeleted DeletedBy { get; set; }
    }

    /// <summary>
    /// Represents an entity that has an unique identifier, created, updated and deleted metadata
    /// </summary>
    /// <typeparam name="TId">The identifier type</typeparam>
    /// <typeparam name="TBy">The by type</typeparam>
    public abstract class EntityWithAllMeta<TId, TBy> : EntityWithAllMeta<TId, TBy, TBy, TBy>
        where TId : IEquatable<TId>
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        protected EntityWithAllMeta()
        {

        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="id">The unique identifier</param>
        protected EntityWithAllMeta(TId id) : base(id)
        {

        }
    }

    /// <summary>
    /// Represents an entity that has an unique identifier, created, updated and deleted metadata
    /// </summary>
    /// <typeparam name="TId">The identifier type</typeparam>
    public abstract class EntityWithAllMeta<TId> : 
        EntityWithAllMeta<TId, string, string, string>, IHaveCreatedMeta, IHaveUpdatedMeta, IHaveDeletedMeta
        where TId : IEquatable<TId>
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        protected EntityWithAllMeta()
        {

        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="id">The unique identifier</param>
        protected EntityWithAllMeta(TId id) : base(id)
        {

        }
    }
}
