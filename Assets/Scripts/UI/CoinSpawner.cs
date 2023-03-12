using Buildings;
using DG.Tweening;
using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace UserInterface
{
    [DisallowMultipleComponent]
    public sealed class CoinSpawner : MonoBehaviour
    {
        #region Editor fields
        [SerializeField] private RectTransform _counter = null;
        [SerializeField] private CoinCounter _coinCounter = null;
        [SerializeField] private GameObject _spawnParent = null;
        #endregion

        #region Fields
        private CoinData _coinData;
        #endregion

        #region Zenject
        [Inject]
        private void Constructor(CoinData coinData)
        {
            _coinData = coinData;
        }
        #endregion

        #region Public fields
        internal void SpawnCoins(Vector3 position, int count, int sellPrice)
        {
            StartCoroutine(SendAllWheatBoxes(position, count, sellPrice));
        }
        #endregion

        #region Methods
        private IEnumerator SendAllWheatBoxes(Vector3 position, int count, int sellPrice)
        {
            Vector3 spawnPosition = Camera.main.WorldToScreenPoint(position);
            spawnPosition = new Vector3(spawnPosition.x, spawnPosition.y, 0.0f);

            bool isStart = true;

            for (int index = 0; index < count; index++)
            {
                GameObject coin = Instantiate(_coinData.Coin, spawnPosition, Quaternion.identity, _spawnParent.transform);
                coin.transform.DOMove(_counter.position, _coinData.FlyDuration)
                    .OnComplete(() =>
                    {
                        if (isStart)
                        {
                            isStart = false;

                            int coins = sellPrice * count;
                            _coinCounter.AddCoins(coins, _coinData.AppearInterval * count);
                        }

                        Destroy(coin);
                    });

                yield return new WaitForSeconds(_coinData.AppearInterval);
            }
        }
        #endregion
    }
}