public enum PromoCodeResultType
{
    Invalid,
    Unknown,
    AlreadyUsed,
    Activated
}

public class PromoCodeResult
{
    public PromoCodeResultType ResultType;
    public string TranslationKey;

    public PromoCodeResult(PromoCodeResultType resultType, string translationKey)
    {
        ResultType = resultType;
        TranslationKey = translationKey;
    }
}