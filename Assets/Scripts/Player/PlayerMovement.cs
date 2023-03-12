using UnityEngine;
using Zenject;

namespace Player
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody))]
    public sealed class PlayerMovement : MonoBehaviour
    {
        #region Editor fields
        [SerializeField] private PlayerAnimator _animator;
        [SerializeField] private Transform _model = null;
        #endregion

        #region Fields
        private DynamicJoystick _dynamicJoystick;
        private PlayerData _playerData;
        private Rigidbody _rigidbody;
        private Vector3 _currentVelocity, _moveAmount;
        #endregion

        #region Zenject
        [Inject]
        private void Constructor(DynamicJoystick dynamicJoystick, PlayerData playerData)
        {
            _dynamicJoystick = dynamicJoystick;
            _playerData = playerData;
        }
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Move();
            Look();

            Animation();
        }

        private void FixedUpdate()
        {
            _rigidbody.MovePosition(_rigidbody.position + (transform.TransformDirection(_moveAmount) * Time.fixedDeltaTime));
        }
        #endregion

        #region Methods
        private void Move()
        {
            Vector3 moveDirection = new Vector3(_dynamicJoystick.Horizontal, 0.0f, _dynamicJoystick.Vertical).normalized;

            _moveAmount = Vector3.SmoothDamp(_moveAmount, moveDirection * _playerData.MovementSpeed, ref _currentVelocity, _playerData.SmoothTime);
        }

        private void Look()
        {
            if (_dynamicJoystick.Direction == Vector2.zero) return;

            float angle = Mathf.Atan2(_dynamicJoystick.Horizontal, _dynamicJoystick.Vertical) * Mathf.Rad2Deg;

            _model.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
        }

        private void Animation()
        {
            float movementValue = Mathf.Clamp(_moveAmount.magnitude / _playerData.MovementSpeed, 0.0f, _playerData.MovementSpeed);

            _animator.SetMovement(movementValue);
        }
        #endregion
    }
}