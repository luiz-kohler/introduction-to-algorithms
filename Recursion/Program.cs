using System.Net.Http.Headers;

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

// MERGE SORT

static List<int> MergeSort(List<int> unsortedList)
{
    if (unsortedList.Count < 2)
        return unsortedList;

    var mid = (unsortedList.Count - 1) / 2;

    var leftList = unsortedList.Where((item, index) => index <= mid).ToList();
    var rightList = unsortedList.Where((item, index) => index > mid).ToList();

    leftList = MergeSort(leftList);
    rightList = MergeSort(rightList);

    return Merge(leftList, rightList);
}

static List<int> Merge(List<int> leftList, List<int> rightList)
{
    var sortedList = new List<int>();
    
    while(leftList.Count > 0 || rightList.Count > 0)
    {
        if(leftList.Count > 0 && rightList.Count > 0)
        {
            if (leftList[0] <= rightList[0])
            {
                sortedList.Add(leftList[0]);
                leftList.RemoveAt(0);
            }
            else if (rightList[0] <= leftList[0])
            {
                sortedList.Add(rightList[0]);
                rightList.RemoveAt(0);
            }
        }

        else if (leftList.Count > 0 && rightList.Count == 0)
        {
            sortedList.Add(leftList[0]);
            leftList.RemoveAt(0);
        }

        else if (rightList.Count > 0 && leftList.Count == 0)
        {
            sortedList.Add(rightList[0]);
            rightList.RemoveAt(0);
        }
    }

    return sortedList;
}