using System;
using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public string playerName;
    public DiceRoll diceRoll;
    public BoardGrid board;
    public int storePlayerIndex = 1;
    public float moveSpeed = 4f;
    private int currentTileIndex = 0;

    private void Awake()
    {
        diceRoll = FindObjectOfType<DiceRoll>();
        board = FindObjectOfType<BoardGrid>();
    }

    public void MoveSteps(int steps)
    {
        StartCoroutine(MoveAlongPath(steps));
    }

    IEnumerator MoveAlongPath(int steps)
    {
        while (steps > 0 && currentTileIndex + 1 < board.pathTiles.Count && storePlayerIndex + steps <= board.pathTiles.Count)
        {
            //storePlayerIndex = storePlayerIndex + steps;
            currentTileIndex++;
            Vector3 nextPos = board.pathTiles[currentTileIndex].position;

            while (Vector3.Distance(transform.position, nextPos) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextPos, moveSpeed * Time.deltaTime);
                yield return null;
            }

            transform.position = nextPos;
            steps--;
            yield return new WaitForSeconds(0.1f); // Optional: delay between tile moves
            storePlayerIndex = currentTileIndex + 1;
        }

        CheckPlayerIndex();
    }

    void CheckPlayerIndex()
    {
        switch(storePlayerIndex)
        {
            case 4:
                StartCoroutine(PlayerSnakeLadderLerp(56));
                SoundController.instance.PlayLadderSound();
                break;

            case 12 :
                StartCoroutine(PlayerSnakeLadderLerp(50));
                SoundController.instance.PlayLadderSound();
                break;

            case 14 :
                StartCoroutine(PlayerSnakeLadderLerp(55));
                SoundController.instance.PlayLadderSound();
                break;

            case 22:
                StartCoroutine(PlayerSnakeLadderLerp(58));
                SoundController.instance.PlayLadderSound();
                break;

            case 28:
                StartCoroutine(PlayerSnakeLadderLerp(10));
                SoundController.instance.PlaySnakeSound();
                break;

            case 37:
                StartCoroutine(PlayerSnakeLadderLerp(3));
                SoundController.instance.PlaySnakeSound();
                break;

            case 41:
                StartCoroutine(PlayerSnakeLadderLerp(79));
                SoundController.instance.PlayLadderSound();
                break;

            case 48:
                StartCoroutine(PlayerSnakeLadderLerp(16));
                SoundController.instance.PlaySnakeSound();
                break;

            case 54:
                StartCoroutine(PlayerSnakeLadderLerp(88));
                SoundController.instance.PlayLadderSound();
                break;

            case 75:
                StartCoroutine(PlayerSnakeLadderLerp(32));
                SoundController.instance.PlaySnakeSound();
                break;

            case 94:
                StartCoroutine(PlayerSnakeLadderLerp(71));
                SoundController.instance.PlaySnakeSound();
                break;

            case 96:
                StartCoroutine(PlayerSnakeLadderLerp(42));
                SoundController.instance.PlaySnakeSound();
                break;

            case 100:
                StartCoroutine(GameFinished());
                SoundController.instance.PlayFinishSound();
                break;
        }

        diceRoll.rollDiceButton.interactable = true;
    }

    IEnumerator PlayerSnakeLadderLerp(int transformToIndex)
    {
        currentTileIndex = transformToIndex -1;
        storePlayerIndex = currentTileIndex + 1;
        Vector3 nextLerpPos = board.pathTiles[currentTileIndex].position;

        while (Vector3.Distance(transform.position, nextLerpPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextLerpPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = nextLerpPos;
        yield return new WaitForSeconds(0.1f);
        diceRoll.rollDiceButton.interactable = true;
    }

    IEnumerator GameFinished()
    {
        GameController.instance.PlayerWon(playerName);
        for (int i = 0; i < diceRoll.player.Length; i++)
        {
            diceRoll.player[i].gameObject.SetActive(false);
        }
        diceRoll.rollDiceButton.gameObject.SetActive(false);
        Debug.Log("Congratulation");
        yield return null;
    }
}
