#include <Packages/com.blendernodesgraph.core/Editor/Includes/Importers.hlsl>

void test_float(float3 _POS, float3 _PVS, float3 _PWS, float3 _NOS, float3 _NVS, float3 _NWS, float3 _NTS, float3 _TWS, float3 _BTWS, float3 _UV, float3 _SP, float3 _VVS, float3 _VWS, Texture2D image_9906, out float4 Color, out float3 Normal, out float Smoothness, out float4 Emission, out float AmbientOcculusion, out float Metallic, out float4 Specular)
{
	
	float4 _ImageTexture_9906 = node_image_texture_LOD(image_9906, _UV, 0, 0);

	Color = _ImageTexture_9906;
	Normal = float3(0.0, 0.0, 0.0);
	Smoothness = 0.0;
	Emission = float4(0.0, 0.0, 0.0, 0.0);
	AmbientOcculusion = 0.0;
	Metallic = 0.0;
	Specular = float4(0.0, 0.0, 0.0, 0.0);
}