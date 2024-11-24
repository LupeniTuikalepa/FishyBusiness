using UnityEngine;

namespace LTX
{
    public static class UnityEngineExtensions
    {
        public static void ClearChildren(this Transform transform, params Transform[] ignore)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
                ClearEditor(transform, ignore);
            else
#endif
                ClearRuntime(transform, ignore);
        }

#if UNITY_EDITOR
        private static void ClearEditor(this Transform transform, params Transform[] ignore)
        {
            int childCount = transform.childCount;
            int offset = 0;
            for (int i = 0; i + offset < childCount; i++)
            {
                Transform child = transform.GetChild(offset);
                bool valid = true;
                for (int j = 0; j < ignore.Length; j++)
                {
                    if (ignore[j] == child)
                    {
                        valid = false;
                        break;
                    }
                }

                if (!valid)
                {
                    offset++;
                    continue;
                }

                child.DestroyGameObject();
            }
        }
#endif

        private static void ClearRuntime(this Transform transform, params Transform[] ignore)
        {
            int childCount = transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Transform child = transform.GetChild(i);
                bool valid = true;
                for (int j = 0; j < ignore.Length; j++)
                {
                    if (ignore[j] == child)
                    {
                        valid = false;
                        break;
                    }
                }

                if (valid)
                    child.DestroyGameObject();
            }
        }


        public static void Activate(this GameObject unityObject) => unityObject.SetActive(true);
        public static void Deactivate(this GameObject unityObject) => unityObject.SetActive(false);

        public static void DestroyGameObject(this Component component) => component.gameObject.Destroy();
        public static void Destroy<T> (this T unityObject) where T : Object
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
                Object.DestroyImmediate(unityObject);
            else
#endif
                Object.Destroy(unityObject);
        }

    }
}