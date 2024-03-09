Shader "Custom/Slices"
{
  Properties {
    _MainTex ("Texture", 2D) = "white" {}
    _BumpMap ("Bumpmap", 2D) = "bump" {}
  }
  SubShader {
    Tags { "RenderType" = "Opaque" }
    Cull Off
    CGPROGRAM
    // #include "UnityCG.cginc" // For _ScreenParams
    #pragma surface surf Lambert
    struct Input {
      float2 uv_MainTex;
      float2 uv_BumpMap;
      float3 worldPos;
    };
    sampler2D _MainTex;
    sampler2D _BumpMap;
    void surf (Input IN, inout SurfaceOutput o) {
      // float aspect_ratio = _ScreenParams.x / _ScreenParams.y;
      // clip (frac((IN.worldPos.y+IN.worldPos.z*0.1) * 5) - 0.5);
      // clip (frac((IN.worldPos.x+IN.worldPos.z*0.1) * 5 * aspect_ratio) - 0.5);

      clip (frac((IN.worldPos.x) * 8) - 0.5);
      clip (frac((IN.worldPos.y) * 8) - 0.5);
      clip (frac((IN.worldPos.z) * 8) - 0.5);
      // clip (frac((IN.worldPos.x) * 5 * aspect_ratio) - 0.5);

      o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
      o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
    }
    ENDCG
  }
  Fallback "Diffuse"
}
