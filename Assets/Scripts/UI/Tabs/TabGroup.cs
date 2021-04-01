using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    private UIGeneralManager uiGeneralManager;
    private TabButton selTab;
    [SerializeField] private Transform tabButtonsHolder;
    private List<TabButton> tButtons;

    protected float exitDelaytime = 1.1f;
    protected static LTDescr delay;

    public void Initialize()
    {
        tButtons = new List<TabButton>();
        uiGeneralManager = FindObjectOfType<UIGeneralManager>();
        SubscribeTabButtons();
        UpdateTabGroupState();
    }
    private void SubscribeTabButtons()
    {
        for (int i = 0; i < tabButtonsHolder.childCount; i++)
        {
            var tabButton = tabButtonsHolder.GetChild(i).GetComponent<TabButton>();
            tabButton.tGroup = this;
            tabButton.bGround = tabButton.GetComponent<Image>();
            tButtons.Add(tabButton);
            if (!tabButton.isStartingTab) continue;
            selTab = tabButton;
        }
    }

    private void UpdateTabGroupState()
    {
        foreach (var tButton in tButtons)
        {
            if (tButton.Equals(selTab))
            {
                SetTabButtonColor(tButton, true);
                ActivateTabObjects(tButton, true);
            }
            else
            {
                SetTabButtonColor(tButton, false);
                ActivateTabObjects(tButton, false);
            }
        }
    }

    public virtual void ClickOnTab(TabButton _button)
    {
        selTab = _button;
        UpdateTabGroupState();
    }

    protected void RotateObjectsInZAxis(TabButton _button)
    {
        if (_button.RotatingObjectsCount() <= 0) return;
        _button.StartRotatingObjects();
    }

    protected void SetTabButtonColor(TabButton tabButton, bool selected)
    {
        Color col;
        if (selected)
        {
            ColorUtility.TryParseHtmlString(uiGeneralManager.themeColors.selCol, out col);
        }
        else
        {
            ColorUtility.TryParseHtmlString(uiGeneralManager.themeColors.nonSelCol, out col);
        }

        tabButton.bGround.color = col;
    }

    private static void ActivateTabObjects(TabButton tabButton, bool selected)
    {
        foreach (var gObject in tabButton.objectsToOpenWhenSelected)
        {
            //TODO: Check Hardcoded delayTime
            delay = LeanTween.delayedCall(.3f, () => { gObject.SetActive(selected); });
        }
    }
}