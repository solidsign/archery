namespace MyLibs.Core
{
    public interface IValue<T> where T : struct
    {
        public T Value { get; }
    }
}