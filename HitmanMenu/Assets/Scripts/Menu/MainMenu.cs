using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static string SelectionSubText;
    public static string SelectionMainText;
    public static Sprite SelectionIconSprite;

    public TextMeshProUGUI SelectionSub;
    public TextMeshProUGUI SelectionMain;
    public Image SelectionIcon;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        SoundManager.PlayLoop("Music", SoundManager.Sound.Music, 1, true);
    }

    public void ApplyText()
    {
        SelectionSub.text = SelectionSubText;
        SelectionMain.text=SelectionMainText;
        SelectionIcon.sprite = SelectionIconSprite;
    }


    public void PlayHitmune()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
