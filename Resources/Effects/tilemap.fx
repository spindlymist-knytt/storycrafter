#if OPENGL
#define VS_SHADERMODEL vs_3_0
#define PS_SHADERMODEL ps_3_0
#else
#define VS_SHADERMODEL vs_4_0
#define PS_SHADERMODEL ps_4_0
#endif

////////////////////////////////////////////////////////////////
// Constants
////////////////////////////////////////////////////////////////

#define TILESET_WIDTH 16
#define TILESET_HEIGHT 8
#define TILESET_WIDTH_PX 384
#define TILESET_HEIGHT_PX 192
#define TILES_PER_TILESET 128
#define SCREEN_WIDTH 25
#define SCREEN_HEIGHT 10
#define SCREEN_WIDTH_PX 600
#define SCREEN_HEIGHT_PX 240
#define TILES_PER_LAYER 250

////////////////////////////////////////////////////////////////
// Shader Inputs
////////////////////////////////////////////////////////////////

struct VS_IN
{
    float4 position : POSITION;
    uint vid : SV_VertexID;
};

struct PS_IN
{
    float4 position : SV_POSITION;
    float3 uv0 : TEXCOORD0;
    float3 uv1 : TEXCOORD1;
    float3 uv2 : TEXCOORD2;
    float3 uv3 : TEXCOORD3;
    //uint layer0 : LAYER0;
    //uint layer1 : LAYER1;
    //uint layer2 : LAYER2;
    //uint layer3 : LAYER3;
};

float4x4 viewProj;
float4 assets;

Texture2D<float> tileData : register(t0);
Texture2DArray tilesets : register(t1);

SamplerState tileSampler
{
    texture = <tileData>;
    MipFilter = Point;
    MinFilter = Point;
    MagFilter = Point;
    AddressU = Clamp;
    AddressV = Clamp;
};

SamplerState tilesetSampler
{
    texture = <tilesets>;
    MipFilter = Point;
    MinFilter = Point;
    MagFilter = Point;
    AddressU = Clamp;
    AddressV = Clamp;
};

////////////////////////////////////////////////////////////////
// Functions
////////////////////////////////////////////////////////////////

uint readByteFromTileData(uint index, uint layer)
{
    index += layer * TILES_PER_LAYER;
    uint tileDataX = index / 4;
    
    float pixel = tileData.Load(int3(tileDataX, 0, 0));
    
    uint block = asuint(pixel);
    uint shift = (index % 4) * 8;
    uint byte = (block >> shift) & 0xFF;
    
    return byte;
}

float3 calcTileUV(uint vertex, uint tileIndex)
{   
    uint tileset;
    if (tileIndex < TILES_PER_TILESET)
    {
        tileset = (uint) assets.x; // tileset A
    }
    else
    {
        tileIndex -= TILES_PER_TILESET;
        tileset = (uint) assets.y; // tileset B
    }
    
    uint tileX = tileIndex % TILESET_WIDTH;
    uint tileY = tileIndex / TILESET_WIDTH;
    
    float3 uv = float3(tileX, tileY, tileset);
    if (vertex == 1 || vertex == 5)
    {
        uv.x += 1.0f;
        uv.y += 1.0f;
    }
    else if (vertex == 2)
    {
        uv.y += 1.0f;
    }
    else if (vertex == 4)
    {
        uv.x += 1.0f;
    }
    uv.x /= TILESET_WIDTH;
    uv.y /= TILESET_HEIGHT;

    return uv;
}

//float2 calcGradientUV(uint vertex, uint screenIndex)
//{
//    uint screenX = screenIndex % SCREEN_WIDTH;
//    uint screenY = screenIndex / SCREEN_WIDTH;
//    
//    float2 uv = float2(screenX, screenY);
//    if (vertex == 1 || vertex == 5)
//    {
//        uv.x += 1.0f;
//        uv.y += 1.0f;
//    }
//    else if (vertex == 2)
//    {
//        uv.y += 1.0f;
//    }
//    else if (vertex == 4)
//    {
//        uv.x += 1.0f;
//    }
//    uv.y /= SCREEN_HEIGHT;
//    
//    return uv;
//}

float4 blend(float4 foreground, float4 background)
{
    float transA = (1.0f - foreground.a);
    float transB = (1.0f - background.a);
    
    return float4(
        foreground.a * foreground.rgb + transA * background.rgb,
        1.0f - (transA * transB)
    );
}

////////////////////////////////////////////////////////////////
// Vertex Shader
////////////////////////////////////////////////////////////////

PS_IN VS(VS_IN input)
{
    PS_IN output = (PS_IN) 0;
    
    uint screenIndex = input.vid / 6;
    uint vertex = input.vid % 6;
    
    uint layer0 = readByteFromTileData(screenIndex, 0);
    uint layer1 = readByteFromTileData(screenIndex, 1);
    uint layer2 = readByteFromTileData(screenIndex, 2);
    uint layer3 = readByteFromTileData(screenIndex, 3);

    output.position = mul(input.position, viewProj);
    output.uv0 = calcTileUV(vertex, layer0);
    output.uv1 = calcTileUV(vertex, layer1);
    output.uv2 = calcTileUV(vertex, layer2);
    output.uv3 = calcTileUV(vertex, layer3);
    
    return output;
}

////////////////////////////////////////////////////////////////
// Pixel Shader
////////////////////////////////////////////////////////////////

float4 PS(PS_IN input) : SV_Target
{
    float4 color = tilesets.Sample(tilesetSampler, input.uv0);
    color = blend(tilesets.Sample(tilesetSampler, input.uv1), color);
    color = blend(tilesets.Sample(tilesetSampler, input.uv2), color);
    color = blend(tilesets.Sample(tilesetSampler, input.uv3), color);
    
    return color;
}

technique Unlit
{
    pass
    {
        VertexShader = compile VS_SHADERMODEL VS();
        PixelShader = compile PS_SHADERMODEL PS();
    }
}
