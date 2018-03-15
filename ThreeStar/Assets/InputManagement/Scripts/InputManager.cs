using UnityEngine;

namespace ThreeStar.InputManagement {
    public class InputManager : MonoBehaviour {
        public InputConfig inputConfig;

        private void FixedUpdate () {
            for (int i = 0; i < inputConfig.axes.Length; i++) {
                inputConfig.axes[i].negative = Input.GetKey (inputConfig.axes[i].negativeKey);
                inputConfig.axes[i].positive = Input.GetKey (inputConfig.axes[i].positiveKey);
                inputConfig.axes[i].targetAxis = inputConfig.axes[i].negative ? -1 : inputConfig.axes[i].positive ? 1 : 0;
                inputConfig.axes[i].axis = Mathf.MoveTowards (
                    inputConfig.axes[i].axis, inputConfig.axes[i].targetAxis, inputConfig.axes[i].sensitivity * Time.deltaTime);
            }
        }

        public float GetAxis (string name) {
            for (int i = 0; i < inputConfig.axes.Length; i++) {
                if (string.Equals (name, inputConfig.axes[i].axisName)) {
                    return inputConfig.axes[i].axis;
                }
            }
            return 0;
        }

        public bool GetButton (string name) {
            for (int i = 0; i < inputConfig.axes.Length; i++) {
                if (string.Equals (name, inputConfig.axes[i].axisName)) {
                    return inputConfig.axes[i].positive;
                }
            }
            return false;
        }
    }
}
