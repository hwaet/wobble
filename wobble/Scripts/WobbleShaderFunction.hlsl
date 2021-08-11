#ifndef WOBBLE_HLSL
#define WOBBLE_HLSL

void Wobble_float(float4 ObjectVerts, float falloff, float radius, float strength, float3 wobblePosition, out float3 Out)
{
	//Out = ObjectVerts;

    float4 worldPosition = mul(unity_ObjectToWorld, ObjectVerts);
    float3 wobbleVec = worldPosition.xyz - wobblePosition;
    float3 direction = normalize(wobbleVec);

    float fade = 1 - (saturate(length(wobbleVec) / radius));
    fade = pow(fade, falloff); 

    worldPosition.xyz += (direction * fade * strength);

    Out = mul(unity_WorldToObject, worldPosition);
}

#endif