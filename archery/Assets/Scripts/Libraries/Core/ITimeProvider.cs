using UnityEngine;

namespace MyLibs.Core
{
    public interface ITimeProvider
    {
        public long Tick { get; }
        public float DeltaTime { get; }
    }

    public class UnityTimeProvider : ITimeProvider
    {
        public long Tick => Time.frameCount;
        public float DeltaTime => Time.deltaTime;
    }
}