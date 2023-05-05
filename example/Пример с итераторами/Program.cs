using System.Collections;
using static System.Console;

    var fromOne = iterate(1);

    var fromTwo = iterate(2);
    var fromThree = iterate(3);
    WriteLine(string.Join(',', fromThree.Take(4)));
    var fromFour = iterate(4);
    WriteLine(fromFour.Count());

IEnumerable<int> iterate(int startingValue)
{
    if (startingValue is 2 or 5)
    {
        throw new ArgumentException("Starting from 2 or 5 is not allowed");
    }
    return internalIterate(startingValue);
    
}
IEnumerable<int> internalIterate(int startingValue)
{
    while (true) 
    {
        yield return startingValue;
    }

}
