using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SaveButtonInput : MonoBehaviour
{
    private List<Toggle> toggles = new List<Toggle>();
    [SerializeField] private string settingName;

    private void Awake()
    {
        GetComponentsInChildren(toggles);

        foreach(Toggle toggle in toggles)
        {
            toggle.isOn = false;
            toggle.onValueChanged.AddListener((bool isOn) => { OnToggleChanged(isOn, toggles.IndexOf(toggle)); });
        }

        int toggleIndex = PlayerPrefs.GetInt(settingName);
        if(toggleIndex >= 0 && toggleIndex < toggles.Count)
        {
            toggles[toggleIndex].isOn = true;
        }
    }

    private void OnToggleChanged(bool isOn, int toggleIndex)
    {
        if(isOn)
        {
            PlayerPrefs.SetInt(settingName, toggleIndex);
        }
    }
}
