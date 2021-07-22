using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum WheelGeneratorType
{
    Instantiator,
    Organizer
}
public struct UITabButtons
{
    private TabButton tButton;
    private RectTransform rTransform;
    [SerializeField] private Image img;
    public UITabButtons(TabButton _tButton)
    {
        this.tButton = _tButton;
        rTransform = tButton.GetComponent<RectTransform>();
        img = tButton.gameObject.GetComponent<Image>();
    }
}
public class WheelUIGenerator : MonoBehaviour
{
    private List<RectTransform> objectsInwheel;
    public GameObject myPrefab;
    public int wheelElementsCount;
    [SerializeField] private TabGroup tabGroup;
    [SerializeField] private RectTransform circleCenter;
    [SerializeField] private float circleRadius;
    [SerializeField] private float leenMoveTime;

    [SerializeField] private WheelGeneratorType wgType;

    private void Awake()
    {
        SetList();
        InstantiateOrGetObjectsForWheel();
        StartCoroutine(SetAndMoveObjectPositions());
    }
    private void SetList()
    {
        if (objectsInwheel == null)
        {
            objectsInwheel = new List<RectTransform>();
        }
    }
    private void InstantiateOrGetObjectsForWheel()
    {
        switch (wgType)
        {
            case WheelGeneratorType.Instantiator:
                InstantiateObjectsInWheel();
                //TabGroupSettings
                SetInTabGroup();
                break;
            case WheelGeneratorType.Organizer:
                SetObjectsForWheel();
                break;
            default: return;
        }
    }
    private void InstantiateObjectsInWheel()
    {
        for (int i = 0; i < wheelElementsCount; i++)
        {
            var instObject = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity, circleCenter.transform);
            objectsInwheel.Add(instObject.GetComponent<RectTransform>());
            instObject.name += i;
        }
    }

    private void SetInTabGroup ()
    {
        UIGeneralManager uiManager = FindObjectOfType<UIGeneralManager>();
        uiManager.InitializeTabGroup(tabGroup);
    }

    private void SetObjectsForWheel()
    {
        for (int i = 0; i < circleCenter.transform.childCount; i++)
        {
            if (circleCenter.transform.GetChild(i).GetComponent<TabButton>())
            {
                RectTransform rTRansform = circleCenter.transform.GetChild(i).GetComponent<RectTransform>();
                objectsInwheel.Add(rTRansform);
            }
        }
    }
    private IEnumerator SetAndMoveObjectPositions()
    {
        for (int i = 0; i < objectsInwheel.Count; i++)
        {
            yield return new WaitForSeconds(.03f);

            var angle = GetWheelAngles(i);
            var newPosition = GetObjectPositionInCircle(angle, circleRadius);
            LeanTween.move(objectsInwheel[i], newPosition, leenMoveTime);
        }
    }

    private Vector3 GetObjectPositionInCircle(float angle, float radius)
    {
        var position = circleCenter.pivot;
        var x = radius * Mathf.Cos(angle);
        var y = radius * Mathf.Sin(angle);
        return new Vector3(x, y);
    }
    private float GetWheelAngles(int index)
    {
        return index * Mathf.PI * 2 / objectsInwheel.Count;
    }
}
