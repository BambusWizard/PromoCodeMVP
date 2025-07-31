using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PromoCodeView : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_InputField promoCodeInput;
    [SerializeField] private TextMeshProUGUI feedbackText;
    [SerializeField] private Button submitButton;
    
    [Header("Feedback Colors")]
    [SerializeField] private Color successColor = Color.green;
    [SerializeField] private Color usedColor = Color.gray;
    [SerializeField] private Color errorColor = Color.red;
    
    public void Initialize()
    {
        feedbackText.text = string.Empty;
    }
    
    public string GetInput() => promoCodeInput.text;
    
    public void ShowMessage(string message, PromoCodeResultType resultType)
    {
        feedbackText.text = message;
        feedbackText.color = resultType switch
        {
            PromoCodeResultType.Activated   => successColor,
            PromoCodeResultType.AlreadyUsed => usedColor,
            _                               => errorColor,
        };
    }

    public void ClearInput()
    {
        promoCodeInput.text = string.Empty;
    }

    public void SetSubmitCallback(System.Action callback)
    {
        submitButton.onClick.RemoveAllListeners();
        submitButton.onClick.AddListener(() => callback?.Invoke());
    }
}