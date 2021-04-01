using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerClickHandler
{
    public TabGroup tGroup;
    public Image bGround;

    public bool isStartingTab;
    
    [SerializeField] private GameObject[] rotatingObjects;
    public GameObject[] objectsToOpenWhenSelected;

    void Awake()
    {
        bGround = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + " was Clicked!");
        tGroup.ClickOnTab(this);
    }

    public int RotatingObjectsCount()
    {
        return rotatingObjects.Length;
    }
    public void StartRotatingObjects()
    {
        foreach (GameObject gObj in rotatingObjects)
        {
            if (!gameObject.LeanIsTweening())
            {
                //LeanTween.rotateAround(gObj, Vector3.forward, degrees, time).setEase(LeanTweenType.easeInOutCubic);
            }
        }
    }
}
