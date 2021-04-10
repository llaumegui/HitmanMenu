using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTabs : MonoBehaviour
{

    int _direction;
    public float Speed;

    public Vector2 Limits;
    public RectTransform RectT;

    public void SetDir(int dir)
    {
        _direction = dir;
    }

    public void SetDirToNull()
    {
        _direction = 0;
    }

    private void Update()
    {
        if (_direction ==0)
            return;

        if (RectT.anchoredPosition.x <= Limits.x && _direction ==-1)
            RectT.anchoredPosition = new Vector2(Limits.x,RectT.anchoredPosition.y);
        else if (RectT.anchoredPosition.x >= Limits.y && _direction ==1)
            RectT.anchoredPosition = new Vector2(Limits.y, RectT.anchoredPosition.y);
        else
        {
            RectT.anchoredPosition = new Vector2(RectT.anchoredPosition.x + (_direction * Speed), RectT.anchoredPosition.y);
        }

    }

}
