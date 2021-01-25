using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private AudioSource _menuAudio;
    public AudioClip menuAudio;
    public AudioClip introAudio;

    void Start()
    {
        _menuAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        _menuAudio.PlayOneShot(menuAudio, 20f);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
