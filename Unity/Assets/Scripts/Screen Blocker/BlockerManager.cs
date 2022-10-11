using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlockerManager : MonoBehaviour
{
    private string DEFAULT_AVATAR;
    [SerializeField] private GameObject gamePrefab;
    [SerializeField] private GameObject gamesPanel;

    private Object[] gamesObj;
    private GameObject[] newGames;
    private GameObject[] newGamesImage;

    private GamesData[] games;
    private Button[] buttonsGames;
    private List<string> blockedGames = new List<string>();

    private void Start()
    {
        gamesObj = Resources.LoadAll("ScriptableObjects");
        newGames = new GameObject[gamesObj.Length];
        newGamesImage = new GameObject[gamesObj.Length];

        buttonsGames = new Button[gamesObj.Length];
        games = new GamesData[gamesObj.Length];

        // Instanciamos todos los juegos disponibles
        for( int i = 0; i< gamesObj.Length; i++)
        {

            newGames[i] = Instantiate(gamePrefab);
            buttonsGames[i] = newGames[i].GetComponent<Button>();
            games[i] = (GamesData)gamesObj[i];

            newGames[i].name = games[i].GameName;

            newGamesImage[i] = newGames[i].transform.GetChild(0).gameObject;

            newGamesImage[i].GetComponent<Image>().sprite = games[i].GameSprite;

            newGames[i].transform.SetParent(gamesPanel.transform);

        }

        // Juegos bloqueados más oscuros
        Profiles profiles = DataManager.LoadData(DEFAULT_AVATAR);
        foreach (Profile p in profiles.GameProfiles)
        {
            if (p.IsSelected)
            {
                for (int x = 0; x < p.BlockedGames.Length; x++)
                {
                    blockedGames.Add(p.BlockedGames[x]);
                    for(int y = 0; y< newGames.Length; y++)
                    {
                        if(p.BlockedGames[x] == newGames[y].name)
                        {
                            newGamesImage[y].GetComponent<Image>().color = Color.grey;
                        }
                    }
                    
                }
            }
        }

        for (int i = 0; i<buttonsGames.Length; i++)
        {
            buttonsGames[i].onClick.AddListener(blockGame);
            
        }

        //Posible mejora.Calcular altura ocupada por juegos y compararla con la altura del MaskPanel para hacer más grande el GamesPanel y poder hacer scroll

    }

    public void blockGame()
    {
        GameObject selectedGO = EventSystem.current.currentSelectedGameObject;

        for (int i = 0; i<buttonsGames.Length; i++)
        {
            if (selectedGO.name.Equals(newGames[i].name))
            {
                if(newGamesImage[i].GetComponent<Image>().color == Color.grey)
                {
                    blockedGames.Remove(selectedGO.name);
                    newGamesImage[i].GetComponent<Image>().color = Color.white;
                }
                else
                {
                    blockedGames.Add(selectedGO.name);
                    newGamesImage[i].GetComponent<Image>().color = Color.grey;
                }
            }
        }

    }

    public void BlockAll()
    {
        for (int i = 0; i < buttonsGames.Length; i++)
        { 
            if (newGamesImage[i].GetComponent<Image>().color != Color.grey)
            {
                blockedGames.Add(newGames[i].name);
                newGamesImage[i].GetComponent<Image>().color = Color.grey;
            } 
        }
    }

    public void UnBlockAll()
    {
        for (int i = 0; i < buttonsGames.Length; i++)
        {
            if (newGamesImage[i].GetComponent<Image>().color == Color.grey)
            {
                blockedGames.Remove(newGames[i].name);
                newGamesImage[i].GetComponent<Image>().color = Color.white;
            }
        }
    }

    public void Back()
    {
        Profiles profiles = DataManager.LoadData(DEFAULT_AVATAR);
        foreach(Profile p in profiles.GameProfiles)
        {
            if (p.IsSelected)
            {
                p.BlockedGames = blockedGames.ToArray();
            }
        }

        DataManager.SaveData(profiles);
         
        SceneManager.LoadScene("MainMenuScene");
    }
}
