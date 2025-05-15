using Zenject;

namespace TZ_Eisvil
{
    public class EnemyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<EnemyGlobalTracker>()
                .AsSingle();
        }
    }
}