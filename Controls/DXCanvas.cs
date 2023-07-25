using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using System.Windows.Forms;
using SharpDX;

namespace Story_Crafter.Controls {
    using Device = SharpDX.Direct3D11.Device;
    using Buffer = SharpDX.Direct3D11.Buffer;

    class DXCanvas : System.Windows.Forms.Control {

        bool isDesignEnvironment;

        Device device;
        SwapChain swapChain;
        Texture2D target;
        RenderTargetView targetView;

        public DXCanvas() {
            System.Diagnostics.Process process = System.Diagnostics.Process.GetCurrentProcess();
            isDesignEnvironment = process.ProcessName == "devenv";
            process.Dispose();
        }

        protected override void InitLayout() {
            base.InitLayout();

            if (isDesignEnvironment) { return; }

            try {
                SwapChainDescription description = new SwapChainDescription {
                    BufferCount = 1,
                    Flags = SwapChainFlags.None,
                    IsWindowed = true,
                    ModeDescription = new ModeDescription(
                        ClientSize.Width,
                        ClientSize.Height,
                        new Rational(60, 1),
                        Format.R8G8B8A8_UNorm),
                    OutputHandle = this.Handle,
                    SampleDescription = new SampleDescription(1, 0),
                    SwapEffect = SwapEffect.Discard,
                    Usage = Usage.RenderTargetOutput
                };

                Device.CreateWithSwapChain(
                    SharpDX.Direct3D.DriverType.Hardware,
                    DeviceCreationFlags.Debug,
                    description,
                    out device,
                    out swapChain);

                target = Texture2D.FromSwapChain<Texture2D>(swapChain, 0);
                targetView = new RenderTargetView(device, target);
                device.ImmediateContext.OutputMerger.SetRenderTargets(targetView);
            }
            catch(SharpDXException e) {
                Program.Debug.Log("DirectX exception", e.Message);
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (isDesignEnvironment) { base.OnPaint(e); return; }

            device.ImmediateContext.ClearRenderTargetView(targetView, Color.CornflowerBlue);
            swapChain.Present(0, PresentFlags.None);

            base.OnPaint(e);
        }
    }
}
