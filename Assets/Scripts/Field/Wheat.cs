using UnityEngine;
using Zenject;

namespace Field
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider))]
    public sealed class Wheat : MonoBehaviour
    {
        #region Editor field
        [SerializeField] private Transform _model;
        #endregion

        #region Fields
        private bool _hasGrown;
        private float _timeToGrow;

        private const string SCYTHE_TAG = "Weapon";

        private WheatData _wheatData = null;
        private BoxCollider _boxCollider = null;
        #endregion

        #region Properties
        public bool HasGrown { get => _hasGrown; }
        #endregion

        #region Zenject
        [Inject]
        private void Constructor(WheatData wheatData)
        {
            _wheatData = wheatData;
        }
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
        }

        private void Start()
        {
            _hasGrown = true;
            _timeToGrow = _wheatData.GrowTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(SCYTHE_TAG))
            {
                _hasGrown = false;

                _model.gameObject.SetActive(_hasGrown);
                _boxCollider.enabled = _hasGrown;

                Instantiate(_wheatData.DropOnMowing, transform.position, Quaternion.identity);

                _timeToGrow = _wheatData.GrowTime;
            }
        }
        #endregion

        #region Public methods
        internal void UpdateGrownTime()
        {
            _timeToGrow -= Time.deltaTime;

            if (_timeToGrow < 0)
            {
                _hasGrown = true;

                _model.gameObject.SetActive(_hasGrown);
                _boxCollider.enabled = _hasGrown;
            }
        }
        #endregion
    }
}