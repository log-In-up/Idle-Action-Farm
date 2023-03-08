using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "Player Attribute Data", menuName = "Game Data/Player Attribute Data", order = 1)]
    public sealed class PlayerData : ScriptableObject
    {
        #region Editor fields
        [field: SerializeField, Min(0.0f)] public float MovementSpeed { get; private set; }
        [field: SerializeField, Min(0.0f)] public float SmoothTime { get; private set; }
        [field: SerializeField, Min(1)] public int CarryLimit { get; private set; }
        #endregion
    }
}