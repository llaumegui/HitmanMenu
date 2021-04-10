using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DragDirections : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public DragTabs DragTab;
    public int Dir;

    public void OnPointerEnter(PointerEventData eventData)
    {
        DragTab.SetDir(Dir);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DragTab.SetDirToNull();
    }
}
