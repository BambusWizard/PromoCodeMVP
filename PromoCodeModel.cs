using System.Text.RegularExpressions;

public class PromoCodeModel
{
    private readonly PlayerData.PromoCodes promoCodesStorage;
    private readonly PromoCodeDatabase database;

    public PromoCodeModel(PlayerData.PromoCodes promoCodesStorage, PromoCodeDatabase database)
    {
        this.promoCodesStorage = promoCodesStorage;
        this.database = database;
    }

    public PromoCodeResult TryActivate(string input, out string cleanedCode)
    {
        cleanedCode = Sanitize(input);

        if (string.IsNullOrEmpty(cleanedCode))
            return new PromoCodeResult(PromoCodeResultType.Invalid, "PromoCode.Invalid");

        if (!database.IsValidCode(cleanedCode))
            return new PromoCodeResult(PromoCodeResultType.Unknown, "PromoCode.Unknown");

        if (!promoCodesStorage.Add(cleanedCode))
            return new PromoCodeResult(PromoCodeResultType.AlreadyUsed, "PromoCode.AlreadyUsed");

        return new PromoCodeResult(PromoCodeResultType.Activated, "PromoCode.Activated");
    }

    private string Sanitize(string input)
    {
        return Regex.Replace(input.Trim().ToLower(), @"[^a-z0-9]", "");
    }
}
