Shader "Custom/Cutting"
 
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Cutoff ("Cutoff Position", Float) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        float _Cutoff;

        struct Input
        {
            float3 worldPos;
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            // 设置剖面效果
            if (IN.worldPos.y > _Cutoff) // 使用Y轴进行剖面判断
            {
                discard;
            }
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}

