using Buildings;
using Field;
using Player;
using UnityEngine;
using UserInterface;
using Zenject;

[CreateAssetMenu(fileName = "SampleSceneSOInstaller", menuName = "Installers/SampleSceneSOInstaller")]
public sealed class SampleSceneSOInstaller : ScriptableObjectInstaller<SampleSceneSOInstaller>
{
    #region Editor fields
    [SerializeField] private BarnData _barnData;
    [SerializeField] private CoinData _coinData;
    [SerializeField] private FieldSettings _fieldSettings;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private WheatData _wheatData;
    #endregion

    public override void InstallBindings()
    {
        BindBarnData();
        BindCoinData();
        BindFieldSettings();
        BindPlayerData();
        BindWheatData();
    }

    #region Bind Methods
    private void BindBarnData()
    {
        Container.Bind<BarnData>()
            .FromInstance(_barnData)
            .AsSingle()
            .NonLazy();
    }

    private void BindCoinData()
    {
        Container.Bind<CoinData>()
            .FromInstance(_coinData)
            .AsSingle()
            .NonLazy();
    }

    private void BindFieldSettings()
    {
        Container.Bind<FieldSettings>()
            .FromInstance(_fieldSettings)
            .AsSingle()
            .NonLazy();
    }

    private void BindPlayerData()
    {
        Container.Bind<PlayerData>()
            .FromInstance(_playerData)
            .AsSingle()
            .NonLazy();
    }

    private void BindWheatData()
    {
        Container.Bind<WheatData>()
            .FromInstance(_wheatData)
            .AsSingle()
            .NonLazy();
    }
    #endregion
}