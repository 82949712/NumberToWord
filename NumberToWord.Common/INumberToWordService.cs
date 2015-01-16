namespace NumberToWord.Common
{
    public interface INumberToWordService<in T>
    {
        /// <summary>
        /// Converts the specified input to another.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        string Convert(T input);
    }
}
