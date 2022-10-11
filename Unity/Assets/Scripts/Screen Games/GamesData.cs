using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Data", menuName ="New Game", order = 0)]
public class GamesData : ScriptableObject
{
    [SerializeField] private Sprite gameSprite;
    [SerializeField] private string gameName;
    [SerializeField] private string sceneName;

    public Sprite GameSprite { get => gameSprite; set => gameSprite = value; }
    public string GameName { get => gameName; set => gameName = value; }
    public string SceneName { get => sceneName; set => sceneName = value; }
}

