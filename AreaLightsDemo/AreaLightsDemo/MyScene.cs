using WaveEngine.Common.Graphics;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;
using WaveEngine.Mathematics;

namespace AreaLightsDemo
{
    public class MyScene : Scene
    {
        protected override void CreateScene()
        {
            var backendType = Application.Current.Container.Resolve<GraphicsContext>().BackendType;
            var isOpenGL = backendType == GraphicsBackend.OpenGL || backendType == GraphicsBackend.WebGL1 || backendType == GraphicsBackend.WebGL2 || backendType == GraphicsBackend.OpenGLES;

            if (isOpenGL)
            {
                var pp = this.Managers.EntityManager.Find("PostProcessingVolume");
                this.Managers.EntityManager.Remove(pp);
            }
        }
    }
}