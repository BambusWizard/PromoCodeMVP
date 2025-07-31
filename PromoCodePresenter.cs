public class PromoCodePresenter
{
    private readonly PromoCodeModel model;
    private readonly PromoCodeView view;

    public PromoCodePresenter(PromoCodeModel model, PromoCodeView view)
    {
        this.model = model;
        this.view = view;
        
        view.Initialize();
        view.SetSubmitCallback(OnSubmit);
    }

    private void OnSubmit()
    {
        var input = view.GetInput();
        var result = model.TryActivate(input, out var cleanedCode);

        if (result.ResultType == PromoCodeResultType.Activated)
        {
            EventBusSystem.EventBus.RaiseEvent<IPromoCodeHandler>(h => h.OnActivate());
            DataStorage.Instance.PlayerData.activatedPromoCodes.Add(cleanedCode);
            DataStorage.Instance.SaveData();
        }

        var message = LanguageController.Instance.GetTranslatedText(LocalizationTable.Main, result.TranslationKey);
        view.ShowMessage(message, result.ResultType);
        view.ClearInput();
    }
}