namespace Aspinall.ArgumentChecker
{
    public static class FluentChecker
    {
        public static ArgumentChecker<T> CheckThat<T>(T argument, string name)
        {
            return new ArgumentChecker<T>(argument, name);
        }
    }
}
