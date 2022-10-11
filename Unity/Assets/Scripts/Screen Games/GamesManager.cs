using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;

public class GamesManager : MonoBehaviour
{

    private string DEFAULT_AVATAR;
    [SerializeField] private GameObject gamePrefab;
    [SerializeField] private GameObject gamesPanel;

    private Object[] gamesObj;
    private GameObject[] newGames;
    private GameObject[] newGamesImage;

    private GamesData[] games;
    private Button[] buttonsGames;
    private string[] blockedGames;
    private Profile selectedProfile;

    private void Start()
    {
        // Cargamos los datos del perfil seleccionado

        Profiles profiles = DataManager.LoadData(DEFAULT_AVATAR);
        foreach (Profile p in profiles.GameProfiles)
        {
            if (p.IsSelected)
            {
                selectedProfile = p;
            }
        }

        blockedGames = selectedProfile.BlockedGames;

        gamesObj = Resources.LoadAll("ScriptableObjects");
        newGames = new GameObject[gamesObj.Length];
        newGamesImage = new GameObject[gamesObj.Length];

        buttonsGames = new Button[gamesObj.Length];
        games = new GamesData[gamesObj.Length];

        for (int i = 0; i < gamesObj.Length; i++)
        {

            newGames[i] = Instantiate(gamePrefab);
            buttonsGames[i] = newGames[i].GetComponent<Button>();
            games[i] = (GamesData)gamesObj[i];

            if (!blockedGames.Contains(games[i].GameName))
            {
                newGames[i].name = games[i].GameName;

                newGamesImage[i] = newGames[i].transform.GetChild(0).gameObject;

                newGamesImage[i].GetComponent<Image>().sprite = games[i].GameSprite;

                newGames[i].transform.SetParent(gamesPanel.transform);
            }
        }

        for (int i = 0; i < buttonsGames.Length; i++)
        {
            buttonsGames[i].onClick.AddListener(LoadGame);

        }
    }

    public void ShowPanel(GameObject panel)
    {
        RectTransform panelRectTransform = panel.GetComponent<RectTransform>();

        float panelX = 0f;
        float panelY = 0f;

        panelRectTransform.anchoredPosition = new Vector2(panelX, panelY);
    }

    // Cargamos los juegos que no están en la lista de bloqueados
    public void LoadGame()
    {
        GameObject selectedGO = EventSystem.current.currentSelectedGameObject;

        for (int i = 0; i < buttonsGames.Length; i++)
        {
            if (selectedGO.name.Equals(newGames[i].name))
            {
                SceneManager.LoadScene(games[i].SceneName);
            }
        }
    }
    
    public void Back()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
