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
    public class SphereLightVisual : LightVisual<SphereLight>
    {
        protected override void RefreshLightVisual()
        {
            base.RefreshLightVisual();
            this.visualTransform.Scale = Vector3.One * (this.Light.Radius * 2);
        }
    }
}
