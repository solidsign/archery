using System.Collections.Generic;

namespace Game.Core
{
    public class GravityInfluenceReceiver : IGravityInfluenceReceiver
    {
        private readonly IMovingObjectModel _obj;
        private readonly Dictionary<IGravityInfluence, GravityAccelerationDecorator> _influences = new();

        public GravityInfluenceReceiver(IMovingObjectModel obj)
        {
            _obj = obj;
        }

        public void AddGravityInfluence(IGravityInfluence influence)
        {
            var decorator = new GravityAccelerationDecorator(influence.AccelerationFromGravity);
            _influences.Add(influence, decorator);
            _obj.DecoratableAcceleration.Decorate(decorator);
        }
        
        public void RemoveGravityInfluence(IGravityInfluence influence)
        {
            _obj.DecoratableAcceleration.RemoveDecorator(_influences[influence]);
            _influences.Remove(influence);
        }
    }
}