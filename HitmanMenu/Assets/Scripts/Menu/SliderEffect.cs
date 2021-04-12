using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Rendering.PostProcessing;

public class SliderEffect : MonoBehaviour
{
    public Slider SliderBase;
    public AudioMixer Mixer;
    public PostProcessVolume PostProcess;

    private void Awake()
    {
        if(SliderBase == null)
        SliderBase = GetComponent<Slider>();
    }

    public void ChangeValueAudio(string GroupName)
    {
        Mixer.SetFloat(GroupName, -40 + (SliderBase.value*40));
    }

    public void ChangeGamma()
    {
        if (PostProcess.profile.TryGetSettings(out ColorGrading cg))
            cg.postExposure.value = -1 +(2*SliderBase.value);


    }
}
