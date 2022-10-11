using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Profiles
{
    [SerializeField] private Profile[] gameProfiles;
    public Profile[] GameProfiles { get => gameProfiles; set => gameProfiles = value; }

    public Profiles(Profile[] gameProfiles)
    {
        this.GameProfiles = gameProfiles;
    }

    public Profiles()
    {

    }

}
