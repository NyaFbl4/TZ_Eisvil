using TZ_Eisvil;
using Zenject;

namespace Assets.Project.Scripts.Installers
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