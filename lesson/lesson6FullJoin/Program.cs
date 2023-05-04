var persons = new List<Person>
{
    new Person {Name = "Alexey",City = "Moscow"},
    new Person {Name = "Vladimir",City = "St. Peterburg"},
    new Person {Name = "Sergey",City = "Vladimir"},
};
var weathers = new List<Weathers>
{
    new Weathers {Now = "Solar", City = "Moscow"},
    new Weathers {Now = "Rainy", City = "Tallin"},
};
var join = persons.FullJoin(weathers, x => x.City, y => y.City, (first, second, id) => new { id, first, second });
foreach (var j in join)
{
    Console.WriteLine($"{j.first?.Name ?? "NULL"} | {j.id} | {j.second?.Now ?? "NULL"}");
}
public static class ExtensionMethodFullJoin
{
    public static IEnumerable<TResult> FullJoin<T1, T2, T3, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, Func<T1, T3> field1, Func<T2, T3> field2, Func<T1, T2, int, TResult> result)
    {
        if (first == null) throw new ArgumentNullException(nameof(first));
        if (second == null) throw new ArgumentNullException(nameof(second));
        if (field1 == null) throw new ArgumentNullException(nameof(field1));
        if (field2 == null) throw new ArgumentNullException(nameof(field2));
        if (result == null) throw new ArgumentNullException(nameof(result));
        int i = 0;
        var hashSet1 = new HashSet<T3>(first.Select(field1));
        var hashSet2 = new HashSet<T3>(second.Select(field2));

        var lookup1 = first.ToLookup(field1);
        var lookup2 = second.ToLookup(field2);

        var keys = hashSet1.Union(hashSet2);

        foreach (var key in keys)
        {
            var values1 = lookup1[key].DefaultIfEmpty();
            var values2 = lookup2[key].DefaultIfEmpty();

            foreach (var value1 in values1)
            {
                foreach (var value2 in values2)
                {
                    yield return result(value1, value2, i++);
                }
            }
        }
    }
}
public class Person
{
    public string Name { get; set; }
    public string City { get; set; }
};
public class Weathers
{ 
    public string Now { get; set; }
    public string City { get; set; }
};
