using UnityEngine;
using UnityEngine.UI;

namespace MassiveCore.Framework
{
    public class ImageButton : BaseButton
    {
        [SerializeField]
        private Image _image;

        public Sprite Sprite
        {
            get => _image.sprite;
            set => _image.sprite = value;
        }
    }
}
