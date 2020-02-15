using UnityEngine;
using Random = System.Random;

/// <summary>
/// Generates random numbers
/// </summary>
public class RandomNumberGenerator : MonoBehaviour
{
    private static Random rand;

    /// <summary>
    /// Initializes the random number generator
    /// </summary>
    public static void Initialize()
    {
        rand = new Random();
    }

    /// <summary>
    /// Returns a non-negative random integer that is less than the specified 
    /// maximum
    /// </summary>
    /// <param name="maxValue">The exclusive upper bound of the random number 
    ///     to be generated</param>
    /// <returns>An integer that is greater than or equal 
    ///     to 0, and less than maxValue</returns>
    public static int Next(int maxValue)
    {
        return rand.Next(maxValue);
    }
}
