using System;
using System.Collections.Generic;
using SharpDX;
using SharpDX.DXGI;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.D3DCompiler;
using SharpDX.WIC;
using Story_Crafter.Knytt;

namespace Story_Crafter.Rendering {
    using Device = SharpDX.Direct3D11.Device;
    using Buffer = SharpDX.Direct3D11.Buffer;
    using MapFlags = SharpDX.Direct3D11.MapFlags;
    using Resource = SharpDX.Direct3D11.Resource;

    class D3DRenderer {

        Device device;
        DeviceContext context;
        SwapChain swapChain;
        Texture2D target;
        RenderTargetView targetView;
        Buffer tileIndexBuffer, constantBuffer;

        public D3DRenderer(IntPtr windowHandle) {
            try {
                // Create device and swap chain
                var swapChainDescription = new SwapChainDescription {
                    BufferCount = 1,
                    Flags = SwapChainFlags.None,
                    IsWindowed = true,
                    ModeDescription = new ModeDescription(
                        600,
                        240,
                        new Rational(60, 1),
                        Format.R8G8B8A8_UNorm),
                    OutputHandle = windowHandle,
                    SampleDescription = new SampleDescription(1, 0),
                    SwapEffect = SwapEffect.Discard,
                    Usage = Usage.RenderTargetOutput
                };

                Device.CreateWithSwapChain(
                    DriverType.Hardware,
                    DeviceCreationFlags.Debug,
                    swapChainDescription,
                    out device,
                    out swapChain);
                context = device.ImmediateContext;
                target = Texture2D.FromSwapChain<Texture2D>(swapChain, 0);
                targetView = new RenderTargetView(device, target);

                // Set up vertex shader
                var vertexShaderResult = ShaderBytecode.CompileFromFile("Resources/Shaders/tilemap.hlsl", "VS", "vs_4_0");
                var vertexShader = new VertexShader(device, vertexShaderResult.Bytecode);
                var signature = ShaderSignature.GetInputSignature(vertexShaderResult.Bytecode);
                var layout = new InputLayout(device, signature, new[] {
                    new InputElement("POSITION", 0, Format.R32G32B32A32_Float, 0, 0),
                });

                // Set up pixel shader
                var pixelShaderResult = ShaderBytecode.CompileFromFile("Resources/Shaders/tilemap.hlsl", "PS", "ps_4_0");
                var pixelShader = new PixelShader(device, pixelShaderResult.Bytecode);

                // Set up vertex buffers
                var vertexPositions = new Vector4[Metrics.ScreenWidth * Metrics.ScreenHeight * 6];
                int i = 0;
                for (int screenY = 0; screenY < Metrics.ScreenHeight; screenY++) {
                    for (int screenX = 0; screenX < Metrics.ScreenWidth; screenX++) {
                        float top = (240.0f / 2.0f) - (screenY * 24.0f);
                        float bottom = top - 24.0f;
                        float left = -(600.0f / 2.0f) + (screenX * 24.0f);
                        float right = left + 24.0f;
                        vertexPositions[i++] = new Vector4(left, top, 0.5f, 1.0f);
                        vertexPositions[i++] = new Vector4(right, bottom, 0.5f, 1.0f);
                        vertexPositions[i++] = new Vector4(left , bottom, 0.5f, 1.0f);
                        vertexPositions[i++] = new Vector4(left , top, 0.5f, 1.0f);
                        vertexPositions[i++] = new Vector4(right, top, 0.5f, 1.0f);
                        vertexPositions[i++] = new Vector4(right, bottom, 0.5f, 1.0f);
                    }
                }
                
                var vertexPositionsBuffer = Buffer.Create(
                    device,
                    BindFlags.VertexBuffer,
                    vertexPositions);

                // Set up constant buffers
                constantBuffer = new Buffer(
                    device,
                    Utilities.SizeOf<Matrix>(),
                    ResourceUsage.Default,
                    BindFlags.ConstantBuffer,
                    CpuAccessFlags.None,
                    ResourceOptionFlags.None,
                    0);

                tileIndexBuffer = new Buffer(
                     device,
                     (4 * 4) + (4 * 4 * 64),
                     ResourceUsage.Dynamic,
                     BindFlags.ConstantBuffer,
                     CpuAccessFlags.Write,
                     ResourceOptionFlags.None,
                     0);

                // Set up view/projection matrices
                //Matrix view = Matrix.LookAtLH(new Vector3(0, 0, -10), new Vector3(0, 0, 0), Vector3.UnitY);
                Matrix view = Matrix.Identity;
                Matrix proj = Matrix.OrthoLH(600f, 240f, 0.1f, 100f);
                Matrix viewProj = Matrix.Multiply(view, proj);
                viewProj.Transpose();
                context.UpdateSubresource(ref viewProj, constantBuffer);

                // Configure pipeline
                context.InputAssembler.InputLayout = layout;
                context.InputAssembler.PrimitiveTopology = PrimitiveTopology.TriangleList;
                context.InputAssembler.SetVertexBuffers(
                    0,
                    new VertexBufferBinding(vertexPositionsBuffer, Utilities.SizeOf<Vector4>(), 0));
                context.VertexShader.SetConstantBuffer(0, constantBuffer);
                context.VertexShader.SetConstantBuffer(1, tileIndexBuffer);
                context.VertexShader.Set(vertexShader);
                context.PixelShader.Set(pixelShader);
                context.Rasterizer.SetViewport(new Viewport(0, 0, 600, 240, 0.0f, 1.0f));
                context.OutputMerger.SetRenderTargets(targetView);
            }
            catch (SharpDXException e) {
                Program.Debug.Log("DirectX exception", e.Message);
            }
        }

