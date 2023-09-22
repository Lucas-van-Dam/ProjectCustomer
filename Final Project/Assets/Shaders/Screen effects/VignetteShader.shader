Shader "Custom/Vignette" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _VignetteColor ("Vignette Color", Color) = (0,0,0,1)
        _VignettePower ("Vignette Power", Range(0.0, 1.0)) = 0.5
    }
    SubShader {
        
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
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
            float4 _VignetteColor;
            float _VignettePower;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                fixed4 col = tex2D(_MainTex, i.uv);
                float dist = distance(i.uv, 0.5);
                col.rgb *= saturate(1.0 - pow(dist * _VignettePower, 2.0));
                col.rgb += _VignetteColor.rgb * pow(dist, 8.0);
                col.rgba = float4(0,1,1,1);
                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}