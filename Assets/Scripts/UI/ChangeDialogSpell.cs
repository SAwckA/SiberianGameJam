using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDialogSpell : MonoBehaviour
{
    [SerializeField] string prefID;
    [SerializeField] int stageID;

    public void ChangePref()
    {
        PlayerPrefs.SetInt(prefID, stageID);
        Debug.Log(PlayerPrefs.GetInt(prefID));
    }
}
