using System;
using System.Collections.Generic;
using UnityEngine;

namespace OpenWorldDriving.InputSystem
{
    /// <summary>
    /// ScriptableObject storage for rebindable key mappings.
    /// </summary>
    [CreateAssetMenu(menuName = "OpenWorldDriving/Input/Bindings")]
    public class InputBindingsSO : ScriptableObject
    {
        [Serializable]
        public class Binding
        {
            public string actionName;
            public KeyCode key;
        }

        [Tooltip("List of action name to key bindings.")]
        public List<Binding> bindings = new List<Binding>();

        public KeyCode GetKey(string actionName)
        {
            var binding = bindings.Find(item => item.actionName == actionName);
            return binding != null ? binding.key : KeyCode.None;
        }

        public void SetKey(string actionName, KeyCode newKey)
        {
            var binding = bindings.Find(item => item.actionName == actionName);
            if (binding == null)
            {
                binding = new Binding { actionName = actionName, key = newKey };
                bindings.Add(binding);
                return;
            }

            binding.key = newKey;
        }
    }
}
