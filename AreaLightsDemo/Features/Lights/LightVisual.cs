using AreaLightsDemo.Effects;
using System;
using Evergine.Common.Graphics;
using Evergine.Components.Graphics3D;
using Evergine.Framework;
using Evergine.Framework.Graphics;
using Evergine.Framework.Graphics.Effects;
using Evergine.Framework.Services;

namespace AreaLightsDemo.Features.Lights
{
    public abstract class LightVisual<T> : Behavior where T : Light
    {
        [BindService]
        AssetsService assetsService = null;

        [BindComponent(isExactType:false)]
        protected T Light;

        [BindComponent(source: BindComponentSource.Children)]
        protected MaterialComponent materialComponent;

        [BindComponent(source: BindComponentSource.ChildrenSkipOwner)]
        protected Transform3D visualTransform;

        protected BasicColor LightVisualMaterial;

        protected override void OnLoaded()
        {
            base.OnLoaded();
            this.Family = FamilyType.PriorityBehavior;
        }

        protected override bool OnAttached()
        {
            var effect = assetsService.Load<Effect>(EvergineContent.Effects.BasicColor);
            if (effect == null)
            {
                return false;
            }

            var opaqueLayer = assetsService.Load<RenderLayerDescription>(DefaultResourcesIDs.OpaqueRenderLayerID);
            if (opaqueLayer == null)
            {
                return false;
            }

            this.LightVisualMaterial = new BasicColor(effect)
            {
                LayerDescription = opaqueLayer,
            };

            this.RefreshLightVisual();

            return base.OnAttached();
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            this.materialComponent.Material = this.LightVisualMaterial.Material;
        }

        protected override void Update(TimeSpan gameTime)
        {
            this.RefreshLightVisual();
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            this.materialComponent.Material = null;
        }

        protected override void OnDetach()
        {
            base.OnDetach();
            this.LightVisualMaterial.Dispose();
        }

        protected virtual void RefreshLightVisual()
        {
            this.LightVisualMaterial.Parameters_Color = this.Light.LinearColor.AsVector3;
            this.LightVisualMaterial.Parameters_Intensity = this.Light.Intensity;
        }
    }
}
