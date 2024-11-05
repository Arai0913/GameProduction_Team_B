using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�w��I�u�W�F�N�g��y����z���𓯂���������������
public class CinemachineExtend_Look : CinemachineExtension
{
    [Header("����ɓ��ꂽ�I�u�W�F�N�g��y���̂ݏ�ɓ��������������悤�ɂȂ�")]
    [SerializeField] Transform lookObj;

    // �J�������[�N����
    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage,
        ref CameraState state,
        float deltaTime
    )
    {
        // Aim�̒��ゾ�����������{
        if (stage != CinemachineCore.Stage.Aim)
            return;

        //y����z���𓯂���������������
        var eulerAngles = state.RawOrientation.eulerAngles;
        eulerAngles.y=lookObj.eulerAngles.y;
        eulerAngles.z = 0;
        state.RawOrientation = Quaternion.Euler(eulerAngles);
        //Quaternion rot = state.RawOrientation;
        //rot.y=lookObj.rotation.y;
        //rot.z=0;
        //state.RawOrientation = rot;
    }
}
