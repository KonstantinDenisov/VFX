// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Blend_CenterGlow"
{
	Properties
	{
		
	}
	
	SubShader
	{
		Tags { "RenderType"="Opaque" }
	LOD 100
		CGINCLUDE
		#pragma target 3.0
		ENDCG
		Blend Off
		AlphaToMask Off
		Cull Back
		ColorMask RGBA
		ZWrite On
		ZTest LEqual
		Offset 0 , 0
		
		CGINCLUDE
			#ifndef UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX
			#define UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input)
			#endif
		ENDCG
		Pass
		{
			
			Tags { "LightMode"="VertexLMRGBM" "RenderType"="Opaque" }
			Name "Unlit LM"
			CGPROGRAM
			
			#pragma target 2.0
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			

			struct appdata
			{
				float4 vertex : POSITION;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				
			};
			
			struct v2f
			{
				float4 vertex : SV_POSITION;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
				
			};

			
			
			v2f vert ( appdata v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				
				
				v.vertex.xyz +=  float3(0,0,0) ;
				o.vertex = UnityObjectToClipPos(v.vertex);
				return o;
			}
			
			fixed4 frag (v2f i ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( i );
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( i );
				fixed4 finalColor;
				
				
				finalColor = fixed4(1,1,1,1);
				return finalColor;
			}
			ENDCG
		}
		
		Pass
		{
			
			Tags { "LightMode"="VertexLM" "RenderType"="Opaque" }
			Name "Unlit LM Mobile"
			CGPROGRAM
			
			#pragma target 2.0
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			

			struct appdata
			{
				float4 vertex : POSITION;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				
			};
			
			struct v2f
			{
				float4 vertex : SV_POSITION;
				UNITY_VERTEX_OUTPUT_STEREO
				
			};

			
			
			v2f vert ( appdata v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				
				
				v.vertex.xyz +=  float3(0,0,0) ;
				o.vertex = UnityObjectToClipPos(v.vertex);
				return o;
			}
			
			fixed4 frag (v2f i ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( i );
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( i );
				fixed4 finalColor;
				
				
				finalColor = fixed4(1,1,1,1);
				return finalColor;
			}
			ENDCG
		}
	}
	CustomEditor "ASEMaterialInspector"
	
	
}
/*ASEBEGIN
Version=18935
0;0;2560;1379;781.5066;612.5164;1.00134;True;True
Node;AmplifyShaderEditor.TimeNode;1;-1394.506,-181.1542;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ComponentMaskNode;30;-77.20967,-98.28478;Inherit;False;True;True;True;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ComponentMaskNode;31;-75.90969,-259.4848;Inherit;False;True;True;True;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;11;-542.3186,-57.95593;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;33;382.8466,118.7501;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;32;211.9904,-4.084814;Inherit;False;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;21;-1050.91,433.4149;Inherit;True;Property;_Mask;Mask;2;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DepthFade;37;409.8466,446.7501;Inherit;False;True;False;True;2;1;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;38;675.8466,402.7501;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;39;875.8466,227.7501;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;34;587.8466,-106.2499;Inherit;False;Property;_Keyword0;Keyword 0;4;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;COLOR;0,0,0,0;False;0;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StaticSwitch;40;1037.847,151.7501;Inherit;False;Property;_Keyword1;Keyword 0;5;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;43;1198.847,1.750122;Inherit;False;Property;_Emission;Emission;7;0;Create;True;0;0;0;False;0;False;2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;35;639.8466,98.75012;Inherit;False;4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;22;-712.9106,443.8149;Inherit;False;True;True;True;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;44;1367.847,-73.24988;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ComponentMaskNode;8;-932.3186,-156.9559;Inherit;False;True;True;True;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ClampOpNode;25;-300.8095,579.0157;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ComponentMaskNode;29;-151.3098,94.11512;Inherit;False;True;True;True;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ComponentMaskNode;28;-174.7097,280.0151;Inherit;False;True;True;True;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;36;235.8466,509.7501;Inherit;False;Property;_Depthpower;Depth power;6;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;17;-403.419,-278.2558;Inherit;True;Property;_MainTex;MainTex;0;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector4Node;16;-1090.319,-461.9559;Inherit;False;Constant;_TillingMainTexUVNoiseZ;Tilling MainTex UV / Noise Z;0;0;Create;True;0;0;0;False;0;False;1,1,1,1;0,0,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;15;-1148.319,-280.9559;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;2;-1207.319,-31.95593;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;3;-1374.319,-18.95593;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ClampOpNode;27;20.29019,455.5152;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;5;-1181.319,-172.9559;Inherit;False;0;-1;3;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;13;-735.3186,-251.9559;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;26;-156.51,455.5149;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;19;-393.9188,95.14407;Inherit;False;Property;_Color;Color;3;0;Create;True;0;0;0;False;0;False;1,1,1,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VertexColorNode;20;-390.2189,270.8443;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;18;-402.119,-92.3559;Inherit;True;Property;_Noise;Noise;1;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleSubtractOpNode;24;-451.6097,582.9151;Inherit;False;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.TFHCRemapNode;23;-680.4098,614.1154;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;4;-1373.319,-272.9559;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;45;1370.847,150.7501;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;9;-752.3186,-359.9559;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;14;-744.3186,40.04407;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT2;0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.DynamicAppendNode;10;-875.3186,-60.95593;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;-545.3186,-246.9559;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;7;1453.257,161.1795;Float;False;False;-1;2;ASEMaterialInspector;100;1;New Amplify Shader;899e609c083c74c4ca567477c39edef0;True;Unlit LM Mobile;0;1;Unlit LM Mobile;0;False;True;0;1;False;-1;0;False;-1;0;1;False;-1;0;False;-1;True;0;False;-1;0;False;-1;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;True;0;False;-1;False;True;True;True;True;True;0;False;-1;False;False;False;False;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;False;True;1;False;-1;True;3;False;-1;True;True;0;False;-1;0;False;-1;True;1;RenderType=Opaque=RenderType;True;2;False;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;LightMode=VertexLM;RenderType=Opaque=RenderType;True;0;False;0;;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;6;1577.257,10.1795;Float;False;True;-1;2;ASEMaterialInspector;100;7;Blend_CenterGlow;899e609c083c74c4ca567477c39edef0;True;Unlit LM;0;0;Unlit LM;2;False;True;0;1;False;-1;0;False;-1;0;1;False;-1;0;False;-1;True;0;False;-1;0;False;-1;False;False;False;False;False;False;False;False;False;True;0;False;-1;False;True;0;False;-1;False;True;True;True;True;True;0;False;-1;False;False;False;False;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;False;True;1;False;-1;True;3;False;-1;True;True;0;False;-1;0;False;-1;True;1;RenderType=Opaque=RenderType;True;2;False;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;LightMode=VertexLMRGBM;RenderType=Opaque=RenderType;True;0;False;0;;0;0;Standard;0;0;2;True;True;False;;False;0
WireConnection;30;0;18;0
WireConnection;31;0;17;0
WireConnection;11;0;10;0
WireConnection;11;1;14;0
WireConnection;33;0;32;0
WireConnection;33;1;27;0
WireConnection;32;0;31;0
WireConnection;32;1;30;0
WireConnection;32;2;29;0
WireConnection;32;3;28;0
WireConnection;37;0;36;0
WireConnection;38;0;37;0
WireConnection;39;0;35;0
WireConnection;39;1;38;0
WireConnection;34;1;32;0
WireConnection;34;0;33;0
WireConnection;40;1;35;0
WireConnection;40;0;39;0
WireConnection;35;0;17;4
WireConnection;35;1;18;4
WireConnection;35;2;19;4
WireConnection;35;3;20;4
WireConnection;22;0;21;0
WireConnection;44;0;34;0
WireConnection;44;1;43;0
WireConnection;8;0;5;0
WireConnection;25;0;24;0
WireConnection;29;0;19;0
WireConnection;28;0;20;0
WireConnection;17;1;12;0
WireConnection;15;0;4;0
WireConnection;15;1;1;2
WireConnection;2;0;1;2
WireConnection;2;1;3;0
WireConnection;27;0;26;0
WireConnection;13;0;15;0
WireConnection;13;1;8;0
WireConnection;26;0;22;0
WireConnection;26;1;25;0
WireConnection;18;1;11;0
WireConnection;24;0;22;0
WireConnection;24;1;23;0
WireConnection;23;0;5;3
WireConnection;45;0;40;0
WireConnection;9;0;16;1
WireConnection;9;1;16;2
WireConnection;14;0;8;0
WireConnection;14;1;2;0
WireConnection;10;0;16;3
WireConnection;10;1;16;4
WireConnection;12;0;9;0
WireConnection;12;1;13;0
ASEEND*/
//CHKSM=CC28CE420B9ECB2E2A327E413B08BB3C2E3573A9