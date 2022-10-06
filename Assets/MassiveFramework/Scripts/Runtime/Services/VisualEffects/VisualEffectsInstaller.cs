using System.Linq;
using Zenject;

namespace MassiveCore.Framework
{
    public class VisualEffectsInstaller : ServiceInstaller
    {
        [Inject]
        private readonly IGameConfig _gameConfig;

        public override void InstallBindings()
        {
            Container.Bind<IVisualEffects>().To<VisualEffects>().AsSingle();
            Container.BindFactory<string, VisualEffect, VisualEffect.Factory>().FromMethod
            (
                (c, id) =>
                {
                    var configs = _gameConfig.Config<VisualEffectsConfig>().Configs;
                    var prefab = configs.First(x => x.Id == id).VisualEffect;
                    var visualEffect = c.InstantiatePrefabForComponent<VisualEffect>(prefab);
                    visualEffect.name = id;
                    return visualEffect;
                }
            );
        }
    }
}
