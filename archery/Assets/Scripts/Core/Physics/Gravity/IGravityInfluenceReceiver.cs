namespace Game.Core
{
    public interface IGravityInfluenceReceiver
    {
        public void AddGravityInfluence(IGravityInfluence influence);
        public void RemoveGravityInfluence(IGravityInfluence influence);
    }
}