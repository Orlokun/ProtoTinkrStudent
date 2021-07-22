using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateProjectButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject popUpGameObj;
    [SerializeField] private TabGroup popUpGroup;

    private void Awake()
    {
        SetPopUps();
    }

    private void SetPopUps()
    {
        if (popUpGameObj == null)
        {
            //TODO: CreateStandardPopUp
            Debug.LogError("tHERE IS NO POP UP OBJECT ASSIGNED TO THIS BUTTON: " + gameObject.name);
        }
        else
        {
            try
            {
                popUpGroup = popUpGameObj.GetComponent<TabGroup>();
            }
            catch
            {
                Debug.LogError("The pop up object in: " + gameObject.name + " hhas no TabGroup Component");
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SetPopUpActive(true);
    }

    public void SetPopUpActive(bool isActive)
    {
        popUpGameObj.SetActive(isActive);
    }

}
