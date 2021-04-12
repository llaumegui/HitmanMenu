using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChangePic : MonoBehaviour
{
    public float Frequence;

    public List<Sprite> Sprites;
    Image _image;

    float _value;

    int _index;

    private void Start()
    {
        _image = GetComponent<Image>();
        ChangePic();
    }

    private void Update()
    {
        _value+=(Time.deltaTime/Frequence);

        if(_value>=1)
        {
            _value = 0;
            ChangePic();
        }
    }

    void ChangePic()
    {
        _image.sprite = Sprites[_index];

        _index++;

        if(_index>=Sprites.Count)
        {
            _index = 0;
        }
    }

}
