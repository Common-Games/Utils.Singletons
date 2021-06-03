using UnityEngine;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace CommonGames.Samples.Singletons.Basic
{

    public sealed class ExampleTester : MonoBehaviour
    {
        #region MonoBehaviour

        #region Normal

        #if ODIN_INSPECTOR
        [Button]
        #endif
        [ContextMenu(itemName: nameof(CheckMonoBehaviourSingleton))]
        private void CheckMonoBehaviourSingleton()
        {
            //Should work in editor, after start, whatever.

            if (Example_MonoBehaviourSingleton.InstanceExists)
            {
                Debug.Log(message: nameof(CheckMonoBehaviourSingleton) + " = " +
                                   Example_MonoBehaviourSingleton.Instance.Info);   
            }
            else
            {
                Debug.LogWarning(message: "No MonoBehaviourSingleton Instance Exists!");
            }
        }
        #if ODIN_INSPECTOR
        [Button]
        #endif
        [ContextMenu(itemName: nameof(CheckMonoBehaviourSingleton_Persistent))]
        private void CheckMonoBehaviourSingleton_Persistent()
        {
            if (Example_MonoBehaviourSingleton_Persistent.InstanceExists)
            {
                Debug.Log(message: nameof(CheckMonoBehaviourSingleton_Persistent) + " = " +
                                   Example_MonoBehaviourSingleton_Persistent.Instance.Info);
            }
            else
            {
                Debug.LogWarning(message: "No MonoBehaviourSingleton_Persistent Instance Exists!");
            }
        }

        #endregion

        #region Lazy

        #if ODIN_INSPECTOR
        [Button]
        #endif
        [ContextMenu(itemName: nameof(CheckMonoBehaviourSingleton_Lazy))]
        private void CheckMonoBehaviourSingleton_Lazy()
        {
            Debug.Log(message: nameof(CheckMonoBehaviourSingleton_Lazy) + " = " +
                               Example_MonoBehaviourSingleton_Lazy.Instance.Info);
        }
        #if ODIN_INSPECTOR
        [Button]
        #endif
        [ContextMenu(itemName: nameof(CheckMonoBehaviourSingletonSingleton_LazyPersistent))]
        private void CheckMonoBehaviourSingletonSingleton_LazyPersistent()
        {
            Debug.Log(message: nameof(CheckMonoBehaviourSingletonSingleton_LazyPersistent) + " = " +
                               Example_MonoBehaviourSingleton_LazyPersistent.Instance.Info);
        }

        #endregion

        #region Ensured

        #if ODIN_INSPECTOR
        [Button]
        #endif
        [ContextMenu(itemName: nameof(CheckMonoBehaviourSingleton_Ensured))]
        private void CheckMonoBehaviourSingleton_Ensured()
        {
            Debug.Log(message: nameof(Example_MonoBehaviourSingleton_Ensured) + " = " +
                               Example_MonoBehaviourSingleton_Ensured.Instance.Info);
        }
        #if ODIN_INSPECTOR
        [Button]
        #endif
        [ContextMenu(itemName: nameof(CheckMonoBehaviourSingleton_EnsuredPersistent))]
        private void CheckMonoBehaviourSingleton_EnsuredPersistent()
        {
            Debug.Log(message: nameof(CheckMonoBehaviourSingleton_EnsuredPersistent) + " = " +
                               Example_MonoBehaviourSingleton_EnsuredPersistent.Instance.Info);
        }

        #endregion

        #endregion
    }
}
