using System;
using System.Collections.Generic;
using System.Text;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;
using WaveEngine.Mathematics;

namespace AreaLightsDemo.Features.Behaviors
{
    public class OffsetLoopBehavior : Behavior
    {
        private Vector3 initPosition;

        [BindService]
        private Clock clock = null;

        [BindComponent]
        private Transform3D transform3D = null;

        public Vector3 Offset { get; set; }
        public float Period { get; set; } = 3;


        protected override bool OnAttached()
        {
            this.initPosition = this.transform3D.LocalPosition;
            return base.OnAttached();
        }

        protected override void Update(TimeSpan gameTime)
        {
            var positionMin = this.initPosition - this.Offset;
            var positionMax = this.initPosition + this.Offset;
            float lerp = (float)(Math.Sin(this.clock.TotalTime.TotalSeconds / (this.Period / MathHelper.TwoPi )) * 0.5 + 0.5);

            this.transform3D.LocalPosition = Vector3.Lerp(positionMin, positionMax, lerp);
        }
    }
}
