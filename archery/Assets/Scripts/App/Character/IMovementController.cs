using UnityEngine;

namespace Game.Libraries.App.Character
{
    public interface IMovementController
    {
        /// <summary>
        /// Tries to move in given delta
        /// </summary>
        /// <param name="delta">Move delta</param>
        /// <returns>Resulted movement</returns>
        Vector3 Move(Vector3 delta);
        
        PlayerJobs<IPlayerMovementJob> Jobs { get; }
    }
}