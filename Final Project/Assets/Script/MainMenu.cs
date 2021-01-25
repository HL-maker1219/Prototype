using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private AudioSource _menuAudio;
    public AudioClip menuAudio;

    void Start()
    {
        _menuAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        _menuAudio.PlayOneShot(menuAudio);
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
