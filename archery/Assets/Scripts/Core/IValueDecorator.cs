namespace Game.Core
{
    public interface IValueDecorator<T> where T : struct
    {
        public T Decorate(T value);
    }
}