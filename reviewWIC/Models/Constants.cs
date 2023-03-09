namespace reviewWIC.Models
{
    public static class Constants
    {
        public static class Roles
        {
            public const string DataAdmin = "Data Administrator";
            public const string SysAdmin = "System Administrator";
            public const string User = "User";
        }

        public static class Policies
        {
            public const string RequireSysAdmin = "RequireSysAdmin";
            public const string RequireDataAdmin = "RequireDataAdmin";
        }
    }
}
