using UnityEngine;

namespace Field
{
    [CreateAssetMenu(fileName = "Wheat Data", menuName = "Game Data/Wheat Data", order = 1)]
    public sealed class WheatData : ScriptableObject
    {
        #region Editor fields
        [field: SerializeField, Min(0.0f)] public float GrowTime { get; private set; }
        [field: SerializeField] public GameObject DropOnMowing { get; private set; }
        [field: SerializeField] public Vector3 DropSpawnOffset { get; private set; }
        #endregion
    }
}