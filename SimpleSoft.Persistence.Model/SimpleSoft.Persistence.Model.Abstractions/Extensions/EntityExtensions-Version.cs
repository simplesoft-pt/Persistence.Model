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
using SimpleSoft.Persistence.Model.Exceptions;

// ReSharper disable once CheckNamespace
namespace SimpleSoft.Persistence.Model
{
    public static partial class EntityExtensions
    {
        /// <summary>
        /// Throws an exception if the versions are different.
        /// </summary>
        /// <typeparam name="T">The version type</typeparam>
        /// <param name="entity">The entity to validate</param>
        /// <param name="expectedVersion">The expected version value</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="VersionMismatchException"></exception>
        public static void ThrowIfMismatch<T>(this IHaveVersion<T> entity, T expectedVersion)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            if (!entity.Version.Equals(expectedVersion))
                throw new VersionMismatchException(entity.Version, expectedVersion);
        }

        /// <summary>
        /// Throws an exception if the versions are different.
        /// </summary>
        /// <param name="entity">The entity to validate</param>
        /// <param name="expectedVersion">The expected version value</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="VersionMismatchException"></exception>
        public static void ThrowIfMismatch(this IHaveVersion<byte[]> entity, byte[] expectedVersion)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            if (entity.Version == null)
            {
                if (expectedVersion != null)
                    throw new VersionMismatchException(null, expectedVersion);
            }
            else if (expectedVersion == null)
            {
                throw new VersionMismatchException(entity.Version, null);
            }
            else if (!ReferenceEquals(entity.Version, expectedVersion) &&
                     entity.Version.Length != expectedVersion.Length)
            {
                for (var i = 0; i < entity.Version.Length; i++)
                {
                    if (entity.Version[i] != expectedVersion[i])
                        throw new VersionMismatchException(entity.Version, expectedVersion);
                }
            }
        }

        /// <summary>
        /// Throws an exception if the versions are different.
        /// </summary>
        /// <param name="entity">The entity to validate</param>
        /// <param name="expectedVersion">The expected version value</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="VersionMismatchException"></exception>
        public static void ThrowIfMismatch(this IHaveVersion<Guid> entity, Guid expectedVersion)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            if (entity.Version != expectedVersion)
                throw new VersionMismatchException(entity.Version, expectedVersion);
        }

        /// <summary>
        /// Throws an exception if the versions are different.
        /// </summary>
        /// <param name="entity">The entity to validate</param>
        /// <param name="expectedVersion">The expected version value</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="VersionMismatchException"></exception>
        public static void ThrowIfMismatch(this IHaveVersion<long> entity, long expectedVersion)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            if (entity.Version != expectedVersion)
                throw new VersionMismatchException(entity.Version, expectedVersion);
        }

        /// <summary>
        /// Throws an exception if the versions are different.
        /// </summary>
        /// <param name="entity">The entity to validate</param>
        /// <param name="expectedVersion">The expected version value</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="VersionMismatchException"></exception>
        public static void ThrowIfMismatch(this IHaveVersion<string> entity, string expectedVersion)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            if (entity.Version != expectedVersion)
                throw new VersionMismatchException(entity.Version, expectedVersion);
        }
    }
}