using Field;
using Player;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SampleSceneSOInstaller", menuName = "Installers/SampleSceneSOInstaller")]
public sealed class SampleSceneSOInstaller : ScriptableObjectInstaller<SampleSceneSOInstaller>
{
    #region Editor fields
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private WheatData _wheatData;
    [SerializeField] private FieldSettings _fieldSettings;
    #endregion

    public override void InstallBindings()
    {
        BindPlayerData();
        BindWheatData();
        BindFieldSettings();
    }

    #region Bind Methods
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

    private void BindFieldSettings()
    {
        Container.Bind<FieldSettings>()
            .FromInstance(_fieldSettings)
            .AsSingle()
            .NonLazy();
    }
    #endregion
}