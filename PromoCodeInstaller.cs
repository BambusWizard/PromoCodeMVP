using UnityEngine;

public class PromoCodeInstaller : MonoBehaviour
{
    [SerializeField] private PromoCodeView view;
    [SerializeField] private PromoCodeDatabase promoCodeDatabase;

    private PromoCodePresenter presenter;

    private void Awake()
    {
        var promoCodesStorage = DataStorage.Instance.PlayerData.activatedPromoCodes;
        var model = new PromoCodeModel(promoCodesStorage, promoCodeDatabase);
        presenter = new PromoCodePresenter(model, view);
    }
}