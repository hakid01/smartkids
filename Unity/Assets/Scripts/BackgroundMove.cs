using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMove : MonoBehaviour
{
    public float x;
    public float y;
    private float actualX;
    private float actualY;
    
    RawImage bg;

    private void Awake()
    {
        actualX = 0f;
        actualY = 0f;
        bg = gameObject.GetComponent<RawImage>();

    }

    void Update()
    {
        //Rect bgRect = bg.GetComponent<Rect>();

        
        bg.uvRect = new Rect (actualX + x, actualY + y, bg.uvRect.width, bg.uvRect.height);
        actualX += x * Time.deltaTime;
        actualY += y * Time.deltaTime;

    }
}
