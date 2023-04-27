Console.WriteLine((C.B).ToString("D"));//1
Console.WriteLine((C.C2).ToString("D"));//2
Console.WriteLine((C.C1).ToString("D"));//1
Console.WriteLine((C.C3).ToString("D"));//2
Console.WriteLine((C.C4).ToString("D"));//3

enum C
{
    B = 1,
    C2,
    C1 = 1,
    C3,
    C4,
};

