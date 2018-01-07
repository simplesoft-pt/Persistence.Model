using System;
using System.Linq;
using Xunit;

namespace SimpleSoft.Persistence.Model.Tests.Abstractions.Extensions.Linq
{
    public class CreatedQueryableTests
    {
        [Fact]
        public void GivenNullArgumentsWhenFilterByCreatedThenArgumentNullExceptionMustBeThrown()
        {
            IQueryable<IHaveCreatedMeta<string>> items = null;
            var by = "";
            Assert.Throws<ArgumentNullException>(() => items.WhereWasCreatedBy(by));
            Assert.Throws<ArgumentNullException>(() => items.WhereWasCreatedBy(by, StringComparison.OrdinalIgnoreCase));

            items = Enumerable.Empty<IHaveCreatedMeta<string>>().AsQueryable();
            by = null;
            Assert.Throws<ArgumentNullException>(() => items.WhereWasCreatedBy(by));
            Assert.Throws<ArgumentNullException>(() => items.WhereWasCreatedBy(by, StringComparison.OrdinalIgnoreCase));
        }

        [Fact]
        public void GivenNullArgumentsWhenFilterByLocalCreatedThenArgumentNullExceptionMustBeThrown()
        {
            IQueryable<IHaveCreatedLocalMeta<string>> items = null;
            var by = "";
            Assert.Throws<ArgumentNullException>(() => items.WhereWasCreatedLocallyBy(by));
            Assert.Throws<ArgumentNullException>(() => items.WhereWasCreatedLocallyBy(by, StringComparison.OrdinalIgnoreCase));

            items = Enumerable.Empty<IHaveCreatedLocalMeta<string>>().AsQueryable();
            by = null;
            Assert.Throws<ArgumentNullException>(() => items.WhereWasCreatedLocallyBy(by));
            Assert.Throws<ArgumentNullException>(() => items.WhereWasCreatedLocallyBy(by, StringComparison.OrdinalIgnoreCase));
        }

        [Fact]
        public void GivenACollectionWithKnownCreatedByWhenFilterByCreatedThenANotEmptyCollectionMustBeReturned()
        {
            const long by = 1;
            IQueryable<IHaveCreatedMeta<long>> items = new[]
            {
                new CreatedLongMeta(3, DateTimeOffset.Now),
                new CreatedLongMeta(2, DateTimeOffset.Now),
                new CreatedLongMeta(1, DateTimeOffset.Now),
                new CreatedLongMeta(1, DateTimeOffset.Now),
                new CreatedLongMeta(0, DateTimeOffset.Now),
            }.AsQueryable();

            var entities = items.WhereWasCreatedBy(by);
            Assert.NotNull(entities);
            Assert.NotEmpty(entities);
        }

        [Fact]
        public void GivenACollectionWithKnownCreatedByWhenFilterByLocalCreatedThenANotEmptyCollectionMustBeReturned()
        {
            const long by = 1;
            IQueryable<IHaveCreatedLocalMeta<long>> items = new[]
            {
                new CreatedLocalLongMeta(3, DateTime.Now),
                new CreatedLocalLongMeta(2, DateTime.Now),
                new CreatedLocalLongMeta(1, DateTime.Now),
                new CreatedLocalLongMeta(1, DateTime.Now),
                new CreatedLocalLongMeta(0, DateTime.Now),
            }.AsQueryable();

            var entities = items.WhereWasCreatedLocallyBy(by);
            Assert.NotNull(entities);
            Assert.NotEmpty(entities);
        }

        [Fact]
        public void GivenACollectionWithoutKnownCreatedByWhenFilterByCreatedThenAnEmptyCollectionMustBeReturned()
        {
            const long by = 1;
            IQueryable<IHaveCreatedMeta<long>> items = new[]
            {
                new CreatedLongMeta(3, DateTimeOffset.Now),
                new CreatedLongMeta(2, DateTimeOffset.Now),
                new CreatedLongMeta(0, DateTimeOffset.Now),
            }.AsQueryable();

            var entities = items.WhereWasCreatedBy(by);
            Assert.NotNull(entities);
            Assert.Empty(entities);
        }

