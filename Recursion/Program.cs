int CalculateFactorial(int number) => number != 1 ? number * CalculateFactorial(number-1) : 1;

static int SumOfDigits(int number, int index = 0)
{
    var numSize = number.ToString().Length;

    if (numSize == index)
        return 0;

    var arr = number.ToString()
        .Select(x => int.Parse(x.ToString()))
        .ToArray();

    var numToSum = arr[index];

    return numToSum + SumOfDigits(number, index+1);
}

static int SumOfDigits_V2(int n)
{
    if (n < 10)
        return n;

    var n_rest_of_number_divided_by_10 = n % 10;
    var n_divided_by_10 = n / 10;

    return n_rest_of_number_divided_by_10 + SumOfDigits_V2(n_divided_by_10);
}

static int GetHighestValue(int[] arr)
{
    if(arr.Length == 0) return 0;

    return 0;
}