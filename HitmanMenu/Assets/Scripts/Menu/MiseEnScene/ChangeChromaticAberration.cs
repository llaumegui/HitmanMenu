using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChangeChromaticAberration : MonoBehaviour
{
    ChromaticAberration _chromatic;
    public bool EnableChromatic = true;

    public Vector2 MinMaxTime;
    public float MaxIntensity;
    public float Frequence;

    bool _reload;
    float _frequence;
    float _interpolator;
    float _intensity;

    private void Awake()
    {
        GetComponent<PostProcessVolume>().profile.TryGetSettings(out _chromatic);
    }

    private void Start()
    {
        if(EnableChromatic)
        StartCoroutine(Reload());
    }

    private void Update()
    {
        if(_chromatic!=null && EnableChromatic)
        {
            if (_reload)
                return;

            _interpolator += Time.deltaTime / _frequence;

            _chromatic.intensity.value = Mathf.Lerp(0, _intensity, _interpolator);

            if(_interpolator>=1)
            {
                _reload = true;
                StartCoroutine(Reload());
            }
        }
    }

    IEnumerator Reload()
    {
        _chromatic.intensity.value = 0;
        _reload = true;
        int rdm = Random.Range(0, 2);
        if (rdm == 1)
        {
            yield return new WaitForSeconds(Frequence / 3);
            _chromatic.intensity.value = _intensity;
            yield return new WaitForSeconds(Frequence / 3);
            _chromatic.intensity.value = 0;
            yield return new WaitForSeconds(Frequence / 3);
        }
        else
            yield return new WaitForSeconds(Frequence);

        _interpolator = 0;
        _frequence = Random.Range(MinMaxTime.x, MinMaxTime.y);
        _intensity = Random.Range(0, MaxIntensity);

        //_chromatic.intensity.value = _intensity / (Random.Range(1, 11));


        _reload = false;
    }
}
