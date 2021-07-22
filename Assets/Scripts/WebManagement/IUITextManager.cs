using UnityEngine;

namespace DefaultNamespace
{
    public interface IUITextManager
    {
        public bool CheckPasswordText();
        public bool CheckMailAddress();

        public bool CanSendMAilAndPassword();
    }
}