using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateWave : MonoBehaviour
{
    //☆作成者:杉山
    [Header("波の生成位置")]
    [SerializeField] GameObject instantiateWavePos;//波の生成位置
    [Header("波のプレハブ")]
    [SerializeField] LineWave wavePrefab;//波のプレハブ
    [Header("波の出現間隔")]
    [SerializeField] float waveInterval;//初期以降の波の出現間隔
    [Header("GamePos")]
    [SerializeField] GameObject gamePos;//GamePos
    [Header("LineInstantiate")]
    [SerializeField] LineInstantiate m_lineInstantiate;
    private float m_waveTime=0;//波の出現間隔を管理する時間(内部数値)
    bool _switch = false;//これがfalseになっている時は波を生成しない、trueの時は波を生成する

    public bool Switch
    {
        get { return _switch; }
        set { _switch = value; }
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateWavePrefab();//波の生成
    }

    //波の生成、waveIntervalTimeの時間ごとに波を生成する
    void InstantiateWavePrefab()
    {
        if (!_switch) return;//まだゲーム開始されてなかったら波を生成しない

        m_waveTime += Time.deltaTime;//波の出現間隔を管理する時間を更新
        
        if (m_waveTime > waveInterval)
        {
            m_waveTime = 0f;//波の出現間隔を管理する時間をリセット
            LineWave lineWave = Instantiate(wavePrefab, instantiateWavePos.transform.position, transform.rotation, gamePos.transform);//波を生成
            lineWave.transform.localRotation = Quaternion.Euler(0, 180, 0);//波を後ろ向き(プレイヤー方向)にする
            m_lineInstantiate.Add(lineWave.transform);
            lineWave.GetLineInstantiate(m_lineInstantiate);
        }
    }
}
