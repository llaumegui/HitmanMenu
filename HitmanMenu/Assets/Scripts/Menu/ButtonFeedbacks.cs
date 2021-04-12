using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.Rendering;

public class ButtonFeedbacks : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
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

    [Header("Lock")]
    public GameObject Lock;
    public bool Locked;

    public UnityEvent PointerEnterEvent;
    public UnityEvent PointerExitEvent;

    public Canvas ParentCanvas;
    int _sortingParent;

    private void Awake()
    {
        if (ParentCanvas!=null)
            _sortingParent = ParentCanvas.sortingOrder;

        if (Locked)
            Lock.SetActive(true);
        else
            Lock.SetActive(false);
    }

    private void OnEnable()
    {
        transform.DOScale(1, 0);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundManager.PlaySound(SoundManager.Sound.HoverButton);

        if(PointerEnterEvent.GetPersistentEventCount()!=0)
        {
            if(Images.Count!=0)
            MainMenu.SelectionIconSprite = Images[1].ImageElement.sprite;

            MainMenu.SelectionSubText = Texts[0].TextElement.text;
            MainMenu.SelectionMainText = Texts[1].TextElement.text;
            PointerEnterEvent.Invoke();
        }

        GetComponent<Canvas>().sortingOrder = 3 + _sortingParent;

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
        if (PointerExitEvent.GetPersistentEventCount() != 0)
            PointerExitEvent.Invoke();

            GetComponent<Canvas>().sortingOrder = 2 + _sortingParent;
        transform.DOScale(1, .25f).OnComplete(()=>ResetCanvas());

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

    void ResetCanvas()
    {
        GetComponent<Canvas>().sortingOrder = 1 + _sortingParent;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager.PlaySound(SoundManager.Sound.ClickButton);
    }


    public void EnableDisable(GameObject obj)
    {
        if (obj.activeInHierarchy)
            obj.SetActive(false);
        else
            obj.SetActive(true);
    }
}
