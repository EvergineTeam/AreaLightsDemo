using Evergine.Framework.Graphics;
using Evergine.Mathematics;

namespace AreaLightsDemo.Features.Lights
{
    public class RectangleLightVisual : LightVisual<RectangleLight>
    {
        protected override void RefreshLightVisual()
        {
            base.RefreshLightVisual();
            this.visualTransform.Scale = new Vector3(this.Light.Width, this.Light.Height, 0f);
        }
    }
}
