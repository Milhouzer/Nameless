using UnityEngine;

namespace Milhouzer.Common.Utility
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    Debug.Log("Found instance of " + typeof(T) + " " + instance);
                    if (instance == null)
                    {
                        GameObject singletonObject = new GameObject();
                        instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + " (Singleton)";
                        Debug.Log("Create instance of " + typeof(T));
                    }
                }

                return instance;
            }
        }

        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
            }
            else
            {
                Debug.Log("[" + typeof(T).ToString() + "] Already exists, deleting this object");
                Destroy(gameObject);
            }
        }
    }
}
