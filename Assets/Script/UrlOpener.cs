using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UrlOpener : MonoBehaviour
{
    public string Url;

    public void Open()
    {
        Application.OpenURL("https://www.linkedin.com/in/dhroov-goel-48b6401aa/");
    }
}
