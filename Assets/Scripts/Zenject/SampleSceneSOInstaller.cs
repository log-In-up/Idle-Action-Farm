using Player;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SampleSceneSOInstaller", menuName = "Installers/SampleSceneSOInstaller")]
public class SampleSceneSOInstaller : ScriptableObjectInstaller<SampleSceneSOInstaller>
{
    #region Editor fields
    [SerializeField] private PlayerData _playerData;
    #endregion

    public override void InstallBindings()
    {
        BindPlayerData();
    }

    private void BindPlayerData()
    {
        Container.Bind<PlayerData>()
            .FromInstance(_playerData)
            .AsSingle()
            .NonLazy();
    }
}