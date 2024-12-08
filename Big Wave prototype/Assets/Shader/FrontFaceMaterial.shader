Shader "Unlit/FrontFaceMaterial"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _FrontColor ("Front Color", Color) = (1, 1, 1, 1) // �O�ʗp�̐F
        _BackColor ("Back Color", Color) = (1, 1, 1, 1) // �w�ʗp�̐F
        _SideColor ("Side Color", Color) = (1, 1, 1, 1) // ���ʗp�̐F
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            ZWrite On
            Blend Off
            Cull Back

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;    // �@���f�[�^��ǉ�
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float3 localNormal : TEXCOORD1; // ���[���h���W�n�̖@����n��
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _FrontColor;
            fixed4 _BackColor;
            fixed4 _SideColor;

            // ���_�V�F�[�_�[
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                // �I�u�W�F�N�g��Ԃ̖@�������[���h��Ԃɕϊ�
                o.localNormal = normalize(v.normal);

                UNITY_TRANSFER_FOG(o, o.vertex);
                return o;
            }

            // �t���O�����g�V�F�[�_�[
            fixed4 frag (v2f i) : SV_Target
            {
                // ��{�̃e�N�X�`���J���[���擾
                fixed4 col = tex2D(_MainTex, i.uv);

                float3 n = normalize(i.localNormal);

                // �O�ʁA���ʁA�w�ʂ̔���
                if (n.z < -0.5) // �O�ʁiz ���傫���j
                {
                    col *= _FrontColor;
                }
                else if (n.z > 0.5) // �w�ʁiz ���������j
                {
                    col = _BackColor;
                }
                else // ���ʁiz ���O�ʂ�w�ʂłȂ��ꍇ�j
                {
                    col = _SideColor;
                }

                // �t�H�O�̓K�p
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}