using UnityEngine;

namespace Field
{
    [CreateAssetMenu(fileName = "Field Settings", menuName = "Game Data/Field Settings", order = 1)]
    public sealed class FieldSettings : ScriptableObject
    {
        #region Parameters
        [field: SerializeField, Min(1)] public int Width { get; private set; }
        [field: SerializeField, Min(1)] public int Height { get; private set; }
        [field: SerializeField, Min(0.0f)] public float HorizontalInterval { get; private set; }
        [field: SerializeField, Min(0.0f)] public float VerticalInterval { get; private set; }
        #endregion
    }
}