//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AreaLightsDemo.Effects
{
    using Evergine.Common.Graphics;
    using Evergine.Framework.Graphics;
    using Evergine.Framework.Graphics.Effects;
    using Evergine.Mathematics;
    
    
    [Evergine.Framework.Graphics.MaterialDecoratorAttribute("87133309-71cd-459d-afff-59872511b38f")]
    public partial class BasicColor : Evergine.Framework.Graphics.MaterialDecorator
    {
        
        public BasicColor(Evergine.Framework.Graphics.Effects.Effect effect) : 
                base(new Material(effect))
        {
        }
        
        public BasicColor(Evergine.Framework.Graphics.Material material) : 
                base(material)
        {
        }
        
        public Evergine.Mathematics.Matrix4x4 Base_WorldViewProj
        {
            get
            {
                return this.material.CBuffers[0].GetBufferData<Evergine.Mathematics.Matrix4x4>(0);
            }
            set
            {
				this.material.CBuffers[0].SetBufferData(value, 0);
            }
        }
        
        public Evergine.Mathematics.Vector3 Parameters_Color
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<Evergine.Mathematics.Vector3>(0);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 0);
            }
        }
        
        public float Parameters_Intensity
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<System.Single>(12);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 12);
            }
        }
        
        public float Camera_Exposure
        {
            get
            {
                return this.material.CBuffers[2].GetBufferData<System.Single>(0);
            }
            set
            {
				this.material.CBuffers[2].SetBufferData(value, 0);
            }
        }
    }
}
