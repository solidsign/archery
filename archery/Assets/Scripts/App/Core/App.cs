using MyLibs.Core;

namespace Game.Libraries.App
{
    public class App
    {
        public ITimeProvider Time { get; } = new UnityTimeProvider();
    }
}