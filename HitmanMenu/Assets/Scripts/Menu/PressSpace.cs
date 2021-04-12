using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PressSpace : MonoBehaviour
{
    public UnityEvent Pressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.PlaySound(SoundManager.Sound.ClickTab);
            Pressed.Invoke();
        }
    }
}
