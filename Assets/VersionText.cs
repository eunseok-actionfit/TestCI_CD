using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class VersionText : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var text = GetComponent<TMP_Text>();
        text.text = $"Version: {Application.version}";
    }
}