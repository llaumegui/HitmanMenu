using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ButtonFeedbacks : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [System.Serializable]
    public class FeedbackDataImage
    {
        public Image ImageElement;
        public Sprite DefaultSprite;
        public Sprite ActivatedSprite;
        public Color DefaultColor;
        public Color ActivatedColor;
    }

    [System.Serializable]
    public class FeedbackDataText
    {
        public TextMeshProUGUI TextElement;

        public Color DefaultColor;
        public Color ActivatedColor;
    }

    public float ScaleSelect=1;



    public List<FeedbackDataImage> Images;
    public List<FeedbackDataText> Texts;


    public void OnPointerEnter(PointerEventData eventData)
    {

        transform.DOScale(ScaleSelect, .25f);


        foreach(FeedbackDataImage i in Images)
        {
            if (i.ActivatedSprite != null)
                i.ImageElement.sprite = i.ActivatedSprite;
            i.ImageElement.color = i.ActivatedColor;
        }

        foreach(FeedbackDataText t in Texts)
        {
            t.TextElement.color = t.ActivatedColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1, .25f);

        foreach (FeedbackDataImage i in Images)
        {
            if (i.DefaultSprite != null)
                i.ImageElement.sprite = i.DefaultSprite;
            i.ImageElement.color = i.DefaultColor;
        }

        foreach (FeedbackDataText t in Texts)
        {
            t.TextElement.color = t.DefaultColor;
        }
    }
}
