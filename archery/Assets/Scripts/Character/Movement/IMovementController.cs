using UnityEngine;

namespace Archery.Character.Movement
{
    public interface IMovementController
    {
        PlayerJobs<IPlayerMovementJob> Jobs { get; }

        /// <summary>
        /// Tries to move in given delta
        /// </summary>
        /// <param name="delta">Move delta</param>
        /// <returns>Resulted movement</returns>
        void Move(Vector3 delta);

        /// <summary>
        /// Applies the resulting movement
        /// </summary>
        void Apply();
    }
}