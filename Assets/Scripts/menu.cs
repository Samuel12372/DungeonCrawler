using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;  

public class menu : MonoBehaviour
{
    public GameObject music;
    public AudioMixerSnapshot defaultSnapshot; // Reference to your default snapshot
    public AudioMixerSnapshot sceneSnapshot;
    void Start()
    {
        DontDestroyOnLoad(music);
        defaultSnapshot.TransitionTo(0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene(string sceneName)
    {
        sceneSnapshot.TransitionTo(1.0f); 
        SceneManager.LoadScene(sceneName);
    } 
    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
