using System;

namespace LookingForArrayElements
{
    public static class DecimalCounter
    {
        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[]? arrayToSearch, decimal[]?[]? ranges)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "The arrayToSearch parameter cannot be null.");
            }

            if (ranges == null)
            {
                throw new ArgumentNullException(nameof(ranges), "The ranges parameter cannot be null.");
            }

            int i;
            for (i = 0; i < ranges.Length; i++)
            {
                if (ranges[i] == null)
                {
                    throw new ArgumentNullException($"The ranges[{i}] parameter cannot be null.");
                }

                if (ranges[i] != Array.Empty<decimal>() && ranges[i]!.Length != 2)
                {
                    throw new ArgumentException($"The ranges[{i}] array must have exactly two elements.");
                }
            }

            if (ranges.Length == 0)
            {
                return 0;
            }

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            int count = 0;
            i = 0;
            do
            {
                int j = 0;
                do
                {
                    if (ranges[j] != Array.Empty<decimal>() &&
                        arrayToSearch[i] >= ranges[j]![0] && arrayToSearch[i] <= ranges[j]![1])
                    {
                        count++;
                        break;
                    }

                    j++;
                }
                while (j < ranges.Length);

                i++;
            }
            while (i < arrayToSearch.Length);

            return count;
        }

        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[]? arrayToSearch, decimal[]?[]? ranges, int startIndex, int count)
        {
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "The arrayToSearch parameter cannot be null.");
            }

            if (ranges == null)
            {
                throw new ArgumentNullException(nameof(ranges), "The ranges parameter cannot be null.");
            }

            for (int i = 0; i < ranges.Length; i++)
            {
                if (ranges[i] == null)
                {
                    throw new ArgumentNullException($"The ranges[{i}] parameter cannot be null.");
                }

                if (ranges[i] != Array.Empty<decimal>() && ranges[i]!.Length != 2)
                {
                    throw new ArgumentException($"The ranges[{i}] array must have exactly two elements.");
                }
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "The count parameter must be greater than or equal to zero.");
            }

            if (startIndex < 0 || startIndex >= arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "The startIndex parameter must be greater than or equal to zero and less than the length of the arrayToSearch parameter.");
            }

            if (count > arrayToSearch.Length - startIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "The count parameter must be less than or equal to the length of the arrayToSearch parameter minus the startIndex parameter.");
            }

            if (arrayToSearch.Length == 0 || count == 0)
            {
                return 0;
            }

            int result = 0;
            for (int i = startIndex; i < startIndex + count; i++)
            {
                for (int j = 0; j < ranges.Length; j++)
                {
                    if (ranges[j] != Array.Empty<decimal>() && arrayToSearch[i] >= ranges[j]![0] && arrayToSearch[i] <= ranges[j]![1])
                    {
                        result++;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
