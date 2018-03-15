using UnityEngine;
using System;

namespace ThreeStar.InputManagement {
    [Serializable]
    public struct InputAxis {
        public string axisName;
        public KeyCode positiveKey;
        public KeyCode negativeKey;
        [HideInInspector] public bool positive;
        [HideInInspector] public bool negative;
        [HideInInspector] public float axis;
        [HideInInspector] public float targetAxis;
        public float sensitivity;
        public string pKeyDescription;
        public string nKeyDescription;
    }
}