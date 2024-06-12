using Evergine.Framework.Graphics;
using Evergine.Mathematics;

namespace AreaLightsDemo.Features.Lights
{
    public class DiskLightVisual : LightVisual<DiskLight>
    {
        protected override void RefreshLightVisual()
        {
            base.RefreshLightVisual();
            this.visualTransform.Scale = Vector3.One * (this.Light.Radius * 2); 
        }
    }
}
