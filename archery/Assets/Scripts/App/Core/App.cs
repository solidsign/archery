using MyLibs.Core;

namespace App.Core
{
    public class App
    {
        public ITimeProvider Time { get; } = new UnityTimeProvider();
    }
}