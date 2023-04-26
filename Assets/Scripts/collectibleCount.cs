using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collectibleCount : MonoBehaviour
{
    TMPro.TMP_Text text;
    int count;
    private int totalCollectibles;
    private bool hasWon = false;

    private void Awake()
    {

        text = GetComponent<TMPro.TMP_Text>();
        totalCollectibles = FindObjectsOfType<Collectible>().Length;
    }

    void start() => UpdateCount();

    void OnEnable() => Collectible.OnCollected += OnCollectibleCollected;
    void OnDisable() => Collectible.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        count++;
        UpdateCount();

        if (count == totalCollectibles && !hasWon)
        {
            hasWon = true;
            Debug.Log("You have collected all the collectibles!");
            SceneManager.LoadScene(2);
        }
    }
    void UpdateCount()
    {
        text.text = $"{count}/{Collectible.total}";
    }
}
