using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class MenuManager : MonoBehaviour

{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject settingsBackground;
    [SerializeField] private AnimationClip settingsOpen;
    [SerializeField] private AnimationClip settingsClose;
    [SerializeField] private Animation settingsAnimation;

    [SerializeField] private GameObject helpPanel;
    [SerializeField] private AnimationClip helpOpen;
    [SerializeField] private AnimationClip helpClose;
    [SerializeField] private Animation helpAnimation;

    [SerializeField] private GameObject infoPanel;
    [SerializeField] private AnimationClip infoOpen;
    [SerializeField] private AnimationClip infoClose;
    [SerializeField] private Animation infoAnimation;

    [SerializeField] private GameObject profilePanel;
    [SerializeField] private AnimationClip profileOpen;
    [SerializeField] private AnimationClip profileClose;
    [SerializeField] private Animation profileAnimation;

    [SerializeField] private GameObject captchaPanel;
    [SerializeField] private AnimationClip captchaOpen;
    [SerializeField] private AnimationClip captchaClose;
    [SerializeField] private Animation captchaAnimation;

    [SerializeField] private InputField inputCaptcha;
    [SerializeField] private Text textCaptcha;
    [SerializeField] private GameObject buttonCaptchaToSettings;
    [SerializeField] private GameObject buttonCaptchaToBlock;
    [SerializeField] private GameObject buttonCaptchaToProfiles;

    [SerializeField] private Texture2D imageToShare;

    private int userSolution;

    public void Start()
    {
        userSolution = 0;
     
        //Importante poner las animaciones como legacy desde el modo debug del inspector
        settingsAnimation = settingsPanel.AddComponent<Animation>();
        settingsAnimation.AddClip(settingsOpen, "Open Settings");
        settingsAnimation.AddClip(settingsClose, "Close Settings");

        helpAnimation = helpPanel.AddComponent<Animation>();
        helpAnimation.AddClip(helpClose, "Close Help");
        helpAnimation.AddClip(helpOpen, "Open Help");

        infoAnimation = infoPanel.AddComponent<Animation>();
        infoAnimation.AddClip(infoClose, "Close Info");
        infoAnimation.AddClip(infoOpen, "Open Info");

        profileAnimation = profilePanel.AddComponent<Animation>();
        profileAnimation.AddClip(profileClose, "Close Profile");
        profileAnimation.AddClip(profileOpen, "Open Profile");

        captchaAnimation = captchaPanel.AddComponent<Animation>();
        captchaAnimation.AddClip(captchaClose, "Close Captcha");
        captchaAnimation.AddClip(captchaOpen, "Open Captcha");

    }

    public void CaptchaCloseSettings()
    {
        captchaAnimation.GetComponent<Animation>().Play("Close Captcha");
        if (Captcha.GetSolution() == userSolution)
        {
            Settings();
        }
        inputCaptcha.text = "";
    }    
    
    public void CaptchaCloseProfiles()
    {
        captchaAnimation.GetComponent<Animation>().Play("Close Captcha");
        if (Captcha.GetSolution() == userSolution)
        {
            Profile();
        }
        inputCaptcha.text = "";
    }

    public void CaptchaCloseBlock()
    {
        captchaAnimation.GetComponent<Animation>().Play("Close Captcha");
        if (Captcha.GetSolution() == userSolution)
        {
            Block();
        }
        inputCaptcha.text = "";
    }

    public void CaptchaOpen()
    {
        GameObject selectedGO = EventSystem.current.currentSelectedGameObject;

        ShowPanel(captchaPanel);
        captchaAnimation.GetComponent<Animation>().Play("Open Captcha");
        textCaptcha.text = Captcha.CreateCaptcha();

        // Según la opción a la que se quiere acceder se activa un botón que te lleva a ella
        if (selectedGO.name == "Block")
        {
            buttonCaptchaToBlock.SetActive(true);
            buttonCaptchaToSettings.SetActive(false);
            buttonCaptchaToProfiles.SetActive(false);
        }
        else if (selectedGO.name == "Settings")
        {
            buttonCaptchaToBlock.SetActive(false);
            buttonCaptchaToSettings.SetActive(true);
            buttonCaptchaToProfiles.SetActive(false);
        }
        else if (selectedGO.name == "Profiles")
        {
            buttonCaptchaToBlock.SetActive(false);
            buttonCaptchaToSettings.SetActive(false);
            buttonCaptchaToProfiles.SetActive(true);
        }
    }

    public void GetUserSolution()
    {
        if (inputCaptcha.text != "")
        {
            userSolution = int.Parse(inputCaptcha.text);
        }
        else
        {
            userSolution = 0;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("GamesScene");
        Debug.Log("funciona por dios");
        
    }

    public void Block()
    {
        SceneManager.LoadScene("BlockGamesScene");
    }

    public void Settings()
    {
        ShowPanel(settingsPanel);
        settingsAnimation.GetComponent<Animation>().Play("Open Settings");
 
    }
    public void SettingsClose()
    {
        settingsAnimation.GetComponent<Animation>().Play("Close Settings");

    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Cerramos aplicacion");
    }

    public void ShareApp()
    {
        Debug.Log("Compartimos nuestra precios app");
        StartCoroutine(TakeScreenshotAndShare());
    }

    public void InfoOpen()
    {
        ShowPanel(infoPanel);
        infoAnimation.GetComponent<Animation>().Play("Open Info");

    }

    public void InfoClose()
    {
        infoAnimation.GetComponent<Animation>().Play("Close Info");

    }

    public void Help()
    {
        ShowPanel(helpPanel);
        helpAnimation.GetComponent<Animation>().Play("Open Help");

    }

    public void HelpClose()
    {
        helpAnimation.GetComponent<Animation>().Play("Close Help");

    }

    public void Profile()
    {
        ShowPanel(profilePanel);
        profileAnimation.GetComponent<Animation>().Play("Open Profile");
    }

    public void ProfileClose()
    {
        profileAnimation.GetComponent<Animation>().Play("Close Profile");
    }

    //Colocamos de nuevo el panel en el punto (0,0) para que sea visible y se pueda interactuar con él.
    public void ShowPanel(GameObject panel)
    {
        RectTransform panelRectTransform = panel.GetComponent<RectTransform>();

        float panelX = 0f;
        float panelY = 0f;

        panelRectTransform.anchoredPosition = new Vector2(panelX, panelY);
    }

    // Corrutina para iniciar el proceso de compartir la app
    private IEnumerator TakeScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, imageToShare.EncodeToPNG());

        // To avoid memory leaks
        //Destroy(ss);

        new NativeShare().AddFile(filePath)
            .SetText("La mejor App para los más pequeños!")
            .SetUrl("https://play.google.com/store/apps/details?id=com.hakgames.smartkids&gl=ES")
            .Share();

    }

}