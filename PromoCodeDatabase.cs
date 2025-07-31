using UnityEngine;

[CreateAssetMenu(fileName = "PromoCodeDatabase", menuName = "Game/PromoCode Database")]
public class PromoCodeDatabase : ScriptableObject
{
    [Tooltip("List of all valid promo codes (lowercase, no symbols)")]
    public PlayerData.PromoCodes set;

    public bool IsValidCode(string code)
    {
        set ??= new PlayerData.PromoCodes();
        return set.Contains(code);
    }
}