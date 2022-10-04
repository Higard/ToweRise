using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CanvasButtons : MonoBehaviour
{
    public Sprite MusOn, MusOff;

    public void Start()
    {
        if (PlayerPrefs.GetString("music") == "No" && gameObject.name == "SoundButton")
            GetComponent<Image>().sprite = MusOff;
    }
    public void RestartGame()
    {
        if (PlayerPrefs.GetString("music") != "No")
        {
            GetComponent<AudioSource>().Play();
            StartCoroutine(RestartGameIE());
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        IEnumerator RestartGameIE()
        {
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void MusicWork()
    {
        if (PlayerPrefs.GetString("music") == "No")
        {
            PlayerPrefs.SetString("music", "Yes");
            GetComponent<AudioSource>().Play();
            GetComponent<Image>().sprite = MusOn;

        }
        else
        {
            PlayerPrefs.SetString("music", "No");
            GetComponent<Image>().sprite = MusOff;
        }
    }
}