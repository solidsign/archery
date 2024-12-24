using System.Collections.Generic;
using System.Linq;

namespace Game.Core
{
    public abstract class DecoratableValue<T> : IDecoratableValue<T> where T : struct
    {
        private readonly List<IValueDecorator<T>> _decorators = new();
        private T _baseValue;
        
        public T Value => _decorators.Aggregate(_baseValue, (current, decorator) => decorator.Decorate(current));

        protected DecoratableValue(T baseValue)
        {
            _baseValue = baseValue;
        }

        public void UpdateBaseValue(T baseValue)
        {
            _baseValue = baseValue;
        }
        
        public void Decorate(IValueDecorator<T> decorator)
        {
            _decorators.Add(decorator);
        }

        public void RemoveDecorator(IValueDecorator<T> decorator)
        {
            _decorators.Remove(decorator);
        }
    }
}