using Dtos;
using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldSelectMenu : MonoBehaviour
{
    public List<Environment2DDto> environments;
    public List<TMP_Text> ButtonTexts;
    void Start()
    {
        //Load worlds upon start
    }
}
