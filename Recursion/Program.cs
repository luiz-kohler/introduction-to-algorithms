Random random = new Random();
int[] GenerateUniqueNumbers (int quantity) => Enumerable.Range(1, 100)
                                .OrderBy(x => random.Next()) 
                                .Take(quantity) 
                                .ToArray();

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
        ? BinarySearch(array, item, mid + 1, high)
        : BinarySearch(array, item, low, mid - 1);
}

// SUM OF DIGITS
static int SumOfDigits(int[] array)
{
    if(array == null || array.Length == 0)
        return 0;

    if(array.Length == 1)
        return array[0];

    var newArr = array.Where((_, index) => index != 0).ToArray(); ;

    return array[0] + SumOfDigits(newArr);
}

// QUICK SORT

int[] QuickSort(int[] array)
{
    if (array == null || array.Length == 0)
        return [];

    else if (array.Length == 1)
        return array;

    else if (array.Length == 2)
    {
        return array[0] < array[1]
            ? array
            : array.Reverse().ToArray();
    }

    var mid = (array.Length - 1) / 2;
    var pivot = array[mid];

    var highers = array.Where(item => item > pivot).ToArray();
    var smallers = array.Where(item => item < pivot).ToArray();
    var equals = array.Where(item => item == pivot).ToArray(); 

    return [.. QuickSort(smallers), .. equals, .. QuickSort(highers)];
}


var numbers = GenerateUniqueNumbers(20);

Console.WriteLine($"## {string.Join(", ", numbers)} ##");
Console.WriteLine($"## {string.Join(", ", QuickSort(numbers))} ##");

// MERGE SORT