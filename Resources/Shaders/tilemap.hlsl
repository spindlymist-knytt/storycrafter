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
    float2 uvBackground : TEXCOORD4;
    uint layer0 : LAYER0;
    uint layer1 : LAYER1;
    uint layer2 : LAYER2;
    uint layer3 : LAYER3;
};

float4x4 viewProj : register(b0);

cbuffer tileDataBuffer : register(b1)
{
    uint4 assets;
    uint4 tileData[64];
}

Texture2DArray tilesets : register(t0);
Texture2D gradient : register(t1);
SamplerState texSampler
{
    Filter = MIN_MAG_MIP_POINT;
    AddressU = Wrap;
    AddressV = Wrap;
};

////////////////////////////////////////////////////////////////
// Functions
////////////////////////////////////////////////////////////////

uint unpackByteFromTileData(uint index)
{
    uint bufferIndex = index / 16;
    uint componentIndex = (index % 16) / 4;
    uint block = tileData[bufferIndex][componentIndex];

    uint shift = (index % 4) * 8;
    uint byte = (block >> shift) & 0xFF;
    
    return byte;
}

float3 calcTileUV(uint vertex, uint screenIndex, uint layer)
{   
    uint byteIndex = (layer * TILES_PER_LAYER) + screenIndex;
    uint tileIndex = unpackByteFromTileData(byteIndex);
    
    uint tileset;
    if (tileIndex < TILES_PER_TILESET)
    {
        tileset = assets.x; // tileset A
    }
    else
    {
        tileIndex -= TILES_PER_TILESET;
        tileset = assets.y; // tileset B
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

float2 calcGradientUV(uint vertex, uint screenIndex)
{
    uint screenX = screenIndex % SCREEN_WIDTH;
    uint screenY = screenIndex / SCREEN_WIDTH;
    
    float2 uv = float2(screenX, screenY);
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
    uv.y /= SCREEN_HEIGHT;
    
    return uv;
}

float4 blend(float4 foreground, float4 background)
{
    return float4(foreground.a * foreground.rgb + (1 - foreground.a) * background.rgb, 1.0f);
}

////////////////////////////////////////////////////////////////
// Vertex Shader
////////////////////////////////////////////////////////////////

PS_IN VS(VS_IN input)
{
    PS_IN output = (PS_IN) 0;
    
    uint screenIndex = input.vid / 6;
    uint vertex = input.vid % 6;
    
    output.layer0 = unpackByteFromTileData((0 * TILES_PER_LAYER) + screenIndex);
    output.layer1 = unpackByteFromTileData((1 * TILES_PER_LAYER) + screenIndex);
    output.layer2 = unpackByteFromTileData((2 * TILES_PER_LAYER) + screenIndex);
    output.layer3 = unpackByteFromTileData((3 * TILES_PER_LAYER) + screenIndex);
    
    output.position = mul(input.position, viewProj);
    output.uv0 = calcTileUV(vertex, screenIndex, 0);
    output.uv1 = calcTileUV(vertex, screenIndex, 1);
    output.uv2 = calcTileUV(vertex, screenIndex, 2);
    output.uv3 = calcTileUV(vertex, screenIndex, 3);
    output.uvBackground = calcGradientUV(vertex, screenIndex);
    
    return output;
}

////////////////////////////////////////////////////////////////
// Pixel Shader
////////////////////////////////////////////////////////////////

float4 PS(PS_IN input) : SV_Target
{   
    float4 background = gradient.Sample(texSampler, input.uvBackground);
    float4 color0 = blend(tilesets.Sample(texSampler, input.uv0), background);
    float4 color1 = blend(tilesets.Sample(texSampler, input.uv1), color0);
    float4 color2 = blend(tilesets.Sample(texSampler, input.uv2), color1);
    float4 color3 = blend(tilesets.Sample(texSampler, input.uv3), color2);

    return color3;
}
