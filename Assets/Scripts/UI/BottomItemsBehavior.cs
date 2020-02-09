using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BottomItemsBehavior : MonoBehaviour
{
    [SerializeField]
    private GameManagerTrump gameManager;

    [SerializeField]
    private Button musicButton;
    [SerializeField]
    private Button fxButton;

    [SerializeField]
    private Sprite musicButtonSpriteActive;
    [SerializeField]
    private Sprite fxButtonSpriteActive;

    private Sprite musicButtonSpriteInactive;
    private Sprite fxButtonSpriteInactive;

    const string LEVEL_SCENE = "level";//"backup";

    public void Awake() {
        if (!FB.IsInitialized) {
            FB.Init(FBInizialize);
        }
        musicButtonSpriteInactive = musicButton.GetComponent<Image>().sprite;
        fxButtonSpriteInactive = fxButton.GetComponent<Image>().sprite;
        gameManager.ButtonMusicEvent += OnMusicPlay;
        gameManager.ButtonFxEvent += OnFxPlay;
    }

    private void OnFxPlay(object sender, bool isPlaying)
    {
        fxButton.GetComponent<Image>().sprite = isPlaying ? fxButtonSpriteActive : fxButtonSpriteInactive;
    }

    private void OnMusicPlay(object sender, bool isPlaying)
    {
        musicButton.GetComponent<Image>().sprite = isPlaying ? musicButtonSpriteActive : musicButtonSpriteInactive;
    }

    private void FBInizialize()
    {
        Debug.LogFormat("FB Init complete");
    }

    public void OnShareClick() {
       FB.ShareLink(new Uri("https://www.youtube.com/watch?v=H3U2QAy1h-k"), "This game is awesome!", "WHAC-A-TRUMP!", new Uri("http://gametest.dk/filer/logo.png"));
    }

    public void OnMusicClick() {
        gameManager.MusicChanged();
    }

    public void OnFXClick() {
        gameManager.FXChanged();
    }

    public void OnPlayClick() {
        SceneManager.LoadScene(1);
    }
}
