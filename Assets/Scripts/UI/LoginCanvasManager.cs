using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using WebManagement;

public class LoginCanvasManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mailWarningText;
    [SerializeField]
    private GameObject passWarningText;

    
    [SerializeField]
    private GameObject mailInputObject;
    [SerializeField]
    private GameObject passInputObject;
    private LoginManager loginManager;
    private void Awake()
    {
        loginManager = InputsAreNotNull()
            ? new LoginManager(mailInputObject, passInputObject, mailWarningText, passWarningText)
            : throw new ArgumentException("Mail input or pass input Game Object is null");
    }

    private bool InputsAreNotNull()
    {
        return mailInputObject != null && passInputObject != null;
    }

    public void StartLoginProcess()
    {
        if (loginManager.CanSendMAilAndPassword())
        {
            var loginModel = loginManager.PrepareLoginElements();
            var httpManager = FindObjectOfType<HttpManager>();
            httpManager.SendLoginRequest(loginModel);
        }
    }

    public void CheckInputsInLoginElements()
    {
        var mailInputState = loginManager.CheckMailAddress();
        var passInputState = loginManager.CheckPasswordText();
        Debug.Log("It's " + (mailInputState && passInputState) + " That mail & pass inputs are correct");
    }
}
