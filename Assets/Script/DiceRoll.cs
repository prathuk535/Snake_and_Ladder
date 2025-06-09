using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour
{
    public bool playWithComputer = false;
    public PlayerMover[] player;
    public Sprite[] diceFaces; // Assign 6 sprites in Inspector
    public float rollDuration = 1.0f; // How long the dice rolls
    public SpriteRenderer diceRenderer;
    public Button rollDiceButton;
    public AudioSource audio;

    public int currentPlayerIndex = 0;

    void Start()
    {
        diceRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        for (int i = 0; i < player.Length; i++)
        {
            player[i] = FindAnyObjectByType<PlayerMover>();
        }
    }

    public void PlayWithComputerStatus(bool isPlayingWithComputer)
    {
        playWithComputer = isPlayingWithComputer;
    }

    public void RollDice()
    {
        SoundController.instance.PlayDiceSound();
        StartCoroutine(RollAnimation());
    }

    IEnumerator RollAnimation()
    {
        rollDiceButton.interactable = false;
        float timer = 0f;
        while (timer < rollDuration)
        {
            int index = Random.Range(0, diceFaces.Length);
            diceRenderer.sprite = diceFaces[index];
            timer += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        // Final result
        int finalIndex = Random.Range(0, diceFaces.Length);
        diceRenderer.sprite = diceFaces[finalIndex];
        player[currentPlayerIndex].MoveSteps(finalIndex +1);
        currentPlayerIndex = (currentPlayerIndex + 1) % player.Length;
    }
}
