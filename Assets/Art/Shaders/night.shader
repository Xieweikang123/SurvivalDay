Shader "mask shader" {
	Properties{

		_MainTex("Base (RGB)", 2D) = "white" {}

		_Mask("Culling Mask", 2D) = "white" {}	//贴图作为遮罩
		
	/*	_Mask0("Mask0", 2D) = "white" {}
		_Mask1("Mask1", 2D) = "white" {}*/

		
		_Cutoff("Alpha cutoff", Range(0,1)) = 0.1	//调整后期边缘的透明度

	}
		SubShader{
			//Tags { "RenderType"="Opaque" }
			Tags{ "Queue" = "Transparent" }  //这个决定了渲染方式，是保证所有的不透明物体都会在半透明物体之前被渲染，简单的说就是我们可以进行透明度的渲染了。
			Lighting Off

				ZWrite Off

				Blend SrcAlpha OneMinusSrcAlpha

				AlphaTest GEqual[_Cutoff]

				Pass

				{
					SetTexture[_Mask]{ combine texture }
					SetTexture[_MainTex]{ combine texture,texture - previous }
			
				/*	SetTexture[_Mask0]{ combine previous,previous - texture }
					SetTexture[_Mask1]{ combine previous,previous - texture }*/

				}
		}
}
