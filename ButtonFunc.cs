using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunc : MonoBehaviour
{
    public GameObject fx;
    public GameObject music;

    public Sprite FX;
    public Sprite NoFX;
    public Sprite Music;
    public Sprite NoMusic;

    public bool isFX = true;
    public bool isMusic = true;

    private void Start()
    {
        PlayerPrefs.SetInt("isFirst", PlayerPrefs.GetInt("isFirst") + 1);
        if (PlayerPrefs.GetInt("isFirst") == 1)
        {
            PlayerPrefs.SetInt("FX", 1);
            PlayerPrefs.SetInt("Music", 1);
        }
        if (fx != null && music != null)
        {
            if (PlayerPrefs.GetInt("FX") == 0)
                isFX = false;
            else
                isFX = true;
            if (PlayerPrefs.GetInt("Music") == 0)
                isMusic = false;
            else
                isMusic = true;

            if (!isFX)
            {
                fx.GetComponent<Image>().sprite = NoFX;
            }
            if (!isMusic)
            {
                music.GetComponent<Image>().sprite = NoMusic;
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Next()
    {
        if(SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
        {
            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Load(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void togglefx()
    {
        if(isFX)
        {
            fx.GetComponent<Image>().sprite = NoFX;
            PlayerPrefs.SetInt("FX", 0);
        }
        else
        {
            fx.GetComponent<Image>().sprite = FX;
            PlayerPrefs.SetInt("FX", 1);
        }
        isFX = !isFX;
    }

    public void togglemusic()
    {
        if (isMusic)
        {
            music.GetComponent<Image>().sprite = NoMusic;
            PlayerPrefs.SetInt("Music", 0);
        }
        else
        {
            music.GetComponent<Image>().sprite = Music;
            PlayerPrefs.SetInt("Music", 1);
        }
        isMusic = !isMusic;
    }
}
