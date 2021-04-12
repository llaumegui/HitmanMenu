using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomText : MonoBehaviour
{
    TMPro.TextMeshProUGUI _txt;
    public List<string> Texts;


    private void Awake()
    {
        _txt = GetComponent<TMPro.TextMeshProUGUI>();
    }


    private void OnEnable()
    {
        SetText();
    }

    private void SetText()
    {
        int id = Random.Range(0, Texts.Count);

        _txt.text = Texts[id];
    }
}
