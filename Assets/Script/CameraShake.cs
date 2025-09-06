using Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;
    public float startTime;

    void Start()
    {
        
    }

 
    void Update()
    {
        if(startTime > 0f)
        {
            startTime -= Time.deltaTime;

            if(startTime <= 0)
            {
                CinemachineBasicMultiChannelPerlin perlin = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                perlin.m_AmplitudeGain = 0f;
            }
        }

    }

    public void Shake( float duration, float intensity)
    {
        startTime = duration;
        CinemachineBasicMultiChannelPerlin perlin = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perlin.m_AmplitudeGain = intensity;
    }
}
