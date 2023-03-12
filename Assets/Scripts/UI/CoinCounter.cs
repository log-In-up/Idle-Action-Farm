using TMPro;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Zenject;

namespace UserInterface
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(TextMeshProUGUI))]
    public sealed class CoinCounter : MonoBehaviour
    {
        #region Editor fields
        [SerializeField] private RectTransform _moneyCounter = null;
        #endregion

        #region Fields
        private int _coins;

        private const string COUNTER_FORMAT = "0000";

        private TextMeshProUGUI _text = null;
        private CoinData _coinData;
        #endregion

        #region Zenject
        [Inject]
        private void Constructor(CoinData coinData)
        {
            _coinData = coinData;
        }
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            _coins = 0;
            _text.text = _coins.ToString(COUNTER_FORMAT);
        }
        #endregion

        #region Public methods
        internal void AddCoins(int coins, float addCoinsDuration)
        {
            int endValue = _coins + coins;

            DOTween.To(() => _coins, x => _coins = x, endValue, addCoinsDuration)
                .OnUpdate(() =>
                {
                    _text.text = _coins.ToString(COUNTER_FORMAT);
                });

            _moneyCounter.DOShakeRotation(addCoinsDuration, _coinData.ShakeStrength, _coinData.ShakeVibrato,_coinData.ShakeRandomness, _coinData.ShakeFadeOut);
        }
        #endregion
    }
}