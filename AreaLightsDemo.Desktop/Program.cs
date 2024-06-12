using System;
using System.Diagnostics;
using Evergine.Common;
using Evergine.Common.Audio;
using Evergine.Common.Graphics;
using Evergine.Framework;
using Evergine.Framework.Graphics;
using Evergine.Framework.Services;
using Evergine.Platform;

namespace AreaLightsDemo.Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create app
            MyApplication application = new MyApplication();

            // Create Services
            uint width = 1280;
            uint height = 720;
            WindowsSystem windowsSystem = CreateWindowSystem();
            application.Container.RegisterInstance(windowsSystem);
            var window = windowsSystem.CreateWindow("AreaLightsDemo", width, height);

            ConfigureGraphicsContext(application, window);
			
            AudioDevice audioDevice = CreateAudioDevice();
            application.Container.RegisterInstance(audioDevice);

            Stopwatch clockTimer = Stopwatch.StartNew();
            windowsSystem.Run(
            () =>
            {
                application.Initialize();
            },
            () =>
            {
                var gameTime = clockTimer.Elapsed;
                clockTimer.Restart();

                application.UpdateFrame(gameTime);
                application.DrawFrame(gameTime);
            });
        }

        private static void ConfigureGraphicsContext(Application application, Window window)
        {
            GraphicsContext graphicsContext = CreateGraphicsContext();
            graphicsContext.CreateDevice();
            SwapChainDescription swapChainDescription = new SwapChainDescription()
            {
                SurfaceInfo = window.SurfaceInfo,
                Width = window.Width,
                Height = window.Height,
                ColorTargetFormat = PixelFormat.R8G8B8A8_UNorm,
                ColorTargetFlags = TextureFlags.RenderTarget | TextureFlags.ShaderResource,
                DepthStencilTargetFormat = PixelFormat.D24_UNorm_S8_UInt,
                DepthStencilTargetFlags = TextureFlags.DepthStencil,
                SampleCount = TextureSampleCount.None,
                IsWindowed = true,
                RefreshRate = 60
            };
            var swapChain = graphicsContext.CreateSwapChain(swapChainDescription);
            swapChain.VerticalSync = true;

            var graphicsPresenter = application.Container.Resolve<GraphicsPresenter>();
            var firstDisplay = new Display(window, swapChain);
            graphicsPresenter.AddDisplay("DefaultDisplay", firstDisplay);

            application.Container.RegisterInstance(graphicsContext);
        }
		
		private static AudioDevice CreateAudioDevice()
        {
            AudioDevice audioDevice;
            if (OperatingSystemHelper.IsOSPlatform(PlatformType.Windows))
            {
                audioDevice = new Evergine.XAudio2.XAudioDevice();
            }
            else if (OperatingSystemHelper.IsAnyOfOSPlatforms(new[] { PlatformType.Linux, PlatformType.MacOS }))
            {
                audioDevice = new Evergine.OpenAL.ALAudioDevice();
            }
            else
            {
                throw new Exception("Audio device can not be created.");
            }

            return audioDevice;
        }

        private static WindowsSystem CreateWindowSystem()
        {
            WindowsSystem windowsSystem = new Evergine.SDL.SDLWindowsSystem();
            return windowsSystem;
        }

        private static GraphicsContext CreateGraphicsContext()
        {
            GraphicsContext graphicsContext;
            if (OperatingSystemHelper.IsOSPlatform(PlatformType.Windows))
            {
                graphicsContext = new Evergine.DirectX11.DX11GraphicsContext();
            }
            else if (OperatingSystemHelper.IsOSPlatform(PlatformType.Linux))
            {
                graphicsContext = new Evergine.Vulkan.VKGraphicsContext();
            }
            else if (OperatingSystemHelper.IsOSPlatform(PlatformType.MacOS))
            {
                graphicsContext = new Evergine.Metal.MTLGraphicsContext();
            }
            else
            {
                throw new Exception("Graphics context can not be created.");
            }

            return graphicsContext;
        }
    }
}
