Shader "Custom/VignetteShader" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _VignetteColor ("Vignette Color", Color) = (0, 0, 0, 1)
        _VignetteRadius ("Vignette Radius", Range(0, 1)) = 0.5
        _VignetteSoftness ("Vignette Softness", Range(0, 1)) = 0.5
    }
    SubShader {
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _VignetteColor;
            float _VignetteRadius;
            float _VignetteSoftness;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                fixed4 col = tex2D(_MainTex, i.uv);
                float dist = length(i.uv - 0.5);
                float vignette = smoothstep(_VignetteRadius, _VignetteRadius - _VignetteSoftness, dist);
                col.rgb *= lerp(1, _VignetteColor.rgb, vignette);
                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}