﻿#region License
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
    /// Represents an entity that has an unique identifier, created, updated, deleted metadata
    /// and version as Guid.
    /// </summary>
    /// <typeparam name="TId">The identifier type</typeparam>
    /// <typeparam name="TCreated">The created by type</typeparam>
    /// <typeparam name="TUpdated">The updated by type</typeparam>
    /// <typeparam name="TDeleted">The deleted by type</typeparam>
    public abstract class EntityWithAllMetaAndVersionAsGuid<TId, TCreated, TUpdated, TDeleted> :
        EntityWithAllMetaAndVersion<TId, TCreated, TUpdated, TDeleted, Guid>, IHaveVersionAsGuid
        where TId : IEquatable<TId>
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        protected EntityWithAllMetaAndVersionAsGuid()
        {

        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="id">The unique identifier</param>
        protected EntityWithAllMetaAndVersionAsGuid(TId id) : base(id)
        {

        }
    }

    /// <summary>
    /// Represents an entity that has an unique identifier, created, updated, deleted metadata
    /// and version as Guid.
    /// </summary>
    /// <typeparam name="TId">The identifier type</typeparam>
    /// <typeparam name="TBy">The by type</typeparam>
    public abstract class EntityWithAllMetaAndVersionAsGuid<TId, TBy> :
        EntityWithAllMetaAndVersion<TId, TBy, Guid>, IHaveVersionAsGuid
        where TId : IEquatable<TId>
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        protected EntityWithAllMetaAndVersionAsGuid()
        {

        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="id">The unique identifier</param>
        protected EntityWithAllMetaAndVersionAsGuid(TId id) : base(id)
        {

        }
    }

    /// <summary>
    /// Represents an entity that has an unique identifier, created, updated, deleted metadata
    /// and version as Guid.
    /// </summary>
    /// <typeparam name="TId">The identifier type</typeparam>
    public abstract class EntityWithAllMetaAndVersionAsGuid<TId> :
        EntityWithAllMetaAndVersion<TId, Guid>, IHaveVersionAsGuid
        where TId : IEquatable<TId>
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        protected EntityWithAllMetaAndVersionAsGuid()
        {

        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="id">The unique identifier</param>
        protected EntityWithAllMetaAndVersionAsGuid(TId id) : base(id)
        {

        }
    }
}
