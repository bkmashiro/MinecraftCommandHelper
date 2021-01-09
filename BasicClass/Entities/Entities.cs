using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Media;

namespace MinecraftCommandHelper.Entities
{
    interface IEntities
    {
        string GetFullNBT(); //返还实体的最大NBT（忽略空值）
    }
    public class Entities : NBT, INBT, IEntities
    {
        //Properties

        public string id = string.Empty;
        public double?[] Motion = null;
        public double?[] Position = null;
        public double?[] Rotation = null;
        public long? UUIDLeast = null;
        public long? UUIDMost = null;
        public long? UUID = null;
        public string CustomName = string.Empty;
        public bool? CustomNameVisible = null;
        public bool? Silent = null;
        public int? Health = null;
        public bool? Invulnerable = null; //无敌
        public int? Air = null;
        public int? Fire = null;
        public bool? OnGround = null;
        public int? Dimension = null;
        public int? PortalCooldown = null;
        public double? FallDistance = null;
        public bool? Glowing = null;
        public List<string> Tags = new List<string>();
        public List<Entities> Passengers = new List<Entities>();

        //Commands     



        private string GetID() => $"{(id == string.Empty ? null : $"id:{id},")}";
        private string GetMotion() => $"{(Motion == null ? null : $"Motion:[{Motion[0]},{Motion[1]},{Motion[2]}],")}";
        private string GetPosition() => $"{(Position == null ? null : $"Postion:[{Position[0]},{Position[1]},{Position[2]}],")}";
        private string GetRotation() => $"{(Rotation == null ? null : $"Rotation:[{Rotation[0]}f,{Rotation[1]}f],")}";
        private string GetCustomName() => $"{(CustomName == string.Empty ? null : $"CustomName:\'{{\"text\":\"{CustomName}\"}}\',")}";
        private string GetCustomNameVisible() => $"{(CustomNameVisible == null ? null : $"CustomNameVisible:{(CustomNameVisible ?? false ? 1 : 0)}b,")}";
        private string GetSilent() => $"{(Silent == null ? null : $"Silent:{(Silent ?? false ? 1 : 0)}b,")}";
        private string GetHealth() => $"{(Health == null ? null : $"Health:{Health}f,")}";
        private string GetInvulnerable() => $"{(Invulnerable == null ? null : $"Invulnerable:{(Invulnerable ?? false ? 1 : 0)}b,")}";
        private string GetAir() => $"{(Air == null ? null : $"Air:{Air}s,")}";
        private string GetFire() => $"{(Fire == null ? null : $"Fire:{Fire}s,")}";
        private string GetOnGround() => $"{(OnGround == null ? null : $"OnGround:{(OnGround ?? false ? 1 : 0)}b,")}";
        private string GetDimension() => $"{(Dimension == null ? null : $"Dimension:{Dimension},")}";
        private string GetPortalCooldown() => $"{(PortalCooldown == null ? null : $"PortalCooldown:{PortalCooldown},")}";
        private string GetFallDistance() => $"{(FallDistance == null ? null : $"FallDistance:{FallDistance},")}";
        private string GetGlowing() => $"{(Glowing == null ? null : $"Glowing:{(Glowing ?? false ? 1 : 0)}b,")}";
        private string GetSingleTag(int index) => $"\"{Tags[index]}\"";
        private string GetTags()
        {
            if (Tags.Count == 0)
            {
                return "";
            }
            else if (Tags.Count == 1)
            {
                return $"Tags:[{GetSingleTag(0)}],";
            }
            else
            {
                string s = "Tags:";
                foreach (string tag in Tags)
                {
                    s += $"\"{tag}\",";
                    //QUESTION 是否删除末尾句号
                }
                return s += "],";
            }
        }
        private string GetPassengers()
        {
            if (Passengers.Count == 0)
            {
                return "";
            }
            else if (Passengers.Count == 1)
            {
                return $"Passengers:[{{{Passengers[0].GetEntityNBT()}}}],";
            }
            else
            {
                string s = "Passengers:";
                foreach (var passenger in Passengers)
                {
                    s += $"{{{passenger.GetEntityNBT()}}},";
                    //QUESTION 是否删除末尾句号
                }
                return s += "],";
            }
        }

        public override string GetCaption() => "实体NBT";


        #region DefaultSettings

        #endregion
        public string GetEntityNBT()
        {
            string s = "";
            s = $"{GetID()}{GetMotion()}{GetPosition()}{GetRotation()}{GetCustomName()}" +
                $"{GetCustomNameVisible()}{GetSilent()}{GetHealth()}{GetInvulnerable()}" +
                $"{GetAir()}{GetFire()}{GetOnGround()}{GetDimension()}{GetPortalCooldown()}" +
                $"{GetFallDistance()}{GetGlowing()}{GetTags()}{GetPassengers()}";
            return s;
        }
        /// <summary>
        /// b为false，不添加ID
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public string GetEntityNBT(bool b)
        {
            string s = "";
            s = $"{(b ? GetID() : "")}{GetMotion()}{GetPosition()}{GetRotation()}{GetCustomName()}" +
                $"{GetCustomNameVisible()}{GetSilent()}{GetHealth()}{GetInvulnerable()}" +
                $"{GetAir()}{GetFire()}{GetOnGround()}{GetDimension()}{GetPortalCooldown()}" +
                $"{GetFallDistance()}{GetGlowing()}{GetTags()}{GetPassengers()}";
            return s;
        }

        public virtual string GetFullNBT()
        {
            return $"{GetEntityNBT()}";
        }



        Paragraph _paragraph = new Paragraph();
        ColorfulTextBase cb = new ColorfulTextBase();
        public Paragraph GetColorNBT()
        {
            _paragraph.Inlines.Clear();

            AddInLines(GetID(), pv.color_string);
            AddInLines(GetMotion(), pv.color_array);
            AddInLines(GetPosition(), pv.color_array);
            AddInLines(GetRotation(), pv.color_array);
            AddInLines(GetCustomName(), pv.color_string);
            AddInLines(GetCustomNameVisible(), pv.color_bool);
            AddInLines(GetSilent(), pv.color_bool);
            AddInLines(GetHealth(), pv.color_int);
            AddInLines(GetInvulnerable(), pv.color_bool);
            AddInLines(GetAir(), pv.color_int);
            AddInLines(GetFire(), pv.color_int);
            AddInLines(GetOnGround(), pv.color_bool);
            AddInLines(GetDimension(), pv.color_int);
            AddInLines(GetPortalCooldown(), pv.color_int);
            AddInLines(GetFallDistance(), pv.color_int);
            AddInLines(GetGlowing(), pv.color_bool);
            AddInLines(GetTags(), pv.color_array);
            AddInLines(GetPassengers(), pv.color_odd);

            return _paragraph;
        }
        private void AddInLines(string s, Brush a)
        {

            if (s != null)
            {
                s += '\r';
                _paragraph.Inlines.Add(cb.GetRun(s, a));
            }
        }





    }
}
