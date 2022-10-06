using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MassiveCore.Framework
{
    public class AnimatedNumericText : BaseMonoBehaviour
    {
        [SerializeField]
        private Text _text;

        [SerializeField]
        private string _format = "{0}";

        [Space, SerializeField]
        private float _animationSpeed = 5f;

        private AnimatedNumber _animation;

        public int Number
        {
            get => (int)_animation.TargetNumber;
            set => _animation.TargetNumber = value;
        }

        private void Awake()
        {
            InitAnimation();
            SubscribeOnAnimation();
        }

        private void InitAnimation()
        {
            _animation = new AnimatedNumber(_animationSpeed);
            _animation.AddTo(this);
            _animation.Initialize();
        }

        private void SubscribeOnAnimation()
        {
            _animation.Number.Subscribe(value => UpdateText((int)Mathf.Round(value)));
        }

        private void UpdateText(int value)
        {
            _text.text = string.IsNullOrEmpty(_format) ? value.ToString() : string.Format(_format, value);
        }
    }
}
