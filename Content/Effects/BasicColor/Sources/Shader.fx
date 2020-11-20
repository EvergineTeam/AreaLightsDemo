[Begin_ResourceLayout]

	cbuffer Base : register(b0)
	{
		float4x4 WorldViewProj	: packoffset(c0);	[WorldViewProjection]
	};

	cbuffer Parameters : register(b1)
	{
		float3 Color			: packoffset(c0);   [Default(0.3, 0.3, 1.0)]
		float Intensity 		: packoffset(c0.w); [Default(1)]		
	};
	
	cbuffer Camera : register(b2)
	{
		float Exposure			: packoffset(c0.x); [CameraExposure]
	};

[End_ResourceLayout]

[Begin_Pass:Default]
	[profile 10_0]
	[entrypoints VS=VS PS=PS]

	struct VS_IN
	{
		float4 Position : POSITION;
		float3 Normal	: NORMAL;
		float2 TexCoord : TEXCOORD;
	};

	struct PS_IN
	{
		float4 pos : SV_POSITION;
		float3 Nor	: NORMAL;
		float2 Tex : TEXCOORD;
	};

	PS_IN VS(VS_IN input)
	{
		PS_IN output = (PS_IN)0;

		output.pos = mul(input.Position, WorldViewProj);
		output.Nor = input.Normal;
		output.Tex = input.TexCoord;

		return output;
	}

	float4 PS(PS_IN input) : SV_Target
	{
		return float4(Color * Intensity * Exposure ,1);
	}

[End_Pass]