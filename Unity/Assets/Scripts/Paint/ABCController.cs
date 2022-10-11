using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ABCController : MonoBehaviour
{

    [SerializeField] private GameObject lettersPanel;
    [SerializeField] private AnimationClip lettersOpen;
    [SerializeField] private AnimationClip lettersClose;
    [SerializeField] private Animation lettersAnimation;

    [SerializeField] private Text letter;

    private bool lettersSelection;
    // Start is called before the first frame update
    void Start()
    {
        lettersAnimation = lettersPanel.AddComponent<Animation>();
        lettersAnimation.AddClip(lettersClose, "Close Letters");
        lettersAnimation.AddClip(lettersOpen, "Open Letters");

        lettersSelection = false;
    }

    public int ActualLetter(string letter)
    {
        int unicodeLetter = 0;

        foreach(char c in letter)
        {
            unicodeLetter = (int)c;
        }
        Debug.Log("actual unicode letter: " + unicodeLetter);

        return unicodeLetter;
    }

    public void Next()
    {
        Clear();

        string strLetter = letter.text;
        int actualtUnicodeLetter = ActualLetter(strLetter);
        int nextUnicodeLetter = actualtUnicodeLetter + 1;

        // Añadir letra Ñ 209

        if (actualtUnicodeLetter == 78)
        {
            nextUnicodeLetter = 209;
        } else if ( actualtUnicodeLetter == 209)
        {
            nextUnicodeLetter = 79;
        }else if (actualtUnicodeLetter == 90 )
        {
            nextUnicodeLetter = 65;
        }

        char c = (char)nextUnicodeLetter;
        string nextLetter = c.ToString();

        letter.text = nextLetter;
    }

    public void Previous()
    {
        Clear();
        string strLetter = letter.text;

        int actualtUnicodeLetter = ActualLetter(strLetter);

        int previousUnicodeLetter = actualtUnicodeLetter - 1;

        // Añadir letra Ñ 209

        if (actualtUnicodeLetter == 79)
        {
            previousUnicodeLetter = 209;
        }
        else if (actualtUnicodeLetter == 209)
        {
            previousUnicodeLetter = 78;
        }else if (actualtUnicodeLetter == 65)
        {
            previousUnicodeLetter = 90;
        }

        char c = (char)previousUnicodeLetter;
        string previousLetter = c.ToString();

        letter.text = previousLetter;
    }

    public void Clear()
    {
        GameObject[] brushes = GameObject.FindGameObjectsWithTag("brush");
        foreach (GameObject brush in brushes)
        {
            Destroy(brush);
        }
    }

    public void SetLetter()
    {
        GameObject selectedGO = EventSystem.current.currentSelectedGameObject;
        string selectedLetter = selectedGO.name;

        letter.text = selectedLetter;
        Debug.Log("letra seleccionada: " + letter);
    }

    public void Back()
    {
        SceneManager.LoadScene("GamesScene");
    }

    private void LettersOpen()
    {
        ShowPanel(lettersPanel);
        lettersAnimation.GetComponent<Animation>().Play("Open Letters");

    }

    private void LettersClose()
    {
        lettersAnimation.GetComponent<Animation>().Play("Close Letters");

    }

    public void AnimLetters()
    {
        Clear();
        if (lettersSelection)
        {
            LettersClose();
            lettersSelection = false;
        }
        else
        {
            LettersOpen();
            lettersSelection = true;
        }
    }

    public void ShowPanel(GameObject panel)
    {
        RectTransform panelRectTransform = panel.GetComponent<RectTransform>();

        float panelX = 0f;
        float panelY = 0f;

        panelRectTransform.anchoredPosition = new Vector2(panelX, panelY);
    }
}
