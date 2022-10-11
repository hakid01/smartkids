using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Painter : MonoBehaviour
{
    [SerializeField] private GameObject lienzo;
    [SerializeField] private GameObject brush;

    LineRenderer currentLineRenderer;

    Touch touch;

    private Color lrColor;

    [SerializeField] private GameObject color0;
    [SerializeField] private GameObject color1;
    [SerializeField] private GameObject color2;
    [SerializeField] private GameObject color3;
    [SerializeField] private GameObject color4;
    [SerializeField] private GameObject color5;

    private GameObject[] colors = new GameObject[6];

    private void Start()
    {
        currentLineRenderer = brush.GetComponent<LineRenderer>();

        
        colors[0] = color0;
        colors[1] = color1;
        colors[2] = color2;
        colors[3] = color3;
        colors[4] = color4;
        colors[5] = color5;

        lrColor = color0.GetComponent<Image>().color;

    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            // Toque inicial sobre la pantalla
            if ( touch.phase == TouchPhase.Began)
            {

                    CreateBrush();

            }
            
            // Arrastre del dedo por la pantalla
            if(touch.phase == TouchPhase.Moved)
            {
                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                    AddPoint(touchPosition);

            }

        }
    }

    public void CreateBrush()
    {
        GameObject newBrush = Instantiate(brush);
        newBrush.SetActive(true);
        currentLineRenderer = newBrush.GetComponent<LineRenderer>();

        currentLineRenderer.transform.SetParent(lienzo.transform);

        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

        Debug.Log("lrColor: " + lrColor);

        currentLineRenderer.startColor = lrColor;
        currentLineRenderer.endColor = lrColor;

        currentLineRenderer.SetPosition(0, touchPosition);
        currentLineRenderer.SetPosition(1, touchPosition);

    }

    public void AddPoint(Vector2 pointPosition)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount -1;

        currentLineRenderer.SetPosition(positionIndex, pointPosition);

    }

    public void ChangeColor()
    {
        GameObject selectedGO = EventSystem.current.currentSelectedGameObject;

        for (int i = 0; i < colors.Length; i++)
        {
            if (selectedGO == colors[i])
            {
                lrColor = colors[i].GetComponent<Image>().color; 
            }
        }

    }

}
