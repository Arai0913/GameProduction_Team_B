using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�w��I�u�W�F�N�g��y����z���𓯂���������������
public class CinemachineExtend_Look : CinemachineExtension
{
    [Header("�Ǐ]�ڕW")]
    [SerializeField] Transform target;
    [Header("�Œ肷�鎲")]
    [SerializeField] bool x;
    [SerializeField] bool y;
    [SerializeField] bool z;

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

        //�`�F�b�N����ꂽ�Œ莲�ɑ΂��ČŒ肷��
        var eulerAngles = state.RawOrientation.eulerAngles;
        if (x) eulerAngles.x = target.eulerAngles.x;//x���̌Œ�
        if (y) eulerAngles.y = target.eulerAngles.y;//x���̌Œ�
        if (z) eulerAngles.z = target.eulerAngles.z;//x���̌Œ�
        state.RawOrientation = Quaternion.Euler(eulerAngles);

        //y����z���𓯂���������������
        //var eulerAngles = state.RawOrientation.eulerAngles;
        //eulerAngles.y=lookObj.eulerAngles.y;
        //eulerAngles.z = 0;
        //state.RawOrientation = Quaternion.Euler(eulerAngles);
        //Quaternion rot = state.RawOrientation;
        //rot.y=lookObj.rotation.y;
        //rot.z=0;
        //state.RawOrientation = rot;
    }

    
}
