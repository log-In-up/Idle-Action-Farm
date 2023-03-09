using UnityEngine;

namespace Player
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    public sealed class PlayerAnimator : MonoBehaviour
    {
        #region Fields
        private Animator _animator = null;

        private const string MOVEMENT_RATIO = "MovementRatio", IS_HARVESTING = "IsHarvesting";
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        #endregion

        #region Public methods
        internal void SetMovement(float movementValue)
        {
            _animator.SetFloat(MOVEMENT_RATIO, movementValue);
        }

        internal void SetHarvesting(bool harvesting)
        {
            _animator.SetBool(IS_HARVESTING, harvesting);
        }
        #endregion
    }
}
