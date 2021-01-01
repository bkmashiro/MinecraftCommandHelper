using System.Collections.Generic;
using System.Text;
using System;

namespace MinecraftCommandHelper.BasicClass.Items.Proper
{
    public class Enchant
    {
        List<SingleEnchant> Enchants = new List<SingleEnchant>();
        public void AddEnchant(string name,int level)
        {
            SingleEnchant singleEnchant = new SingleEnchant();
            singleEnchant.enchant_name = name;
            singleEnchant.enchant_level = level;
            if (name=="" || level >32767 ||level<0)
            {
                throw new ArgumentNullException("非法参数");
            }
            Enchants.Add(singleEnchant);
        }
        public string GetAllEnchantCommand()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Enchants)
            {
                sb.Append(item.GetCommand());
            }
            return sb.ToString();
        }
    }

   public class SingleEnchant
    {
        public string enchant_name = "";
        public  int enchant_level = 0;
        public string GetCommand() => ($"{{id:{enchant_name},lvl:{enchant_level}s}}");

    }

}
