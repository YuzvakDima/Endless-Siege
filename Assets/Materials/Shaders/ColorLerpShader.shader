Shader "Custom/TrapReadyLerpShader"
{
    Properties
    {
        _ColorA ("Color A", Color) = (1, 1, 0, 1) 
        _ColorB ("Color B", Color) = (1, 0, 0, 1) 
        _IdleColor ("Idle Color", Color) = (0.5, 0.5, 0.5, 1) 
        _Speed ("Lerp Speed", Float) = 2.0
        _IsReady ("Is Ready", Float) = 0.0 
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            fixed4 _ColorA;
            fixed4 _ColorB;
            fixed4 _IdleColor;
            float _Speed;
            float _IsReady;

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                if (_IsReady < 0.5)
                {
                    return _IdleColor;
                }
                else
                {
                    float t = (sin(_Time.y * _Speed) + 1.0) * 0.5;
                    return lerp(_ColorA, _ColorB, t);
                }
            }
            ENDCG
        }
    }
}
