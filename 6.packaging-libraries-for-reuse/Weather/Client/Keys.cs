namespace Client
{
    using System;

    public static class Keys
    {
        public const string OpenWeatherMapApiKey = "834afebb501cb78e11525767b6ba7c3f";

        public static void ThrowIfKeysNotSet()
        {
            if (string.IsNullOrWhiteSpace(OpenWeatherMapApiKey))
            {
                throw new ArgumentException("You need to add your API keys");
            }
        }
    }
}
