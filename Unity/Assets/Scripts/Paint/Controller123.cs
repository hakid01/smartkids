using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Controller123 : MonoBehaviour
{

    [SerializeField] private GameObject numbersPanel;
    [SerializeField] private AnimationClip numbersOpen;
    [SerializeField] private AnimationClip numbersClose;
    [SerializeField] private Animation numbersAnimation;

    [SerializeField] private Text number;

    private bool numbersSelection;
    // Start is called before the first frame update
    void Start()
    {
        numbersAnimation = numbersPanel.AddComponent<Animation>();
        numbersAnimation.AddClip(numbersClose, "Close Numbers");
        numbersAnimation.AddClip(numbersOpen, "Open Numbers");

        numbersSelection = false;
    }

    public void Next()
    {
        Clear();

        string strNumber = number.text;

        int actualNumber = Convert.ToInt32(strNumber);

        int nextNumber;

        if (actualNumber == 9)
        {
            nextNumber = 0;
        }
        else
        {
            nextNumber = actualNumber + 1;
        }

        strNumber = nextNumber.ToString();

        number.text = strNumber;
    }

    public void Previous()
    {
        Clear();
        string strNumber = number.text;

        int actualNumber = Convert.ToInt32(strNumber);

        int previousNumber;

        if (actualNumber == 0)
        {
            previousNumber = 9;
        }
        else
        {
            previousNumber = actualNumber - 1;
        }

        strNumber = previousNumber.ToString();

        number.text = strNumber;
    }

    public void Clear()
    {
        GameObject[] brushes = GameObject.FindGameObjectsWithTag("brush");
        foreach (GameObject brush in brushes)
        {
            Destroy(brush);
        }
    }

    public void SetNumber()
    {
        GameObject selectedGO = EventSystem.current.currentSelectedGameObject;
        string selectedNumber = selectedGO.name;

        number.text = selectedNumber;
        Debug.Log("numero seleccionado: " + number);
    }

    public void Back()
    {
        SceneManager.LoadScene("GamesScene");
    }

    private void NumbersOpen()
    {
        ShowPanel(numbersPanel);
        numbersAnimation.GetComponent<Animation>().Play("Open Numbers");

    }

    private void NumbersClose()
    {
        numbersAnimation.GetComponent<Animation>().Play("Close Numbers");

    }

    public void AnimNumbers()
    {
        Clear();
        if (numbersSelection)
        {
            NumbersClose();
            numbersSelection = false;
        }
        else
        {
            NumbersOpen();
            numbersSelection = true;
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
