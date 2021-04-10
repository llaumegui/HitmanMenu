using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Blink : MonoBehaviour
{
    public TextMeshProUGUI TextToBlink;
    public float Timing;

    bool _back;
    float _value;

    private void Start()
    {
        float alpha = 0;
        Color c = TextToBlink.color;
        c.a = alpha;
        TextToBlink.color = c;
    }

    void ChangeColor(float alpha)
    {
        Color c = TextToBlink.color;
        c.a = alpha;
        TextToBlink.color = c;
    }

    private void Update()
    {
        _value += Time.deltaTime/Timing;
        ChangeColor(Mathf.Abs(Mathf.Cos(_value)));
    }
}
