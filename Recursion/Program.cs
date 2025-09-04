// BINARY SEARCH
static int BinarySearch(int[] array, int item, int low, int high)
{
    if (array == null || array.Length == 0) 
        return -1;

    if (low > high) 
        return -1;

    var mid = low + (high - low) / 2;
    var midItem = array[mid];

    if(midItem == item)
        return mid;

    return midItem < item
        ? BinarySerach(array, item, mid + 1, high)
        : BinarySerach(array, item, low, mid - 1);
}

// SUM OF DIGITS

// NUMBER OF ITEMS

// HIGHEST VALUE

// QUICK SORT

// MERGE SORT