        public void InstallAssets(Story story) {
            var factory = new ImagingFactory();

            Texture2D tilesetsArray = new Texture2D(
                device,
                new Texture2DDescription() {
                    Width = Metrics.TilesetWidthPx,
                    Height = Metrics.TilesetHeightPx,
                    ArraySize = 256,
                    BindFlags = BindFlags.ShaderResource,
                    Usage = ResourceUsage.Default,
                    CpuAccessFlags = CpuAccessFlags.None,
                    Format = Format.R8G8B8A8_UNorm,
                    MipLevels = 1,
                    OptionFlags = ResourceOptionFlags.None,
                    SampleDescription = new SampleDescription(1, 0),
                });

            int stride = Metrics.TilesetWidthPx * 4;
            var buffer = new DataStream(stride * Metrics.TilesetHeightPx, true, true);

            for (int i = 0; i < 256; i++) {
                BitmapSource tileset = LoadBitmap(factory, story.Tileset(i));
                tileset.CopyPixels(stride, buffer);
                DataBox box = new DataBox(buffer.DataPointer, stride, 1);

                int subresource = Resource.CalculateSubResourceIndex(0, i, 1);
                context.UpdateSubresource(box, tilesetsArray, subresource);

                buffer.Seek(0, System.IO.SeekOrigin.Begin);
            }

            var resourceView = new ShaderResourceView(device, tilesetsArray);
            context.PixelShader.SetShaderResources(0, resourceView);
        }

        public void Render(Story story, Screen screen) {
            // Upload gradient (temporary)
            var gradient = Program.LoadBitmap(story.Gradient(screen.Gradient));
            var textureGrad = createTextureFromBitmap(gradient);
            var rcViewGrad = new ShaderResourceView(device, textureGrad);
            context.PixelShader.SetShaderResources(1, rcViewGrad);

            //var watch = System.Diagnostics.Stopwatch.StartNew();

            // Upload tile data
            DataBox result = context.MapSubresource(tileIndexBuffer, 0, MapMode.WriteDiscard, MapFlags.None);
            using (DataStream stream = new DataStream(result.DataPointer, tileIndexBuffer.Description.SizeInBytes, false, true)) {
                stream.Write(screen.TilesetA);
                stream.Write(screen.TilesetB);
                stream.Write(0xCCCCCCCC);
                stream.Write(0xCCCCCCCC);
                stream.Write(screen.RawData, 0, 250 * 4);
            }
            context.UnmapSubresource(tileIndexBuffer, 0);

            // Draw and present
            context.ClearRenderTargetView(targetView, Color.Black);
            context.Draw(Metrics.ScreenWidth * Metrics.ScreenHeight * 6, 0);
            swapChain.Present(0, PresentFlags.None);

            //watch.Stop();
            //Program.Debug.Log("Rendered in ", watch.ElapsedTicks, " ticks (", watch.ElapsedMilliseconds, "ms)");
        }

        BitmapSource LoadBitmap(ImagingFactory factory, string path) {
            var decoder = new BitmapDecoder(
                factory,
                path,
                DecodeOptions.CacheOnDemand);

            var frame = decoder.GetFrame(0);

            var clipper = new BitmapClipper(factory);
            clipper.Initialize(
                frame,
                new SharpDX.Mathematics.Interop.RawBox(0, 0, 384, 192));

            var converter = new FormatConverter(factory);
            converter.Initialize(
                clipper,
                PixelFormat.Format32bppRGBA,
                BitmapDitherType.None,
                null,
                0.0,
                BitmapPaletteType.Custom);

            return converter;
        }

        Texture2D createTextureFromBitmap(System.Drawing.Bitmap bitmap) {
            if (bitmap.PixelFormat != System.Drawing.Imaging.PixelFormat.Format32bppArgb) {
                bitmap = bitmap.Clone(
                    new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            }

            System.Drawing.Imaging.BitmapData data = bitmap.LockBits(
                new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            Texture2D texture = new Texture2D(
                device,
                new Texture2DDescription {
                    Width = bitmap.Width,
                    Height = bitmap.Height,
                    ArraySize = 1,
                    BindFlags = BindFlags.ShaderResource,
                    Usage = ResourceUsage.Immutable,
                    CpuAccessFlags = CpuAccessFlags.None,
                    Format = Format.B8G8R8A8_UNorm,
                    MipLevels = 1,
                    OptionFlags = ResourceOptionFlags.None,
                    SampleDescription = new SampleDescription(1, 0),
                },
                new DataRectangle(data.Scan0, data.Stride));

            bitmap.UnlockBits(data);

            return texture;
        }
    }
}
