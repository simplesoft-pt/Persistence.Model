using System;

namespace SimpleSoft.Persistence.Model.Tests.Abstractions
{
    public class EntityStringId : Entity<string>
    {
        public EntityStringId() { }

        public EntityStringId(string id) : base(id) { }
    }

    public class EntityIntId : Entity<int>
    {
        public EntityIntId() { }

        public EntityIntId(int id) : base(id) { }
    }

    public class EntityLongId : Entity<long>
    {
        public EntityLongId() { }

        public EntityLongId(long id) : base(id) { }
    }

    public class EntityGuidId : Entity<Guid>
    {
        public EntityGuidId() { }

        public EntityGuidId(Guid id) : base(id) { }
    }
}
