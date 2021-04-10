using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class Loading : MonoBehaviour
{
    public Vector2 MinMaxTime;

    public GameObject Obj;

    [Header("Data")]
    public TextMeshProUGUI InfoText;
    public Image Icon;
    public Image FillImage;
    public Image ImageFade;

    public List<LoadingData> Datas;

    public UnityEvent EndEvent;

    [System.Serializable]
    public class LoadingData
    {
        public Sprite Icon;
        public string TextData;
    }

    private void Awake()
    {
        if(ImageFade!=null)
        ImageFade.DOColor(new Color(0, 0, 0, 0),0);
        Obj.SetActive(false);
    }

    IEnumerator Authentification()
    {
        Obj.SetActive(true);

        float loadingTime = Random.Range(MinMaxTime.x, MinMaxTime.y);
        float intervals = loadingTime / Datas.Count;
        float percentage = 100/Datas.Count;
        float currentpercent = 0;

        foreach (LoadingData data in Datas)
        {
            ApplyInfos(data, currentpercent);

            yield return new WaitForSeconds(intervals/2);
            currentpercent = Random.Range(currentpercent, percentage);
            ApplyInfos(data, currentpercent);

            yield return new WaitForSeconds(intervals / 2);
            currentpercent = Random.Range(currentpercent, percentage);
            percentage += percentage;
        }

        if(ImageFade != null)
        {
            Sequence sqc = DOTween.Sequence();
            sqc.Append(ImageFade.DOColor(new Color(0, 0, 0, 1), .5f));
            sqc.Append(ImageFade.DOColor(new Color(0, 0, 0, 0), .5f));
            sqc.Play();
        }

        yield return new WaitForSeconds(.5f);
        Obj.SetActive(false);
        EndEvent.Invoke();
    }

    void ApplyInfos(LoadingData data,float fill)
    {
        FillImage.fillAmount = fill / 100;
        Icon.sprite = data.Icon;
        InfoText.text = data.TextData;
    }

    public void PlayAuthentification()
    {
        StartCoroutine(Authentification());
    }
}
