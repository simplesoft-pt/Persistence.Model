using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SimpleSoft.Persistence.Model.Tests.Abstractions.Extensions.Linq
{
    public class EntityTests
    {
        [Fact]
        public void GivenNullArgumentsWhenGettingByIdThenArgumentNullExceptionMustBeThrown()
        {
            IEnumerable<IEntity<string>> items = null;
            var id = "";
            Assert.Throws<ArgumentNullException>(() => { items.GetById(id); });

            items = Enumerable.Empty<IEntity<string>>();
            id = null;
            Assert.Throws<ArgumentNullException>(() => { items.GetById(id); });
        }

        [Fact]
        public void GivenNullArgumentsWhenContainsIdThenArgumentNullExceptionMustBeThrown()
        {
            IEnumerable<IEntity<string>> items = null;
            var id = "";
            Assert.Throws<ArgumentNullException>(() => { items.ContainsId(id); });

            items = Enumerable.Empty<IEntity<string>>();
            id = null;
            Assert.Throws<ArgumentNullException>(() => { items.ContainsId(id); });
        }

        [Fact]
        public void GivenNullArgumentsWhenFilterByIdThenArgumentNullExceptionMustBeThrown()
        {
            IQueryable<IEntity<string>> items = null;
            var id = "";
            Assert.Throws<ArgumentNullException>(() => { items.WhereId(id); });

            items = Enumerable.Empty<IEntity<string>>().AsQueryable();
            id = null;
            Assert.Throws<ArgumentNullException>(() => { items.WhereId(id); });
        }

        [Fact]
        public void GivenACollectionWithAKnownIdWhenGettingTheIdThenAnEntityMustBeReturned()
        {
            const int id = 1;
            IEnumerable<IEntity<int>> items = new[]
            {
                new EntityIntId(3),
                new EntityIntId(2),
                new EntityIntId(1),
                new EntityIntId(0),
            };

            var entity = items.GetById(id);
            Assert.NotNull(entity);
            Assert.Equal(id, entity.Id);
        }

        [Fact]
        public void GivenACollectionWithoutAKnownIdWhenGettingTheIdThenNullBeReturned()
        {
            const int id = 1;
            IEnumerable<IEntity<int>> items = new[]
            {
                new EntityIntId(3),
                new EntityIntId(2),
                new EntityIntId(0),
            };

            var entity = items.GetById(id);
            Assert.Null(entity);
        }

        [Fact]
        public void GivenACollectionWithDuplicatedKnownIdWhenGettingTheIdThenInvalidOperationExceptionMustBeThrown()
        {
            const int id = 1;
            IEnumerable<IEntity<int>> items = new[]
            {
                new EntityIntId(3),
                new EntityIntId(2),
                new EntityIntId(1),
                new EntityIntId(1),
                new EntityIntId(0),
            };

            Assert.Throws<InvalidOperationException>(() => items.GetById(id));
        }

        [Fact]
        public void GivenACollectionWithAKnownIdWhenCheckingIfContainsIdThenTrueMustBeReturned()
        {
            const int id = 1;
            IEnumerable<IEntity<int>> items = new[]
            {
                new EntityIntId(3),
                new EntityIntId(2),
                new EntityIntId(1),
                new EntityIntId(0),
            };

            var containsId = items.ContainsId(id);
            Assert.True(containsId);
        }

        [Fact]
        public void GivenACollectionWithAKnownIdWhenCheckingIfContainsIdThenFalseMustBeReturned()
        {
            const int id = 1;
            IEnumerable<IEntity<int>> items = new[]
            {
                new EntityIntId(3),
                new EntityIntId(2),
                new EntityIntId(0),
            };

            var containsId = items.ContainsId(id);
            Assert.False(containsId);
        }

        [Fact]
        public void GivenACollectionWithDuplicatedKnownIdWhenCheckingIfContainsIdThenTrueMustBeReturned()
        {
            const int id = 1;
            IEnumerable<IEntity<int>> items = new[]
            {
                new EntityIntId(3),
                new EntityIntId(2),
                new EntityIntId(1),
                new EntityIntId(1),
                new EntityIntId(0),
            };

            var containsId = items.ContainsId(id);
            Assert.True(containsId);
        }

        [Fact]
        public void GivenACollectionWithKnownIdsWhenFilterByIdThenANotEmptyCollectionMustBeReturned()
        {
            const int id = 1;
            IQueryable<IEntity<int>> items = new[]
            {
                new EntityIntId(3),
                new EntityIntId(2),
                new EntityIntId(1),
                new EntityIntId(1),
                new EntityIntId(0),
            }.AsQueryable();

            var entities = items.WhereId(id);
            Assert.NotNull(entities);
            Assert.NotEmpty(entities);
        }

        [Fact]
        public void GivenACollectionWithoutKnownIdsWhenFilterByIdThenAnEmptyCollectionMustBeReturned()
        {
            const int id = 1;
            IQueryable<IEntity<int>> items = new[]
            {
                new EntityIntId(3),
                new EntityIntId(2),
                new EntityIntId(0),
            }.AsQueryable();

            var entities = items.WhereId(id);
            Assert.NotNull(entities);
            Assert.Empty(entities);
        }
    }
}
