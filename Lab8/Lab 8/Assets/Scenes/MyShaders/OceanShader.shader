Shader "Custom/OceanShader"
{
	Properties
	{
		_Strength("Strength", Range(0,2)) = 1.0
		_Speed("Speed", Range(-200,200)) = 100
		_MainTex ("Texture", 2D) = "white"
	}

	SubShader
	{
		Tags { "RenderType" = "opaque" }

		Pass
		{
			Cull Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			float _Strength;
			float _Speed;
			sampler2D _MainTex;

            struct vertexInput
            {
                float4 vertex : POSITION;
            };

			struct vertexOutput
			{
				float4 pos : SV_POSITION;
			};

            vertexOutput vert (vertexInput IN)
            {
                vertexOutput o;

				float4 worldPos = mul(unity_ObjectToWorld, IN.vertex);

				float displacement = (cos(worldPos.y) + cos(worldPos.x + (_Speed * _Time)));
				worldPos.y = worldPos.y + (displacement * _Strength);

				o.pos = mul(UNITY_MATRIX_VP, worldPos);
                return o;
            }

			struct fragInput
			{
				float2 uv : TEXCOORD0;
			};

			fixed4 frag (fragInput IN) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, IN.uv);

				return col;
			}

            ENDCG
        }
    }
}
