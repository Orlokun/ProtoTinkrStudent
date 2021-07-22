using System;
using DefaultNamespace;
using TMPro;
using UnityEngine;

namespace WebManagement
{
    public class LoginManager : IUITextManager
    {
        private GameObject mailInputObject;
        private GameObject passInputObject;

        private GameObject mailWarningText;
        private GameObject passWarningText;

        public LoginManager(GameObject mailInputObject, GameObject passInputObject, GameObject mailWarningText, GameObject passWarningText)
        {
            this.mailInputObject = mailInputObject;
            this.passInputObject = passInputObject;
            this.mailWarningText = mailWarningText;
            this.passWarningText = passWarningText;
        }


        public LoginModel PrepareLoginElements()
        {
            var mail = mailInputObject.GetComponent<TMP_InputField>().text;
            var pass = passInputObject.GetComponent<TMP_InputField>().text;
            return new LoginModel(mail, pass);
        }
        public bool CanSendMAilAndPassword()
        {
            return CheckMailAddress() && CheckPasswordText();
        }
        public bool CheckMailAddress()
        {
            var mail = mailInputObject.GetComponent<TMP_InputField>().text;

            if (string.IsNullOrEmpty(mail) || !mail.Contains("@") || !mail.Contains("."))
            {
                mailWarningText.SetActive(true);
                return false;
            }
            else
            {
                if (mailWarningText.activeInHierarchy)
                    mailWarningText.SetActive(false);
            }                
            Debug.Log("mail is " + mail);
            return true;
        }
        public bool CheckPasswordText()
        {
            var pass = passInputObject.GetComponent<TMP_InputField>().text;
            if (string.IsNullOrEmpty(pass))
            {
                passWarningText.SetActive(true);
                Debug.LogError("Password is empty");
                return false;
            }
            else
            {
                if (passWarningText.activeInHierarchy)
                {
                    passWarningText.SetActive(false);
                    Debug.Log("pass is " + pass);
                }
            }
            Debug.Log("Pass is: " + pass);
            return true;
        }
    }
}