namespace NetCoreIdentity.Data.Const
{
    public static class Routes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Registration
        {
            public const string Base = Routes.Base + "/registration";

        }
    }
}
