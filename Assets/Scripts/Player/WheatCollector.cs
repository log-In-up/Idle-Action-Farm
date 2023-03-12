using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Player
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider))]
    public sealed class WheatCollector : MonoBehaviour
    {
        #region Editor fields
        [SerializeField] private Transform _stackParent = null;
        #endregion

        #region Fields
        private int _itemsInStack;
        private Vector3[] _placesInStack;

        private PlayerData _playerData = null;

        private const string BLOCK_OF_WHEAT_TAG = "BlockOfWheat";
        #endregion

        #region Event
        public delegate void WheatCollectorDelegate(int itemsInStack);
        public event WheatCollectorDelegate OnUpdateStack;
        #endregion

        #region Zenject
        [Inject]
        private void Constructor(PlayerData playerData)
        {
            _playerData = playerData;
        }
        #endregion

        #region MonoBehaviour API
        private void Start()
        {
            _itemsInStack = 0;
            OnUpdateStack?.Invoke(_itemsInStack);

            _placesInStack = GetPlacesForStack(_playerData.CarryLimit);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_playerData.CarryLimit > _itemsInStack & other.gameObject.CompareTag(BLOCK_OF_WHEAT_TAG))
            {
                other.transform.SetParent(_stackParent);
                other.transform.DOLocalMove(_placesInStack[_itemsInStack], _playerData.PickUpDuration)
                    .OnComplete(() =>
                    {
                        other.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                    });
                _itemsInStack++;
                OnUpdateStack?.Invoke(_itemsInStack);
            }
        }
        #endregion

        #region Methods
        private Vector3[] GetPlacesForStack(int carryLimit)
        {
            Vector3[] result = new Vector3[carryLimit];

            for (int index = 0; index < result.Length; index++)
            {
                result[index] = new Vector3(0.0f, _playerData.DistanceBetweenBlocks * index, 0.0f);
            }

            return result;
        }
        #endregion

        #region Public methods
        internal void DecreaseStackSizeBy(int amount)
        {
            _itemsInStack -= amount;
            OnUpdateStack?.Invoke(_itemsInStack);
        }

        internal List<GameObject> GetBlocksOfWheat()
        {
            List<GameObject> result = new List<GameObject>();

            foreach (Transform item in _stackParent)
            {
                result.Add(item.gameObject);
            }
            result.Reverse();
            return result;
        }
        #endregion
    }
}