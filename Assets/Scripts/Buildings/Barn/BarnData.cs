using UnityEngine;

namespace Buildings
{
    [CreateAssetMenu(fileName = "Barn Data", menuName = "Game Data/Barn Data", order = 1)]
    public sealed class BarnData : ScriptableObject
    {
        #region Editor fields
        [field: Header("Pickup settings")]
        [field: SerializeField, Min(0.0f)] public float PickUpDuration { get; private set; }
        [field: SerializeField, Min(0.0f)] public float PickUpInterval { get; private set; }

        [field: Header("Sell settings")]
        [field: SerializeField, Min(0)] public int SellPrice { get; private set; }
        #endregion
    }
}