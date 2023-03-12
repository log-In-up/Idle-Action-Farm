using Player;
using System;
using UnityEngine;
using UserInterface;
using Zenject;

namespace DependencyInjection
{
    [DisallowMultipleComponent]
    public sealed class SampleSceneBinder : MonoInstaller
    {
        #region Editor fields
        [SerializeField] private CoinSpawner _coinSpawner = null;
        [SerializeField] private DynamicJoystick _dynamicJoystick = null;
        [SerializeField] private WheatCollector _wheatCollector = null;
        #endregion

        #region Overridden methods
        public override void InstallBindings()
        {
            BindCoinSpawner();
            BindJoystick();
            BindCollector();
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

        private void BindCollector()
        {
            Container.Bind<WheatCollector>()
                .FromInstance(_wheatCollector)
                .AsSingle()
                .NonLazy();
        }

        private void BindCoinSpawner()
        {
            Container.Bind<CoinSpawner>()
                .FromInstance(_coinSpawner)
                .AsSingle()
                .NonLazy();
        }
        #endregion
    }
}