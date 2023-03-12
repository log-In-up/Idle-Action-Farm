using DG.Tweening;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserInterface;
using Zenject;

namespace Buildings
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider))]
    public sealed class Barn : MonoBehaviour
    {
        #region Fields
        private BarnData _barnData = null;
        private CoinSpawner _coinSpawner = null;
        #endregion

        #region Zenject
        [Inject]
        private void Constructor(BarnData barnData, CoinSpawner coinSpawner)
        {
            _barnData = barnData;
            _coinSpawner = coinSpawner;
        }
        #endregion

        #region MonoBehaviour API
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out WheatCollector collector))
            {
                StartCoroutine(SendAllWheatBoxes(collector));
            }
        }
        #endregion

        #region Methods
        private IEnumerator SendAllWheatBoxes(WheatCollector collector)
        {
            List<GameObject> wheatBoxes = collector.GetBlocksOfWheat();

            foreach (GameObject wheatBox in wheatBoxes)
            {
                wheatBox.transform.DOMove(transform.position, _barnData.PickUpDuration)
                    .OnComplete(() =>
                    {
                        collector.DecreaseStackSizeBy(1);
                        Destroy(wheatBox);
                    });

                yield return new WaitForSeconds(_barnData.PickUpInterval);
            }
            _coinSpawner.SpawnCoins(transform.position, wheatBoxes.Count, _barnData.SellPrice);
        }
        #endregion
    }
}