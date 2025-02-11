using System;
using System.Collections.Generic;
using System.Linq;

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

            _jobs.RemoveAll(x => x.IsDone);
        }

        public bool HasJob(Predicate<TJobType> jobPredicate)
        {
            return _jobs.Exists(jobPredicate);
        }

        public int CountJobs(Func<TJobType, bool> jobPredicate)
        {
            return _jobs.Count(jobPredicate);
        }
    }
}