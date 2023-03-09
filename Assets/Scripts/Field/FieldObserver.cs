using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Field
{
    [DisallowMultipleComponent]
    public sealed class FieldObserver : MonoBehaviour
    {
        #region Editor fields
        [SerializeField] private GameObject _wheatBush = null;
        #endregion

        #region Parameters
        private const float startOffsetValue = 0.0f, invertor = -1.0f;
        private const int startCount = 0;

        private DiContainer _diContainer = null;
        private FieldSettings _fieldSettings = null;
        private List<Wheat> _wheatList = null;
        #endregion

        #region Zenject
        [Inject]
        private void Constructor(DiContainer diContainer, FieldSettings fieldSettings)
        {
            _diContainer = diContainer;
            _fieldSettings = fieldSettings;
        }
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _wheatList = new List<Wheat>();
        }

        private void Start()
        {
            InitializeField();
        }

        private void Update()
        {
            foreach (Wheat wheat in _wheatList)
            {
                if (wheat.HasGrown) continue;

                wheat.UpdateGrownTime();
            }
        }
        #endregion

        #region Methods
        private void InitializeField()
        {
            int countObjectInField = _fieldSettings.Width * _fieldSettings.Height;
            Vector3[] points = SetPoints(new Vector3[countObjectInField]);

            for (int index = 0; index < countObjectInField; index++)
            {
                GameObject wheatBush = _diContainer.InstantiatePrefab(_wheatBush, points[index], Quaternion.identity, transform);

                if (wheatBush.TryGetComponent(out Wheat wheat))
                {
                    _wheatList.Add(wheat);
                }
                else
                {
                    Debug.LogError($"Object {_wheatBush} doesn't contain Wheat.cs");
                }
            }
        }

        private Vector3[] SetPoints(Vector3[] points)
        {
            float verticalOffset = startOffsetValue, horizontalOffset = startOffsetValue;
            int countInLine = startCount;

            for (int index = 0; index < points.Length; index++)
            {
                points[index] = new Vector3(transform.position.x + horizontalOffset, transform.position.y, transform.position.z + verticalOffset);
                countInLine++;

                if (startOffsetValue > horizontalOffset)
                {
                    horizontalOffset *= invertor;
                }
                horizontalOffset += _fieldSettings.HorizontalInterval;

                if (countInLine >= _fieldSettings.Width)
                {
                    verticalOffset += _fieldSettings.VerticalInterval;

                    horizontalOffset = startOffsetValue;
                    countInLine = startCount;
                }
            }

            return points;
        }
        #endregion
    }
}