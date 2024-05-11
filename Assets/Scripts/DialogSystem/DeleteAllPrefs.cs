using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAllPrefs : MonoBehaviour
{
    void Awake()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All Prefs Deleted");
    }
}
