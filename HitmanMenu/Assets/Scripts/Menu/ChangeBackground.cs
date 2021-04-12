using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChangeBackground : MonoBehaviour
{
    Image _target;
    Sprite _empty;

    private void Awake()
    {
        _target = GetComponent<Image>();
        _empty = _target.sprite;
    }

    public void SetBackground(Sprite spr)
    {
        StopAllCoroutines();
        _target.sprite = spr;
        _target.DOColor(new Color(1, 1, 1, 1), .25f);
    }

    public void EmptyBackground()
    {
        StartCoroutine(EmptySprite());
        _target.DOColor(new Color(1, 1, 1, 0), .25f);
    }

    IEnumerator EmptySprite()
    {
        yield return new WaitForSeconds(.25f);
        _target.sprite = _empty;
    }
}
