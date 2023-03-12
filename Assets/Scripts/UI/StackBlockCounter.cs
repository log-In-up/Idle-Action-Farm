using Player;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(TextMeshProUGUI))]
    public sealed class StackBlockCounter : MonoBehaviour
    {
        #region Fields
        private TextMeshProUGUI _counter = null;
        private PlayerData _playerData = null;
        private WheatCollector _wheatCollector = null;
        #endregion

        #region Zenject
        [Inject]
        private void Constructor(WheatCollector wheatCollector, PlayerData playerData)
        {
            _wheatCollector = wheatCollector;
            _playerData = playerData;
        }
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _counter = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            _wheatCollector.OnUpdateStack += OnUpdateStack;
        }

        private void OnDisable()
        {
            _wheatCollector.OnUpdateStack -= OnUpdateStack;
        }
        #endregion

        private void OnUpdateStack(int itemsInStack)
        {
            _counter.text = $"{itemsInStack}/{_playerData.CarryLimit}";
        }
    }
}