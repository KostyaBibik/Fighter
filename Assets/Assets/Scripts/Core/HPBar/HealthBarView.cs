using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void SetNormalizedValue(float value)
        {
            _slider.value = Mathf.Clamp01(value);
        }
    }
}