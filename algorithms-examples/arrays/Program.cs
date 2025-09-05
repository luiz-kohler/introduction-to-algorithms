Random random = new Random();
int[] GenerateUniqueNumbers(int quantity) => Enumerable.Range(10, 50)
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

    if (midItem == item)
        return mid;

    return midItem < item
        ? BinarySearch(array, item, mid + 1, high)
        : BinarySearch(array, item, low, mid - 1);
}

// SUM OF DIGITS
static int SumOfDigits(int[] array)
{
    if (array == null || array.Length == 0)
        return 0;

    if (array.Length == 1)
        return array[0];

    var newArr = array.Where((_, index) => index != 0).ToArray(); ;

    return array[0] + SumOfDigits(newArr);
}

// QUICK SORT
static int[] QuickSort(int[] array)
{
    if (array.Length < 2)
        return array;

    if (array.Length == 2)
        return array[0] < array[1] ? array : array.Reverse().ToArray();

    var pivot = GetMedianOfThreePivot(array);

    var smallers = array.Where(item => item < pivot).ToArray();
    var equals = array.Where(item => item == pivot).ToArray();
    var highers = array.Where(item => item > pivot).ToArray();

    return [.. QuickSort(smallers), .. equals, .. QuickSort(highers)];
}

static int GetMedianOfThreePivot(int[] array)
{
    var first = array[0];
    var middle = array[(array.Length - 1) / 2];
    var last = array[array.Length - 1];

    if (first > middle) (first, middle) = (middle, first);
    if (middle > last) (middle, last) = (last, middle);
    if (first > middle) (first, middle) = (middle, first);

    return middle;
}

// MERGE SORT
static int[] MergeSort(int[] array)
{
    if (array.Length < 2)
        return array;

    var mid = (array.Length - 1) / 2;

    var left = array.Where((_, index) => index <= mid).ToArray();
    var right = array.Where((_, index) => index > mid).ToArray();

    left = MergeSort(left);
    right = MergeSort(right);

    return Merge(left, right);
}

static int[] Merge(int[] left, int[] right)
{
    var sorted_array = new int[left.Length + right.Length];

    var sorted_index = 0;
    int left_index = 0;
    int right_index = 0;

    int max_left_index = left.Length - 1;
    int max_right_index = right.Length - 1;

    while (left_index <= max_left_index || right_index <= max_right_index)
    {
        if (left_index <= max_left_index && right_index <= max_right_index)
        {
            var item_from_left = left[left_index];
            var item_from_right = right[right_index];

            if (item_from_left <= item_from_right)
            {
                sorted_array[sorted_index] = item_from_left;
                sorted_index++;
                left_index++;
            }
            else
            {
                sorted_array[sorted_index] = item_from_right;
                sorted_index++;
                right_index++;
            }
        }
        else if (left_index <= max_left_index)
        {
            var item_from_left = left[left_index];
            sorted_array[sorted_index] = item_from_left;
            sorted_index++;
            left_index++;
        }
        else if (right_index <= max_right_index)
        {
            var item_from_right = right[right_index];
            sorted_array[sorted_index] = item_from_right;
            sorted_index++;
            right_index++;
        }
    }

    return sorted_array;
}


// BUBBLE SORT
static int[] BubbleSort(int[] array)
{
    for (int i = 0; i < array.Length - 1; i++)
    {
        for (int j = 0; j < array.Length - i - 1; j++)
        {
            if (array[j] > array[j+1])
            {
                var temp = array[j];

                array[j] = array[j+1];
                array[j+1] = temp;
            }
        }
    }

    return array;
}



for (int i = 0; i <= 5; i++)
{
    var numbers = GenerateUniqueNumbers(10);
    Console.WriteLine($" ");
    Console.WriteLine($"- Unsorted : [{string.Join(", ", numbers)}]");
    Console.WriteLine($"- My Sort  : [{string.Join(", ", BubbleSort(numbers))}]");
    Console.WriteLine($"- C# Sort  : [{string.Join(", ", numbers.Order())}]");
    Console.WriteLine($" ");
}
