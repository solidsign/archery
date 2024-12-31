using System.Collections.Generic;

namespace Archery.Character
{
    public class PlayerJobs<TJobType> where TJobType : IPlayerJob
    {
        private readonly List<TJobType> _jobs = new();
        
        public void Add(TJobType job)
        {
            _jobs.Add(job);
        }

        public void Update()
        {
            if (_jobs.Count == 0) return;
            
            foreach (var playerJob in _jobs)
            {
                playerJob.Update();
            }

            _jobs.RemoveAll(x => x.IsDone is false);
        }

        public bool HasJob<T>()
        {
            return _jobs.Exists(x => x is T);
        }
    }
}