        [Fact]
        public void GivenACollectionWithoutKnownCreatedByWhenFilterByLocalCreatedThenAnEmptyCollectionMustBeReturned()
        {
            const long by = 1;
            IQueryable<IHaveCreatedLocalMeta<long>> items = new[]
            {
                new CreatedLocalLongMeta(3, DateTime.Now),
                new CreatedLocalLongMeta(2, DateTime.Now),
                new CreatedLocalLongMeta(0, DateTime.Now),
            }.AsQueryable();

            var entities = items.WhereWasCreatedLocallyBy(by);
            Assert.NotNull(entities);
            Assert.Empty(entities);
        }

        [Fact]
        public void GivenACollectionWithKnownCreatedByWhenFilterByCreatedIgnoreCaseThenANotEmptyCollectionMustBeReturned()
        {
            const string by = "BBBB";
            IQueryable<IHaveCreatedMeta<string>> items = new[]
            {
                new CreatedStringMeta("dddd", DateTimeOffset.Now), 
                new CreatedStringMeta("cccc", DateTimeOffset.Now), 
                new CreatedStringMeta("bbbb", DateTimeOffset.Now), 
                new CreatedStringMeta("bbbb", DateTimeOffset.Now), 
                new CreatedStringMeta("aaaa", DateTimeOffset.Now), 
            }.AsQueryable();

            var entities = items.WhereWasCreatedBy(by, StringComparison.OrdinalIgnoreCase);
            Assert.NotNull(entities);
            Assert.NotEmpty(entities);
        }

        [Fact]
        public void GivenACollectionWithKnownCreatedByWhenFilterByLocalCreatedIgnoreCaseThenANotEmptyCollectionMustBeReturned()
        {
            const string by = "BBBB";
            IQueryable<IHaveCreatedLocalMeta<string>> items = new[]
            {
                new CreatedLocalStringMeta("dddd", DateTime.Now), 
                new CreatedLocalStringMeta("cccc", DateTime.Now), 
                new CreatedLocalStringMeta("bbbb", DateTime.Now), 
                new CreatedLocalStringMeta("bbbb", DateTime.Now), 
                new CreatedLocalStringMeta("aaaa", DateTime.Now), 
            }.AsQueryable();

            var entities = items.WhereWasCreatedLocallyBy(by, StringComparison.OrdinalIgnoreCase);
            Assert.NotNull(entities);
            Assert.NotEmpty(entities);
        }

        [Fact]
        public void GivenACollectionWithKnownCreatedByWhenFilterByCreatedNotIgnoringCaseThenANotEmptyCollectionMustBeReturned()
        {
            const string by = "BBBB";
            IQueryable<IHaveCreatedMeta<string>> items = new[]
            {
                new CreatedStringMeta("dddd", DateTimeOffset.Now),
                new CreatedStringMeta("cccc", DateTimeOffset.Now),
                new CreatedStringMeta("bbbb", DateTimeOffset.Now),
                new CreatedStringMeta("bbbb", DateTimeOffset.Now),
                new CreatedStringMeta("aaaa", DateTimeOffset.Now),
            }.AsQueryable();

            var entities = items.WhereWasCreatedBy(by, StringComparison.Ordinal);
            Assert.NotNull(entities);
            Assert.Empty(entities);
        }

        [Fact]
        public void GivenACollectionWithKnownCreatedByWhenFilterByLocalCreatedNotIgnoringCaseThenANotEmptyCollectionMustBeReturned()
        {
            const string by = "BBBB";
            IQueryable<IHaveCreatedLocalMeta<string>> items = new[]
            {
                new CreatedLocalStringMeta("dddd", DateTime.Now),
                new CreatedLocalStringMeta("cccc", DateTime.Now),
                new CreatedLocalStringMeta("bbbb", DateTime.Now),
                new CreatedLocalStringMeta("bbbb", DateTime.Now),
                new CreatedLocalStringMeta("aaaa", DateTime.Now),
            }.AsQueryable();

            var entities = items.WhereWasCreatedLocallyBy(by, StringComparison.Ordinal);
            Assert.NotNull(entities);
            Assert.Empty(entities);
        }
    }
}
