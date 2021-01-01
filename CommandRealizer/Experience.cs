namespace MinecraftCommandHelper.CommandRealizer
{
    class Experience
    {
        Selectors Selector = new Selectors();
        int? val = null;
        bool IsLevel = false;
        ExperienceMode mode = ExperienceMode.add;

        string[] modes = new string[] { "add", "set", "query" };
        enum ExperienceMode
        {
            add, set, query,
        }

        public string Realize_Experience() => $"experience {modes[(int)mode]} {Selector.GetSeletor()} {val ?? 10} {(IsLevel ? "levels" : "")}";
    }
}
