using UnityEngine;

namespace FishyBusiness
{
    public static class PhoneNumberUtilities
    {
        public static string GeneratePhoneNumber()
        {
            string[] prefixes = { "06", "07" };
            string prefix = prefixes[Random.Range(0, prefixes.Length)];
            string generatedPhoneNumber = prefix;

            for (int i = 0; i < 8; i++)
            {
                generatedPhoneNumber += Random.Range(0, 10).ToString();
            }
            return generatedPhoneNumber;
        }
    }
}