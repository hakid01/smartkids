using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMe : MonoBehaviour
{
    // Script para mover el objeto fuera de cámara y cargarlo una vez para que quede en memoria y las siguientes animaciones se vean fluidas
    RectTransform panelRectTransform;
    float panelX;
    float panelY;
    Vector2 hidePosition;

    public void Start()
    {
        panelX = -2000f;
        panelY = 0f;

        hidePosition = new Vector2(panelX, panelY);

        panelRectTransform = gameObject.GetComponent<RectTransform>();

        HidePanel();
    }

    private void HidePanel()
    {
        gameObject.SetActive(false);
        panelRectTransform.anchoredPosition = hidePosition;
        gameObject.SetActive(true);

    }
}
