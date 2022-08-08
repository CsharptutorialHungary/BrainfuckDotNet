namespace BrainFuckDotnet.Runtime
{
    public static class ExceptionFactory
    {
        private static string CreateMessage(Error error, object[] args)
        {
            string key = error.ToString();
            string? str = Properties.Resources.ResourceManager.GetString(key);

            if (str == null)
                throw new InvalidOperationException($"key not found: {key}");

            string final = string.Format(str, args);
            return final;
        }

        public static BrainFuckException Create(Error error, params object[] args)
        {
            string final = CreateMessage(error, args);
            return new BrainFuckException(final);
        }

        public static BrainFuckException Create(Error error, Exception inner, params object[] args)
        {
            string final = CreateMessage(error, args);
            return new BrainFuckException(final, inner);
        }
    }
}