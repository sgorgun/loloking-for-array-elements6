using System;

namespace LookingForArrayElements
{
    public static class FloatCounter
    {
        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[]? arrayToSearch, float[]? rangeStart, float[]? rangeEnd)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeStart is null)
            {
                throw new ArgumentNullException(nameof(rangeStart));
            }

            if (rangeEnd is null)
            {
                throw new ArgumentNullException(nameof(rangeEnd));
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("The length of the rangeStart and rangeEnd arrays must be equal.");
            }

            for (int n = 0; n < rangeStart.Length; n++)
            {
                if (rangeStart[n] > rangeEnd[n])
                {
                    throw new ArgumentException(nameof(rangeStart));
                }
            }

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            if (rangeStart.Length == 0)
            {
                return 0;
            }

            if (rangeEnd.Length == 0)
            {
                return 0;
            }

            if (arrayToSearch.Length < rangeStart.Length)
            {
                throw new ArgumentException("The length of the arrayToSearch array must be greater than or equal to the length of the rangeStart and rangeEnd arrays.");
            }

            if (arrayToSearch.Length < rangeEnd.Length)
            {
                throw new ArgumentException("The length of the arrayToSearch array must be greater than or equal to the length of the rangeStart and rangeEnd arrays.");
            }

            int result = 0;
            for (int i = 0; i < arrayToSearch.Length; i++)
            {
                for (int j = 0; j < rangeStart.Length; j++)
                {
                    if (arrayToSearch[i] >= rangeStart[j] && arrayToSearch[i] <= rangeEnd[j])
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
         /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[]? arrayToSearch, float[]? rangeStart, float[]? rangeEnd, int startIndex, int count)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeStart is null)
            {
                throw new ArgumentNullException(nameof(rangeStart));
            }

            if (rangeEnd is null)
            {
                throw new ArgumentNullException(nameof(rangeEnd));
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("The length of the rangeStart and rangeEnd arrays must be equal.");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is less than zero");
            }

            if (startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is greater than arrayToSearch.Length");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "count is less than zero");
            }

            for (int n = 0; n < rangeStart.Length; n++)
            {
                if (rangeStart[n] > rangeEnd[n])
                {
                    throw new ArgumentException(nameof(rangeStart));
                }
            }

            if (startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "startIndex + count is greater than arrayToSearch.Length");
            }

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            if (rangeStart.Length == 0)
            {
                return 0;
            }

            if (rangeEnd.Length == 0)
            {
                return 0;
            }

            int result = 0;
            int i = startIndex;
            do
            {
                int j = 0;
                do
                {
                    if (arrayToSearch[i] >= rangeStart[j] && arrayToSearch[i] <= rangeEnd[j])
                    {
                        result++;
                    }

                    j++;
                }
                while (j < rangeStart.Length);

                i++;
            }
            while (i < startIndex + count);

            return result;
        }
    }
}
