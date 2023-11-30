using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveTextInput : MonoBehaviour
{
    [SerializeField] private string settingName;

    private void Awake()
    {
        TMP_InputField inputField = GetComponentInChildren<TMP_InputField>();
        inputField.text = PlayerPrefs.GetString(settingName) ?? string.Empty;
        inputField.onValueChanged.AddListener(TextChanged);
    }

    private void TextChanged(string newValue)
    {
        PlayerPrefs.SetString(settingName, newValue);
    }
}
