namespace MinecraftCommandHelper.Entities
{
    public class mobs : Entities,IEntities
    {
        public double? AbsorptionAmount = null;
        public int? AttackTime = null;
        public int? HurtTime = null;
        public int? HurtByTimestamp = null;
        public int? DeathTime = null;
        //Attributes
        //ActiveEffects
        public BasicClass.Items.Items[] ArmorItems = new BasicClass.Items.Items[4];//TODO
        public BasicClass.Items.Items[] HandItems = new BasicClass.Items.Items[2];//TODO
        public double?[] ArmorDropChances = null;
        public double?[] HandDropChances = null;
        public bool? LeftHanded = null;
        public string DeathLootTable = string.Empty;
        public long? DeathLootTableSeed = null;
        public bool? CanPickUpLoot = null;
        public bool? NoAI = null;
        public bool? PersistenceRequired = null;  //不会被刷掉
        public bool? Leashed = null; //拴住
        public Leash leash = new Leash();//TODO
        public string Team = string.Empty;

        private string GetAbsorptionAmount() => $"{(AbsorptionAmount == null ? null : $"AbsorptionAmount:{AbsorptionAmount},")}";
        private string GetAttackTime() => $"{(AttackTime == null ? null : $"AttackTime:{AttackTime},")}";
        private string GetHurtTime() => $"{(HurtTime == null ? null : $"HurtTime:{HurtTime},")}";
        private string GetHurtByTimestamp() => $"{(HurtByTimestamp == null ? null : $"HurtByTimestamp:{HurtByTimestamp},")}";
        private string GetDeathTime() => $"{(DeathTime == null ? null : $"DeathTime:{DeathTime},")}";
        private string GetArmorDropChances() => $"{(ArmorDropChances == null ? null : $"ArmorDropChances:{ArmorDropChances},")}";
        private string GetHandDropChances() => $"{(HandDropChances == null ? null : $"HandDropChances:{HandDropChances},")}";
        private string GetLeftHanded() => $"{(LeftHanded == null ? null : $"LeftHanded:{LeftHanded},")}";
        private string GetDeathLootTable() => $"{(DeathLootTable == null ? null : $"DeathLootTable:{DeathLootTable},")}";
        private string GetCanPickUpLoot() => $"{(CanPickUpLoot == null ? null : $"CanPickUpLoot:{CanPickUpLoot},")}";
        private string GeNoAI() => $"{(NoAI == null ? null : $"NoAI:{NoAI},")}";
        private string GetPersistenceRequired() => $"{(PersistenceRequired == null ? null : $"PersistenceRequired:{PersistenceRequired},")}";
        private string GetLeashed() => $"{(Leashed == null ? null : $"Leashed:{Leashed},")}";
        private string GetTeam() => $"{(Team == null ? null : $"Team:{Team},")}";

        public new string GetFullNBT()
        {
            return "这是mobs的NBT";
        }







    }
}
