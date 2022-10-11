using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorController : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("GamesScene");
    }
}
