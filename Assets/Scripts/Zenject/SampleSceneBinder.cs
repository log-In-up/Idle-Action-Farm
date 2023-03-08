using UnityEngine;
using Zenject;

namespace DependencyInjection
{
    [DisallowMultipleComponent]
    public sealed class SampleSceneBinder : MonoInstaller
    {
        #region Editor fields
        [SerializeField] private DynamicJoystick _dynamicJoystick = null;
        #endregion

        #region Overridden methods
        public override void InstallBindings()
        {
            BindJoystick();
        }
        #endregion

        #region Methods
        private void BindJoystick()
        {
            Container.Bind<DynamicJoystick>()
                .FromInstance(_dynamicJoystick)
                .AsSingle()
                .NonLazy();
        }
        #endregion
    }
}