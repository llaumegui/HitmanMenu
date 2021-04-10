using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        SoundManager.PlayLoop("Music", SoundManager.Sound.Music, 1, true);
    }
}
