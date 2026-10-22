using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class BuyButton : MonoBehaviour
    {
        public Button.ButtonClickedEvent ButtonOnClick => _button.onClick;

        public string ProductId;
        public string ProductTitle;
        [SerializeField ]private Button _button;

        public void SetData(string productId, string productTitle)
        {
            ProductId = productId;
            ProductTitle = productTitle;
            _button.GetComponentInChildren<TMP_Text>().SetText(productTitle);
        }
    }
}