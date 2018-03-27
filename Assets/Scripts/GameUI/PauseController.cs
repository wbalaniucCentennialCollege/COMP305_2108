using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseController : MonoBehaviour {

    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;

    private Canvas canvas;

    private void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}

    public void Pause()
    {
        canvas.enabled = !canvas.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0; // Ternery statement. Checks if timescale is set to 0. Basically invert between 0 and 1.
        PlayAudio();
    }

    public void QuitBtnPress()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void PlayAudio()
    {
        if(Time.timeScale == 0)
        {
            paused.TransitionTo(.01f);
        } 
        else
        {
            unpaused.TransitionTo(.01f);
        }
    }
}
