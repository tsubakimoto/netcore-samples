namespace MiddlewareSample.Services
{
    public class MyService : IMyService
    {
        public string Say(string name)
        {
            return $"Hello, {name}";
        }
    }
}
