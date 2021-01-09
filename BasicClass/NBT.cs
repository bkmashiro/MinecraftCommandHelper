namespace MinecraftCommandHelper
{
    interface INBT
    {
        string GetCaption();
    }
    public class NBT
    {
        public virtual string GetCaption()
        {
            return "NBT基类";
        }
    }
}
