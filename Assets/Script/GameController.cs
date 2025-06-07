using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] DiceRoll dice;
    [SerializeField] GameObject playerSelectionCanvas;
    [SerializeField] GameObject boardCanvas;
    [SerializeField] GameObject winningPanel;
    [SerializeField] PlayerMover[] playerMovers;

    private void Awake()
    {
        instance = this;
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void CloseApplication()
    {
        Application.Quit();
    }

    //Method is called when you select no of players tp be played
    public void SelectPlayers(int index)
    {
        for (int i = 0; i < index; i++)
        {
            playerMovers[i].gameObject.SetActive(true);
        }
        playerSelectionCanvas.SetActive(false);
        boardCanvas.SetActive(true);
        dice.gameObject.SetActive(true);

        dice.player = new PlayerMover[index]; // Make sure DiceRoll has a players[] array
        for (int i = 0; i < index; i++)
        {
            dice.player[i] = playerMovers[i];
        }

    }

    public void PassDiceValuesWithInPlayers()
    {
        //// Deactivate all players
        //foreach (var player in players)
        //{
        //    player.SetActive(false);
        //}

        //// Activate the current player
        //players[currentPlayerIndex].SetActive(true);
        //Debug.Log($"{players[currentPlayerIndex].name}'s turn!");

        //// Simulate dice roll
        //int roll = diceRoller.RollDice();
        //Debug.Log($"{players[currentPlayerIndex].name} rolled a {roll}");

        //// End the turn
        //EndTurn();
    }

    public void PlayerWon(string playerName)
    {
        winningPanel.SetActive(true);
        winningPanel.GetComponentInChildren<TextMeshProUGUI>().text = playerName;
    }
}
