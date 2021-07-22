using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using WebManagement;

namespace DefaultNamespace
{
    public enum RequestType
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    public class HttpManager : MonoBehaviour, IHttpManager
    {
        private const string BaseUrl = "https://api.tinkr.cl/";
        private LoginManager loginManager;
        public string token { get; set; }

        private void Awake()
        {
            DontDestroyOnLoad(transform);
        }

        public void SendLoginRequest(LoginModel loginModel)
        {
            var urlMessage = BaseUrl + "login/";
            var webRequest = UnityWebRequest.Put(urlMessage, JsonUtility.ToJson(loginModel));
            webRequest.method = UnityWebRequest.kHttpVerbPOST;  
            AttachHeadersToReq(webRequest, "Content-Type", "application/json");
            StartCoroutine(SendLoginRequest(webRequest));
        }

        private static IEnumerator SendLoginRequest(UnityWebRequest webRequest)
        {
            yield return webRequest.SendWebRequest();
            Debug.Log(webRequest.downloadHandler.text);
        }
        
        public UnityWebRequest CreateRequest(string path, RequestType rType, object data)
        {
            var wReq = new UnityWebRequest(path, rType.ToString());
            if (data != null)
            {
                var bodyRaw = Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
                wReq.uploadHandler = new UploadHandlerRaw(bodyRaw);
            }
            wReq.downloadHandler = new DownloadHandlerBuffer();
            AttachHeadersToReq(wReq, "Content-Type", "application/json");
            return wReq;
        }

        private void AttachHeadersToReq(UnityWebRequest webRequest, string key, string value)
        {
            webRequest.SetRequestHeader(key, value);
        }
    }

    public interface IHttpManager
    {
        public void SendLoginRequest(LoginModel loginModel);
        public UnityWebRequest CreateRequest(string path, RequestType rType, object data);
    }
}