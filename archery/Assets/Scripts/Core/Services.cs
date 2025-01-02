namespace Archery.Core
{
    public class Services
    {
        public ITimeProvider Time { get; } = new UnityTimeProvider();
    }
}