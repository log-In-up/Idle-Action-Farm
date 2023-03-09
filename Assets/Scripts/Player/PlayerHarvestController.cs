using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SphereCollider))]
    public sealed class PlayerHarvestController : MonoBehaviour
    {
        #region Editor fields
        [SerializeField] private PlayerAnimator _playerAnimator = null;
        [SerializeField] private Transform _harvestTool = null;
        [SerializeField] private LayerMask _wheatMask;
        #endregion

        #region Fields
        private SphereCollider _sphereCollider = null;
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _sphereCollider = GetComponent<SphereCollider>();
        }
        #endregion

        private void Update()
        {
            bool isHarvesting = Physics.CheckSphere(transform.position, _sphereCollider.radius, _wheatMask.value);
            _playerAnimator.SetHarvesting(isHarvesting);
            _harvestTool.gameObject.SetActive(isHarvesting);
        }
    }
}