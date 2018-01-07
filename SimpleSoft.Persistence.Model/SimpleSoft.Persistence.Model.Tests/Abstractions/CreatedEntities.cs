using System;

namespace SimpleSoft.Persistence.Model.Tests.Abstractions
{
    public abstract class CreatedMeta<T> : IHaveCreatedMeta<T>
    {
        protected CreatedMeta() { }

        protected CreatedMeta(T by, DateTimeOffset on)
        {
            CreatedBy = by;
            CreatedOn = on;
        }

        public DateTimeOffset CreatedOn { get; set; }

        public T CreatedBy { get; set; }
    }

    public abstract class CreatedLocalMeta<T> : IHaveCreatedLocalMeta<T>
    {
        protected CreatedLocalMeta() { }

        protected CreatedLocalMeta(T by, DateTime on)
        {
            CreatedBy = by;
            CreatedOn = on;
        }

        public DateTime CreatedOn { get; set; }

        public T CreatedBy { get; set; }
    }

    public class CreatedStringMeta : CreatedMeta<string>, IHaveCreatedMeta
    {
        public CreatedStringMeta() { }

        public CreatedStringMeta(string by, DateTimeOffset on) : base(by, on) { }
    }

    public class CreatedLongMeta : CreatedMeta<long>
    {
        public CreatedLongMeta() { }

        public CreatedLongMeta(long by, DateTimeOffset on) : base(by, on) { }
    }

    public class CreatedLocalStringMeta : CreatedLocalMeta<string>, IHaveCreatedLocalMeta
    {
        public CreatedLocalStringMeta() { }

        public CreatedLocalStringMeta(string by, DateTime on) : base(by, on) { }
    }

    public class CreatedLocalLongMeta : CreatedLocalMeta<long>
    {
        public CreatedLocalLongMeta() { }

        public CreatedLocalLongMeta(long by, DateTime on) : base(by, on) { }
    }
}
