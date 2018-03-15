using UnityEngine;

namespace ThreeStar.InputManagement {
    [CreateAssetMenu (fileName = "NewInputConfig", menuName = "Input Configuration")]
    public class InputConfig : ScriptableObject {
        public InputAxis[] axes;
    }
}