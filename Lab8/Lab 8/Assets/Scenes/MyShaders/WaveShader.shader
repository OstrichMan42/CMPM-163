Shader "Custom/WaveVShader"
{
	Properties
	{
		_Color("Color", Color) = (0, 0, 0, 1)
		_Strength("Strength", Range(0,2)) = 1.0
		_Speed("Speed", Range(-200,200)) = 100
		_MainTex ("Texture", 2D) = "white" {}
	}

		SubShader
	{
		Tags { "RenderType" = "transparent" }

		Pass
		{
			Cull Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			float4 _Color;
			float _Strength;
			float _Speed;

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

            float4 frag (vertexOutput IN) : COLOR
            {
                return _Color;
            }

            ENDCG
        }
    }
}
