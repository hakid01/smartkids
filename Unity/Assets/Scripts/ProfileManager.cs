using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    private string DEFAULT_AVATAR;

    private Color crema = new Color32(249, 248, 219, 255); // color base avatar perfil

    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private InputField inputName;
    [SerializeField] private Text nameText;

    [SerializeField] private Image goAvatarMain;
    [SerializeField] private Image goColorMain;
    [SerializeField] private Image goAvatarPopUp;
    [SerializeField] private Image goColorPopUp;

    [SerializeField] private GameObject gameObjectProfile0;
    [SerializeField] private Image imgaeAvatar0;
    [SerializeField] private GameObject gameObjectProfile1;
    [SerializeField] private Image imageAvatar1;
    [SerializeField] private GameObject gameObjectProfile2;
    [SerializeField] private Image imageAvatar2;
    [SerializeField] private GameObject gameObjectProfile3;
    [SerializeField] private Image imageAvatar3;
    [SerializeField] private GameObject gameObjectProfile4;
    [SerializeField] private Image imageAvatar4;
    [SerializeField] private GameObject gameObjectProfile5;
    [SerializeField] private Image imageAvatar5;

    private GameObject[] goButtonsProfiles = new GameObject[6];
    private Image[] avatarImages = new Image[6];

    private Profile[] gameProfiles = new Profile[6];
    private Profiles profiles;

    private Profiles backupProfiles;
    private Profile[] backupGameProfiles = new Profile[6];

    void Start()
    {

        DEFAULT_AVATAR = "boy";

        goButtonsProfiles[0] = gameObjectProfile0;
        goButtonsProfiles[1] = gameObjectProfile1;
        goButtonsProfiles[2] = gameObjectProfile2;
        goButtonsProfiles[3] = gameObjectProfile3;
        goButtonsProfiles[4] = gameObjectProfile4;
        goButtonsProfiles[5] = gameObjectProfile5;

        avatarImages[0] = imgaeAvatar0;
        avatarImages[1] = imageAvatar1;
        avatarImages[2] = imageAvatar2;
        avatarImages[3] = imageAvatar3;
        avatarImages[4] = imageAvatar4;
        avatarImages[5] = imageAvatar5;

        profiles = DataManager.LoadData(DEFAULT_AVATAR);

        backupProfiles = new Profiles();

        // Cargamos datos Json en profiles
        // Asignamos color y avatar a cada botón de perfil
        for (int i = 0; i < 6; i++)
        {
            gameProfiles[i] = profiles.GameProfiles[i];
            goButtonsProfiles[i].GetComponent<Image>().color = gameProfiles[i].Color;
            avatarImages[i].sprite = Resources.Load<Sprite>("SpriteAvatar/" + gameProfiles[i].Avatar);
            backupGameProfiles[i] = new Profile(DEFAULT_AVATAR);

        }

        backupProfiles = new Profiles(backupGameProfiles);

        SetOneProfileSelect();

    }

    private void SetOneProfileSelect()
    {
        int countIsSelected = 0;
        for (int i = 0; i < 6; i++)
        {
            if (gameProfiles[i].IsSelected == true)
            {
                avatarImages[i].color = Color.white;
                sfxSlider.value = gameProfiles[i].SfxVolume;
                musicSlider.value = gameProfiles[i].MusicVolume;
                MusicController.SetVolume(musicSlider.value);
                SoundsController.SetVolume(sfxSlider.value);

                nameText.text = gameProfiles[i].Nickname;
                //Colocar misma imagen en botones de interfaz principal
                goAvatarMain.sprite = Resources.Load<Sprite>("SpriteAvatar/" + gameProfiles[i].Avatar);
                goAvatarPopUp.sprite = Resources.Load<Sprite>("SpriteAvatar/" + gameProfiles[i].Avatar);
                goColorMain.color = gameProfiles[i].Color;
                goColorPopUp.color = gameProfiles[i].Color;
                countIsSelected++;
            }
        }

        if (countIsSelected == 1)
        {

        }
        else if (countIsSelected == 0)
        {
            gameProfiles[0].IsSelected = true;
            avatarImages[0].color = Color.white;

            //Colocar misma imagen en botones de interfaz principal
            goAvatarMain.sprite = avatarImages[0].sprite;
            goAvatarPopUp.sprite = avatarImages[0].sprite;
            goColorMain.color = goButtonsProfiles[0].GetComponent<Image>().color;
            goColorPopUp.color = goButtonsProfiles[0].GetComponent<Image>().color; //colorImages[0].color;
            sfxSlider.value = gameProfiles[0].SfxVolume;
            musicSlider.value = gameProfiles[0].MusicVolume;
        }
        else if (countIsSelected > 1)
        {
            for (int x = 0; x < 6; x++)
            {
                gameProfiles[x].IsSelected = false;
                avatarImages[x].color = crema;
            }
            gameProfiles[0].IsSelected = true;
            avatarImages[0].color = Color.white;

            //Colocar misma imagen en botones de interfaz principal
            goAvatarMain.sprite = avatarImages[0].sprite;
            goAvatarPopUp.sprite = avatarImages[0].sprite;
            goColorMain.color = goButtonsProfiles[0].GetComponent<Image>().color;
            goColorPopUp.color = goButtonsProfiles[0].GetComponent<Image>().color;
            sfxSlider.value = gameProfiles[0].SfxVolume;
            musicSlider.value = gameProfiles[0].MusicVolume;
        }

        SaveProfileData();
    }

    public void SelectProfile()
    {
        // Ponemos la propiedad IsSelected de todos los perfiles a false
        // Color por defecto de los avatares = crema
        for (int i = 0; i < 6; i++)
        {
            gameProfiles[i].IsSelected = false;
            avatarImages[i].color = crema;
        }

        GameObject selectedGO = EventSystem.current.currentSelectedGameObject;

        LoadProfile(selectedGO);

        // Ponemos la propiedad IsSelected del perfil seleccionado a true
        // Color del avatar en blanco para diferenciar de los no seleccionados
        for (int i = 0; i < 6; i++)
        {
            if (selectedGO == goButtonsProfiles[i])
            {
                gameProfiles[i].IsSelected = true;
                avatarImages[i].color = Color.white;

                //Colocar misma imagen en botones de interfaz principal
                goAvatarMain.sprite = avatarImages[i].sprite;
                goAvatarPopUp.sprite = avatarImages[i].sprite;
                goColorMain.color = goButtonsProfiles[i].GetComponent<Image>().color;
                goColorPopUp.color = goButtonsProfiles[i].GetComponent<Image>().color;
            }
        }

    }

    private void LoadProfile(GameObject profileGO)
    {
        for (int i = 0; i < 6; i++)
        {
            if (profileGO == goButtonsProfiles[i])
            {
                sfxSlider.value = gameProfiles[i].SfxVolume;
                musicSlider.value = gameProfiles[i].MusicVolume;
                MusicController.SetVolume(musicSlider.value);
                SoundsController.SetVolume(sfxSlider.value);

                nameText.text = gameProfiles[i].Nickname;
            }
        }
    }

    public void SetAvatar()
    {
        GameObject selectedGO = EventSystem.current.currentSelectedGameObject;
        Image selectedImage = selectedGO.GetComponent<Image>();

        for (int i = 0; i < 6; i++)
        {
            if (gameProfiles[i].IsSelected)
            {
                avatarImages[i].sprite = selectedImage.sprite;
                gameProfiles[i].Avatar =  selectedImage.name;
                
                //Colocar misma imagen en botones de interfaz principal
                goAvatarMain.sprite = selectedImage.sprite;
                goAvatarPopUp.sprite = selectedImage.sprite;
            }
        }
    }

    public void SetColor()
    {
        GameObject selectedGO = EventSystem.current.currentSelectedGameObject;
        Image selectedImage = selectedGO.GetComponent<Image>();

        for (int i = 0; i < 6; i++)
        {
            if (gameProfiles[i].IsSelected)
            {
                goButtonsProfiles[i].GetComponent<Image>().color = selectedImage.color;
                gameProfiles[i].Color = selectedImage.color;

                // Colocar mismo color en botones interfaz principal
                goColorMain.color = selectedImage.color;
                goColorPopUp.color = selectedImage.color;

            }
        }
    }

    public void SetNickName()
    {
        if(inputName.text != "")
        {
            string nickName;
            nickName = inputName.text = inputName.text.ToUpper();

            for (int i = 0; i < 6; i++)
            {
                if (gameProfiles[i].IsSelected)
                {
                    nameText.text = nickName;
                    gameProfiles[i].Nickname = nickName;

                }
            }
        }
    }

    public void SetMusicVolume()
    {
        for (int i = 0; i < 6; i++)
        {
            if (gameProfiles[i].IsSelected)
            {
                gameProfiles[i].MusicVolume = musicSlider.value;
                MusicController.SetVolume(musicSlider.value);
            }
        }
    }

    public void SetSfxVolume()
    {
        for (int i = 0; i < 6; i++)
        {
            if (gameProfiles[i].IsSelected)
            {
                gameProfiles[i].SfxVolume = sfxSlider.value;
                SoundsController.SetVolume(sfxSlider.value);
            }
        }
    }

    public void SaveProfileData()
    {
        DataManager.SaveData(profiles);
    }

    public void SetDefaultProfile()
    {
        for (int i = 0; i < 6; i++)
        {
            if (gameProfiles[i].IsSelected)
            {
                gameProfiles[i] = new Profile(DEFAULT_AVATAR);
                gameProfiles[i].IsSelected = true;
                profiles.GameProfiles[i] = gameProfiles[i];

                avatarImages[i].color = Color.white;
                goButtonsProfiles[i].GetComponent<Image>().color = gameProfiles[i].Color;
                avatarImages[i].sprite = Resources.Load<Sprite>("SpriteAvatar/" + gameProfiles[i].Avatar);
                sfxSlider.value = gameProfiles[i].SfxVolume;
                musicSlider.value = gameProfiles[i].MusicVolume;
                MusicController.SetVolume(musicSlider.value);
                SoundsController.SetVolume(sfxSlider.value);

                nameText.text = gameProfiles[i].Nickname;
                //Colocar misma imagen en botones de interfaz principal
                goAvatarMain.sprite = Resources.Load<Sprite>("SpriteAvatar/" + gameProfiles[i].Avatar);
                goAvatarPopUp.sprite = Resources.Load<Sprite>("SpriteAvatar/" + gameProfiles[i].Avatar);
                goColorMain.color = gameProfiles[i].Color;
                goColorPopUp.color = gameProfiles[i].Color;

            }
        }
        SaveProfileData();
    }

    public void SaveBackUp()
    {
        for (int i = 0; i < 6; i++)
        {
            backupProfiles.GameProfiles[i].Avatar = profiles.GameProfiles[i].Avatar;
            backupProfiles.GameProfiles[i].Nickname = profiles.GameProfiles[i].Nickname;
            backupProfiles.GameProfiles[i].Color = profiles.GameProfiles[i].Color;
            backupProfiles.GameProfiles[i].IsSelected = profiles.GameProfiles[i].IsSelected;
            backupProfiles.GameProfiles[i].SfxVolume = profiles.GameProfiles[i].SfxVolume;
            backupProfiles.GameProfiles[i].MusicVolume = profiles.GameProfiles[i].MusicVolume;
            backupProfiles.GameProfiles[i].BlockedGames = profiles.GameProfiles[i].BlockedGames;
        }
            Debug.Log(JsonUtility.ToJson(backupProfiles, true));
    }

    public void RestoreBackUp()
    {        
        // Asignamos color y avatar a cada botón de perfil
        for (int i = 0; i < 6; i++)
        {
            profiles.GameProfiles[i].Avatar = backupProfiles.GameProfiles[i].Avatar;
            profiles.GameProfiles[i].Nickname = backupProfiles.GameProfiles[i].Nickname;
            profiles.GameProfiles[i].Color = backupProfiles.GameProfiles[i].Color;
            profiles.GameProfiles[i].IsSelected = backupProfiles.GameProfiles[i].IsSelected;
            profiles.GameProfiles[i].SfxVolume = backupProfiles.GameProfiles[i].SfxVolume;
            profiles.GameProfiles[i].MusicVolume = backupProfiles.GameProfiles[i].MusicVolume;
            profiles.GameProfiles[i].BlockedGames = backupProfiles.GameProfiles[i].BlockedGames;

            goButtonsProfiles[i].GetComponent<Image>().color = gameProfiles[i].Color;
            avatarImages[i].sprite = Resources.Load<Sprite>("SpriteAvatar/" + gameProfiles[i].Avatar);

            if (gameProfiles[i].IsSelected)
            {
                avatarImages[i].color = Color.white;
                sfxSlider.value = gameProfiles[i].SfxVolume;
                musicSlider.value = gameProfiles[i].MusicVolume;
                MusicController.SetVolume(musicSlider.value);
                SoundsController.SetVolume(sfxSlider.value);

                nameText.text = gameProfiles[i].Nickname;
                //Colocar misma imagen en botones de interfaz principal
                goAvatarMain.sprite = Resources.Load<Sprite>("SpriteAvatar/" + gameProfiles[i].Avatar);
                goAvatarPopUp.sprite = Resources.Load<Sprite>("SpriteAvatar/" + gameProfiles[i].Avatar);
                goColorMain.color = gameProfiles[i].Color;
                goColorPopUp.color = gameProfiles[i].Color;

            }
            else
            {
                avatarImages[i].color = crema;
            }

        }

    }

    public void ClearInputField()
    {
        inputName.text = "";
    }
}
