using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ThemeColors
{
    public readonly string nonSelCol;
    public readonly string selCol;
    
    public ThemeColors(string _nonSelCol, string _selCol)
    {
        nonSelCol = _nonSelCol;
        selCol = _selCol;
    }
}

public class UIGeneralManager : MonoBehaviour
{
    public ThemeColors themeColors;
    public List<TabGroup> tGroups;
    
    private string selCol = "#D2FFF2";
    private string nonSelCol = "#FEFAFA";

    private void Awake()
    {
        SetThemeColors();
        InitializeTGroups();
    }
    private void InitializeTGroups()
    {
        foreach (var tabGroup in FindObjectsOfType<TabGroup>())
        {
            tGroups.Add(tabGroup);
            tabGroup.Initialize(this);
        }
    }
    public void SetThemeColors()
    {
        themeColors = new ThemeColors(nonSelCol, selCol);
    }
    public void InitializeTabGroup(TabGroup tGroup)
    {
        tGroups.Add(tGroup);
        tGroup.Initialize(this);
    }
    public void SetObjectInactiveInUI(GameObject gObject)
    {
        gObject.SetActive(false);
    }
    public void SetObjectActiveInUI(GameObject gObject)
    {
        gObject.SetActive(true);
    }
}
