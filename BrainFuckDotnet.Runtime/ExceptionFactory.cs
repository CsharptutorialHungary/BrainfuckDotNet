namespace BrainFuckDotnet.Runtime
{
    public static class ExceptionFactory
    {
        public static BrainFuckException Create(Error error, params object[] args)
        {
            string key = error.ToString();
            string? str = Properties.Resources.ResourceManager.GetString(key);

            if (str == null)
                throw new InvalidOperationException($"key not found: {key}");

            string final = string.Format(str, args);
            return new BrainFuckException(final);
        }
    }
}