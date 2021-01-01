namespace MinecraftCommandHelper.CommandRealizer
{
    class Gamemode
    {
        private string[] gamemode = { "survial", "creative", "adventure", "spectator" };
        public enum Gm
        {
            survial, creative, adventure, spectator,
        }

        public string realize_Gamemode(int g) => $"gamemode {gamemode[g]}";
        
        


    }
}
