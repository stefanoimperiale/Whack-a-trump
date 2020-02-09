using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GameManagerTrump : MonoBehaviour
{
    public delegate void ButtonPlayEventHandler(object sender, bool isActive);
    public event ButtonPlayEventHandler ButtonMusicEvent;
    public event ButtonPlayEventHandler ButtonFxEvent;
    protected virtual void OnMusicPlay(bool isActive) {
        if (isActive && !gameMusic.isPlaying)
        {
            gameMusic.Play();
        }
        else if (!isActive && gameMusic.isPlaying){
            gameMusic.Stop();
        }
        ButtonMusicEvent?.Invoke(this, isActive);
    }
    protected virtual void OnFXPlay(bool isActive)
    {
        ButtonFxEvent?.Invoke(this, isActive);
    }

    private bool _isMusicPlay;
    public bool IsMusicPlay {
        get { return _isMusicPlay; }
        private set { _isMusicPlay = value; PlayerPreferences.SetBool(MUSIC_KEY, _isMusicPlay); OnMusicPlay(_isMusicPlay); }
    }



    private bool _isFxPlay;
    public bool IsFxPlay {
        get { return _isFxPlay; }
        private set { _isFxPlay = value; PlayerPreferences.SetBool(FX_KEY, _isFxPlay); OnFXPlay(_isFxPlay); }
    }


    private const string MUSIC_KEY = "MUSIC";
    private const string FX_KEY = "FX";

    private AudioSource gameMusic;


    void Start()
    {
        gameMusic = GetComponent<AudioSource>();
        LoadPreferences();
    }

    private void LoadPreferences() {
        IsMusicPlay = PlayerPreferences.GetBool(MUSIC_KEY);

        IsFxPlay = PlayerPreferences.GetBool(FX_KEY);
    }

    public void MusicChanged() {
        IsMusicPlay = !IsMusicPlay;
    }

    public void FXChanged()
    {
        IsFxPlay = !IsFxPlay;
    }

    internal void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
