using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoardGrid : MonoBehaviour
{
    public GameObject tilePrefab;
    public Transform boardParent;
    public int rows = 10;
    public int cols = 10;

    public List<Transform> pathTiles = new List<Transform>();

    void Start()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {
        bool reverse = false;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                int actualX = reverse ? cols - 1 - x : x;
                int index = y * cols + actualX;

                GameObject tile = Instantiate(tilePrefab, boardParent);
                tile.name = $"Tile {index + 1}";

                // Set text number (optional)
                TextMeshProUGUI numberText = tile.GetComponentInChildren<TextMeshProUGUI>();
                if (numberText != null)
                    numberText.text = (index + 1).ToString();

                pathTiles.Add(tile.transform);
            }

            reverse = !reverse;
        }

        pathTiles.Sort((a, b) =>
        {
            int aNum = int.Parse(a.name.Split(' ')[1]);
            int bNum = int.Parse(b.name.Split(' ')[1]);
            return aNum.CompareTo(bNum);
        });
    }
}
