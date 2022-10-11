using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountController : MonoBehaviour
{
    [SerializeField] private GameObject maxNumberPanel;
    [SerializeField] private AnimationClip maxNumberOpen;
    [SerializeField] private AnimationClip maxNumberClose;
    [SerializeField] private Animation maxNumberAnimation;

    [SerializeField] private GameObject panelNumber;

    [SerializeField] private GameObject parentContainers;
    [SerializeField] private GameObject containerPrefab;
    [SerializeField] private GameObject itemPrefab;

    [SerializeField] private GameObject buttonSelection;

    [SerializeField] private Sprite boy;
    [SerializeField] private Sprite girl;
    [SerializeField] private Sprite buho;
    [SerializeField] private Sprite perro;
    [SerializeField] private Sprite cerdo;
    [SerializeField] private Sprite gato;
    [SerializeField] private Sprite conejo;
    [SerializeField] private Sprite sombrero;

    private GameObject[] containers;

    private GameObject[] items;

    private int nOptions;

    private int maxNumber;

    private Sprite[] allSprites;
    private Sprite randomItem;
    private string actualNumber;
    private bool correctOption;

    // Máximo número que saldrá para adivinar
    private bool maxNumberSelection; 

    // Start is called before the first frame update
    void Start()
    {
        maxNumberSelection = false;

        maxNumberAnimation = maxNumberPanel.AddComponent<Animation>();
        maxNumberAnimation.AddClip(maxNumberClose, "Close Max Number");
        maxNumberAnimation.AddClip(maxNumberOpen, "Open Max Number");

        correctOption = false;

        allSprites = new Sprite[8];
        allSprites[0] = boy;
        allSprites[1] = girl;
        allSprites[2] = buho;
        allSprites[3] = perro;
        allSprites[4] = cerdo;
        allSprites[5] = gato;
        allSprites[6] = conejo;
        allSprites[7] = sombrero;

        containers = new GameObject[4];
        nOptions = 3;
        maxNumber = 4;
        items = new GameObject[maxNumber];

        SetRandomNumber();

        CreateItemsContainers();
    }

    private void SetRandomNumber()
    {
        actualNumber = "" + Random.Range(1, maxNumber + 1);
        panelNumber.GetComponent<Text>().text = actualNumber;
    }

    // Generamos un array que contenga numeros aleatorios que no se repitan
    private int[] RandomItems(int length, int maxValue)
    {
        int[] numeros = new int[length];
        for (int i = 0; i < length; i++)
        {
            numeros[i] = 0;
        }

        for (int i = 0; i<length; i++)
        {
            int temp = Random.Range(1, maxValue+1);
            if (i > 0)
            {
                while(Duplicate(temp, numeros))
                {
                    temp = Random.Range(0, maxValue);
                }
            }
            numeros[i] = temp;
        }

        return numeros;
    }

    private bool Duplicate(int number, int[] numbers)
    {
        foreach (var n in numbers)
        {
            if(number == n)
            {
                return true;
            }
        }
        return false;
    }

    public void CreateItemsContainers()
    {
        int[] avatarsIndex = RandomItems(nOptions, 7);
        int[] numberOfItems = RandomItems(nOptions, maxNumber);

        //Comprobamos que existe la opcion correcta en el array
        foreach (var item in numberOfItems)
        {
            if(item.ToString() == actualNumber)
            {
                Debug.Log(item.ToString());
                correctOption = true;
            }
        }
        //si no existe cambiamos un valor al azar por la opción correcta
        if (!correctOption)
        {
            int randomIndex = Random.Range(0, numberOfItems.Length);
            numberOfItems[randomIndex] = int.Parse(actualNumber);
        }

        for (int i = 0; i < nOptions; i++)
        {
            string tag = "";
            containers[i] = Instantiate(containerPrefab);
            // Asignamos un tag a los botones en funcion de si es correcto o no, para que suenen diferente
            if(numberOfItems[i] == int.Parse(actualNumber))
            {
                tag = "ok";
            }
            else
            {
                tag = "error";
            }
            containers[i].tag = tag;
            containers[i].GetComponent<Button>().onClick.AddListener(delegate
            {
                CheckNumber();
                SoundsController.PlaySound();
            });
            containers[i].transform.SetParent(parentContainers.transform);
            containers[i].transform.localScale = new Vector3(1f, 1f, 1f);
            randomItem = allSprites[avatarsIndex[i]];

            Debug.Log("number of items: " + numberOfItems[i].GetType());
            Debug.Log("number of items: " + numberOfItems[i]);

            for (int x = 0; x < numberOfItems[i]; x++)
            {
                items[x] = Instantiate(itemPrefab);
                items[x].GetComponent<Image>().sprite = randomItem;
                items[x].GetComponent<Image>().color = new Color32(249, 248, 219, 255);
                items[x].transform.SetParent(containers[i].transform);
                items[x].transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        // reseteamos valor para que en futuras veces no sea siempre verdadero
        correctOption = false;
    }

    // Comprobamos si la opcion elegida es correcta
    public void CheckNumber()
    {
        GameObject selectedGO = EventSystem.current.currentSelectedGameObject;
        int childNumber = selectedGO.transform.childCount;

        if (int.Parse(actualNumber) == childNumber)
        {
            for(int i=0; i<childNumber; i++)
            {
                selectedGO.transform.GetChild(i).GetComponent<Image>().color = Color.green;

            }
        }
        else
        {
            for (int i = 0; i < childNumber; i++)
            {
                selectedGO.transform.GetChild(i).GetComponent<Image>().color = Color.red;

            }
        }
        Debug.Log("hijos: " + childNumber);
    }

    public void Next()
    {
        // Mostramos un nuevo número
        SetRandomNumber();

        // Eliminamos los botones de respuesta anteriores
        for (int i = 0; i < parentContainers.transform.childCount; i++)
        {
            Destroy(parentContainers.transform.GetChild(i).gameObject);
        }

        // Generamos nuevos botones de respuesta
        CreateItemsContainers();
    }

    public void Back()
    {
        SceneManager.LoadScene("GamesScene");
    }

    public void MaxNumberOpen()
    {
        ShowPanel(maxNumberPanel);
        maxNumberAnimation.GetComponent<Animation>().Play("Open Max Number");
        maxNumberSelection = true;

    }

    public void MaxNumberClose()
    {
        maxNumberAnimation.GetComponent<Animation>().Play("Close Max Number");
        maxNumberSelection = false;

    }

    public void ShowPanel(GameObject panel)
    {
        RectTransform panelRectTransform = panel.GetComponent<RectTransform>();

        float panelX = 0f;
        float panelY = 0f;

        panelRectTransform.anchoredPosition = new Vector2(panelX, panelY);
    }

    public void AnimMaxNumber()
    {
        if (maxNumberSelection)
        {
            MaxNumberClose();
        }
        else
        {
            MaxNumberOpen();
        }
    }

    public void SetMaxNumber()
    {
        GameObject selectedGO = EventSystem.current.currentSelectedGameObject;

        buttonSelection.GetComponent<Image>().sprite = selectedGO.GetComponent<Image>().sprite;
        Debug.Log("max number: " + selectedGO.name);
        maxNumber = int.Parse(selectedGO.name);
        items = new GameObject[maxNumber];
        if (maxNumber == 4)
        {
            nOptions = 3;
        }
        else
        {
            nOptions = 4;
        }
    }
}
