using System.Collections.Generic;

namespace MinecraftCommandHelper.BasicClass.Items
{
    public class Items:INBT
    {
        //名称
        string id = string.Empty;
        //数量
        int? Count = null;
        //附魔列表
        BasicClass.Items.Proper.Enchant Enchant = new Proper.Enchant();
        //附加值
        int? Damage = null;
        //Lore
        //特殊属性
        //特殊槽位
        List<string> Tags = new List<string>();


        private string Getid() => $"{(id == null ? null : $"id:{id},")}";
        private string GetCount() => $"{(Count == null ? null : $"Count:{Count},")}";
        private string GetDamage() => $"{(Damage == null ? null : $"Damage:{Damage},")}";
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
        public string GetItemNBT()
        {
            string s = "";
            return s;
        }
        public string GetCaption() =>"物品NBT";
    }
}
