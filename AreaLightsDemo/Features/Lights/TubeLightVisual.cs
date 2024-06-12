using Evergine.Framework.Graphics;
using Evergine.Mathematics;

namespace AreaLightsDemo.Features.Lights
{
    public class TubeLightVisual : LightVisual<TubeLight>
    {
        protected override void RefreshLightVisual()
        {
            base.RefreshLightVisual();
            this.visualTransform.Scale = new Vector3(this.Light.Radius * 2, this.Light.Length, this.Light.Radius * 2);
        }
    }
}
