using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    List<TabButton> _tabButtons;

    [Header("ChangeSprite")]
    public Sprite TabIdle;
    public Sprite TabHover;
    public Sprite TabActive;

    [Header("ChangeColor")]
    public Color IdleColor;
    public Color HoverColor;
    public Color ActiveColor;

    [Header("Change Icon")]
    public Sprite IdleIconBG;
    public Sprite ActiveIconBG;

    [Space]
    public List<GameObject> ObjectsToSwap;

    TabButton _buttonSelected;

    public bool StartWithTab;

    private void Start()
    {
        ResetTabs();
        if (!StartWithTab)
            ResetPages();
        else
            TabSelected(_tabButtons[0]);
    }

    public void Subscribe(TabButton button)
    {
        if (_tabButtons == null)
            _tabButtons = new List<TabButton>();

        _tabButtons.Add(button);
    }

    public void TabEnter(TabButton button)
    {
        if(button != _buttonSelected)
        {
            ResetTabs();
            if (TabHover != null)
            {
                button.Background.sprite = TabHover;

            }

            button.Background.color = HoverColor;

            if (button.IconFill != null)
                button.IconFill.sprite = ActiveIconBG;

            if (button.Icon != null)
                button.Icon.color = HoverColor;

            if (button.TextBox != null)
                button.TextBox.color = HoverColor;
        }
    }

    public void TabExit(TabButton button)
    {
        ResetTabs();
    }

    public void TabSelected(TabButton button)
    {
        _buttonSelected = button;
        ResetTabs();

        if (TabActive != null)
            button.Background.sprite = TabActive;

        button.Background.color = ActiveColor;

        if (button.IconFill != null)
            button.IconFill.sprite = ActiveIconBG;

        if (button.Icon != null)
            button.Icon.color = HoverColor;

        if (button.TextBox != null)
            button.TextBox.color = ActiveColor;

        int index = button.transform.GetSiblingIndex();
        for(int i =0;i<ObjectsToSwap.Count;i++)
        {
            if (i == index)
                ObjectsToSwap[i].SetActive(true);
            else
                ObjectsToSwap[i].SetActive(false);
        }
    }

    public void ResetTabs()
    {
        foreach(TabButton button in _tabButtons)
        {
            if (button == _buttonSelected)
                continue;
            if (TabIdle != null)
                button.Background.sprite = TabIdle;

            button.Background.color = IdleColor;
            if (button.TextBox != null)
                button.TextBox.color = IdleColor;

            if (button.IconFill != null)
                button.IconFill.sprite = IdleIconBG;

            if (button.Icon != null)
                button.Icon.color = Color.white;
        }
    }

    public void ResetPages()
    {
        foreach (GameObject page in ObjectsToSwap)
            page.SetActive(false);
    }
}
