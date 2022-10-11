using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Profile
{
    [SerializeField] private string _nickname;
    [SerializeField] private string _avatar;
    [SerializeField] private Color _color;

    [SerializeField] private float _sfxVolume;
    [SerializeField] private float _musicVolume;

    [SerializeField] private string[] _blockedGames;

    [SerializeField] private bool _isSelected;

    public string Nickname { get => _nickname.ToUpper(); set => _nickname = value; }
    public string Avatar { get => _avatar; set => _avatar = value; }
    public Color Color { get => _color; set => _color = value; }
    public float SfxVolume { get => _sfxVolume; set => _sfxVolume = value; }
    public float MusicVolume { get => _musicVolume; set => _musicVolume = value; }
    public string[] BlockedGames { get => _blockedGames; set => _blockedGames = value; }
    public bool IsSelected { get => _isSelected; set => _isSelected = value; }


    // Valores del perfil por defecto
    public Profile(string avatar)
    {
        this.Nickname = "New Name";
        this.Avatar = avatar;
        this.Color = new Color32(51, 91, 118, 255);
        this.SfxVolume = 0.8f;
        this.MusicVolume = 0.8f;
        this.BlockedGames = null;
        this.IsSelected = false;
    }

    public Profile(string nickname, string avatar, Color color, float sfxVolume, float musicVolume, string[] blockedGames, bool isSelected)
    {
        this.Nickname = nickname;
        this.Avatar = avatar;
        this.Color = color;
        this.SfxVolume = sfxVolume;
        this.MusicVolume = musicVolume;
        this.BlockedGames = blockedGames;
        this.IsSelected = isSelected;
    }

}
