using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;
    public Button[] uiButtons;
    public AudioClip button, dice, snake, ladder, start, congratulation;

    private void Awake()
    {
        instance = this;
        PlayStartSound();
    }

    private void OnEnable()
    {
        for (int i = 0; i < uiButtons.Length; i++)
        {
            uiButtons[i].onClick.AddListener(UIButtonSound);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < uiButtons.Length; i++)
        {
            uiButtons[i].onClick.RemoveListener(UIButtonSound);
        }
    }

    public void UIButtonSound()
    {
        gameObject.GetComponent<AudioSource>().clip = button;
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void PlayDiceSound()
    {
        gameObject.GetComponent<AudioSource>().clip = dice;
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void PlaySnakeSound()
    {
        gameObject.GetComponent<AudioSource>().clip = snake;
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void PlayLadderSound()
    {
        gameObject.GetComponent<AudioSource>().clip = ladder;
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void PlayStartSound()
    {
        gameObject.GetComponent<AudioSource>().clip = start;
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void PlayFinishSound()
    {
        gameObject.GetComponent<AudioSource>().clip = congratulation;
        gameObject.GetComponent<AudioSource>().Play();
    }

}
