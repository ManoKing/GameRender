Shader "Custom/Unlit/Diffuse" {
	Properties{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
#pragma surface surf Lamb

		// Use shader model 3.0 target, to get nicer looking lighting
#pragma target 3.0

		sampler2D _MainTex;

	inline fixed4 LightingLamb(SurfaceOutput s, fixed3 lightDir,  fixed atten) {
		float diff = dot(s.Normal,lightDir);
		fixed4 c;
		c.rgb = (s.Albedo * _LightColor0.rgb * diff);
		c.a = 1.0;
		return c;
	}

	struct Input {
		float2 uv_MainTex;
	};

	void surf(Input IN, inout SurfaceOutput o) {
		half4 c = tex2D(_MainTex, IN.uv_MainTex);
		o.Albedo = c.rgb;
		o.Alpha = c.a;
	}
	ENDCG
	}
		FallBack "Diffuse"
}