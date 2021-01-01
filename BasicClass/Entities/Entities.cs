using System;
using System.Collections.Generic;
using System.Reflection;

namespace MinecraftCommandHelper.Entities
{
    interface IEntities
    {
        string GetFullNBT(); //返还实体的最大NBT（忽略空值）
    }
    public class Entities : IEntities
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

        #region Discard
        #region DefaultSettings

        //private bool is_id_Default = true;
        //private bool is_Motion_Default = true;
        //private bool is_Position_Default = true;
        //private bool is_Rotation_Default = true;
        //private bool is_UUIDLeast_Default = true;
        //private bool is_UUIDMost_Default = true;
        //private bool is_UUID_Default = true;
        //private bool is_CustomName_Default = true;
        //private bool is_CustomNameVisible_Default = false;
        //private bool is_Silent_Default = true;
        //private bool is_Health_Default = true;
        //private bool is_Invulnerable_Default = false; //无敌
        //private bool is_Air_Default = true;
        //private bool is_Fire_Default = true;
        //private bool is_OnGround_Default = true;
        //private bool is_Dimension_Default = true;
        //private bool is_PortalCooldown_Default = true;
        //private bool is_FallDistance_Default = true;
        //private bool is_Glowing_Default = true;
        //private bool is_Tags_Default = true;
        //private bool is_Passengers_Default = true;
        #endregion
        //public void SetPassengers(List<Entities> _Passengers) { is_Passengers_Default = false; Passengers = _Passengers; }
        //public void SetPosition(double[] _postion) { is_Position_Default = false; Position = _postion; }
        //public void SetPosition(double a, double b, double c) { is_Position_Default = false; Position = new double[] { a, b, c }; }
        //public void SetRotation(double[] _rotation) { is_Rotation_Default = false; Rotation = _rotation; }
        //public void SetRotation(double a, double b) { is_Rotation_Default = false; Rotation = new double[] { a, b}; }
        //public void SetCustomName(string _name) { is_CustomName_Default = false;CustomName = _name; }
        //public void SetInvulnerable(bool _Invulnerable) { is_Invulnerable_Default = false; Invulnerable = _Invulnerable; }
        //public void SetCustomNameVisible(bool _CustomNameVisible) { is_CustomNameVisible_Default = false; CustomNameVisible = _CustomNameVisible; }
        //public void SetSilent(bool _Silent) { is_Silent_Default = false; Silent = _Silent; }
        //public void SetHealth(int _Health) { is_Health_Default = false; Health = _Health; }
        //public void SetAir(int _Air) { is_Air_Default = false; Air = _Air; }
        //public void SetFire(int _Fire) { is_Fire_Default = false; Fire = _Fire; }
        //public void SetDimension(int _Dimension) { is_Dimension_Default = false; Dimension = _Dimension; }
        //public void SetPortalCooldown(int _PortalCooldown) { is_PortalCooldown_Default = false; PortalCooldown = _PortalCooldown; }
        //public void SetFallDistance(int _FallDistance) { is_FallDistance_Default = false; FallDistance = _FallDistance; }
        //public void SetGlowing(bool _Glowing) { is_Glowing_Default = false; CustomNameVisible = _Glowing; }
        //public void SetTags(List<string> _tags) { is_Tags_Default = false; Tags = _tags; }

        //public void SetId(string _id) { is_id_Default = false; id = _id; }
        //public void SetMotion(double[] _motion) { is_Motion_Default = false; Motion = _motion; }
        //public void SetMotion(double a, double b, double c) { is_Motion_Default = false; Motion = new double[] { a, b, c }; }

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

        public string GetFullNBT()
        {
            return $"";
        }


    }
}
