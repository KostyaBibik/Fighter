using TMPro;
using UI.Abstract;
using UnityEngine;

namespace UI
{
    public class UILoadingView : UIView
    {
        [SerializeField] private TextMeshProUGUI _text;

        public TextMeshProUGUI Text => _text;
    }
}