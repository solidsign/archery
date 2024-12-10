namespace Game.Core
{
    public interface IDecoratableValue<T> : IValue<T> where T : struct
    {
        void UpdateBaseValue(T baseValue);
        void Decorate(IValueDecorator<T> decorator);
        void RemoveDecorator(IValueDecorator<T> decorator);
    }
}