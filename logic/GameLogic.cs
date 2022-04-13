using System.Security.Cryptography;

namespace game;

public class GameLogic
{
    /*
     * @return 1, if user wins
     * @return 0, if user loose
     * @return -1, if draw
     */
    public static int FindWinner(int peopleChoice, int computerChoice, int optionsCount)
    {
        var result = 0;
        var winOptionCount = (int)(optionsCount / 2);
        var distance = computerChoice - peopleChoice;
        if ((distance > 0 && distance <= winOptionCount)
            || (distance < 0 && Math.Abs(distance) > winOptionCount))
        {
            result = 1;
        }

        if (distance == 0)
        {
            result = -1;
        }
        return result;
    }

    public static string GenerateHMACKey()
    {
        var randomNumber = "";
        for (int i = 0; i < 16; i++)
        {
            randomNumber += RandomNumberGenerator.GetInt32(2147483647);
        }
        
        return randomNumber;
    }

    public static string GenerateChoiceHMAC(string HMACKey, int optionsCount, int computerChoice)
    {
        var charArray = HMACKey.ToCharArray();
        byte[] bytes = new byte[charArray.Length + 1];
        for (int i = 0; i < charArray.Length; i++)
        {
            bytes[i] = (byte)charArray[i];
        }

        bytes[charArray.Length] = (byte)computerChoice;
        var bytesHMAC = SHA256.HashData(bytes);
        var HMAC = "";
        for (int i = 0; i < bytes.Length; i++)
        {
            HMAC += bytes[i];
        }

        return HMAC;
    }
}