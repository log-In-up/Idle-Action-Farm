using UnityEngine;

namespace UserInterface
{
    [CreateAssetMenu(fileName = "Coin Data", menuName = "Game Data/Coin Data", order = 1)]
    public sealed class CoinData : ScriptableObject
    {
        #region Editor fields
        [field: SerializeField, Min(0.0f)] public GameObject Coin { get; private set; }

        [field: Header("Appearing")]
        [field: SerializeField, Min(0.0f)] public float FlyDuration { get; private set; }
        [field: SerializeField, Min(0.0f)] public float AppearInterval { get; private set; }

        [field: Header("Counter vibration")]
        [field: SerializeField, Min(0.0f)]public bool ShakeFadeOut { get; private set; }
        [field: SerializeField, Min(0.0f)]public float ShakeRandomness { get; private set; }
        [field: SerializeField, Min(0)]public int ShakeVibrato { get; private set; }
        [field: SerializeField, Min(0.0f)] public float ShakeStrength { get; private set; }
        #endregion
    }
}