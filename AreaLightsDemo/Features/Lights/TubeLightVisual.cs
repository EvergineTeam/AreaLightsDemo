using System;
using System.Collections.Generic;
using System.Text;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Graphics.Effects;
using WaveEngine.Framework.Graphics.Materials;
using WaveEngine.Framework.Services;
using WaveEngine.Mathematics;

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
