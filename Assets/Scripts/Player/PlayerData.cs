using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "Game Data/Player Data", order = 1)]
    public sealed class PlayerData : ScriptableObject
    {
        #region Editor fields
        [field: Header("Player movement")]
        [field: SerializeField, Min(0.0f)] public float MovementSpeed { get; private set; }
        [field: SerializeField, Min(0.0f)] public float SmoothTime { get; private set; }

        [field: Header("Pickup settings")]
        [field: SerializeField, Min(0.0f)] public float PickUpDuration { get; private set; }

        [field: Header("Carry settings")]
        [field: SerializeField, Min(1)] public int CarryLimit { get; private set; }
        [field: SerializeField, Min(0.0f)] public float DistanceBetweenBlocks { get; private set; }
        #endregion
    }
}