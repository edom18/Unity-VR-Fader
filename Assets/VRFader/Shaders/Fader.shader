Shader "Custom/Fader" {
	Properties {
		_Width ("Width", Float) = 5
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" "Queue"="Transparent" }
		LOD 200

		CGPROGRAM

		#pragma surface surf Standard alpha:fade

		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		float _Width;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			float strength = length(fixed2(0.5) - IN.uv_MainTex) * 2.;
			float alpha    = 1. - pow(strength, _Width);
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;

			o.Albedo     = c.rgb;
			o.Alpha      = alpha;
			o.Metallic   = _Metallic;
			o.Smoothness = _Glossiness;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
