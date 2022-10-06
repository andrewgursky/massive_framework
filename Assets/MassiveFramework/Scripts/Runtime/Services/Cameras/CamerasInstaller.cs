using UnityEngine;

namespace MassiveCore.Framework
{
    public class CamerasInstaller : ServiceInstaller
    {
        [SerializeField]
        private Camera[] _cameras;

        public override void InstallBindings()
        {
            Container.Bind<ICameras>().To<Cameras>().AsSingle().WithArguments(_cameras);
        }
    }
}
