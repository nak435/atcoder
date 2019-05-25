    public static int LowerBound<T>(T[] arr, int start, int end, T value, IComparer<T> comparer) {
        int low = start, high = end, mid;
        while (low < high) {
            mid = ((high - low) >> 1) + low;
            if (comparer.Compare(arr[mid], value) < 0)
                low = mid + 1;
            else
                high = mid;
        }
    #if LOCAL_ENVIRONMENT
        Console.Error.WriteLine($"LowerBound(array:{arr.ToStringA()}");
        Console.Error.WriteLine($"LowerBound(start:{start}, end:{end}, value:{value.ToString()}) return:{low}");
    #endif
        return low;
    }
    public static int LowerBound<T>(T[] array, T value) where T : IComparable {
        return LowerBound(array, 0, array.Length, value, Comparer<T>.Default);
    }

    private static int LowerBound(int[] arr, int val) {
        int left = 0, right = arr.Length - 1, center;
        while (left <= right) {
            center = (left + right) >> 1;
            if (val > arr[center]) left = center + 1;
            else right = center - 1;
        }
        return left;
    }
