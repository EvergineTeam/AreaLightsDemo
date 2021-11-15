using System;
using System.Collections.Generic;
using System.Text;
using Evergine.Components.Graphics3D;
using Evergine.Framework;
using Evergine.Framework.Graphics;
using Evergine.Framework.Graphics.Effects;
using Evergine.Framework.Graphics.Materials;
using Evergine.Framework.Services;
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
