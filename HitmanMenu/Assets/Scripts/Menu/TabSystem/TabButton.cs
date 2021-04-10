using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler,IPointerClickHandler,IPointerExitHandler
{
    public TabGroup Group;

    [HideInInspector]
    public Image Background;

    public TextMeshProUGUI TextBox;

    public Image Icon;
    public Image IconFill;


    private void Awake()
    {
        Background = GetComponent<Image>();
        Group.Subscribe(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Group.TabSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Group.TabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Group.TabExit(this);
    }

}
