namespace MinecraftCommandHelper.Entities
{
    public class Feedable :  Entities , IEntities
    {
        public bool? InLove = null;
        public int? Age = null;
        public int? ForcedAge = null;
        public string Owner = string.Empty;
        public long? OwnerUUID = null;
        public bool? Sitting = false;

        private string GetInLove() => $"{(InLove == null ? null : $"InLove:{InLove},")}";
        private string GetAge() => $"{(Age == null ? null : $"Age:{Age},")}";
        private string GetForcedAge() => $"{(ForcedAge == null ? null : $"ForcedAge:{ForcedAge},")}";
        private string GetOwner() => $"{(Owner == string.Empty ? null : $"Owner:{Owner},")}";
        private string GetOwnerUUID() => $"{(OwnerUUID == null ? null : $"OwnerUUID:{OwnerUUID},")}";
        private string GetSitting() => $"{(Sitting == null ? null : $"Sitting:{Sitting},")}";

        public string GetFeedableNBT() => $"{GetEntityNBT()}{GetInLove()}{GetAge()}{GetForcedAge()}{GetOwner()}{GetOwnerUUID()}{GetSitting()}";
        public new string GetFullNBT() { return "这是Feedable的NBT"; }
    }
}
