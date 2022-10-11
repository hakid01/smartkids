using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadImage : MonoBehaviour
{
    [SerializeField] private GamesData game;
    private Image gameSprite;

    private void Start()
    {
        gameSprite = gameObject.GetComponent<Image>();
         gameSprite.sprite = game.GameSprite;
    }

    public void SetGameData(GamesData gameData)
    {
        game = gameData;
    }
}