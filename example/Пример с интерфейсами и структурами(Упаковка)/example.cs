﻿using static System.Console;
var a1 = new A
{
    Value = 1,
};//Создаем объект в стеке со значением 1
((IA)a1).Value++;//Упаковываем только что созданный объект и производим на полем упакованного объекта инкремент
// То есть создаем копию объекта в куче и увеличиваем у копии поле на 1, но  не у объекта в стеке
object a2 = a1;// Упаковываем объект a1 и ссылку на объект записываем в а2
((IA)a2).Value++;// У упакованного объекта увеличиваем поле  на 1 упаковки не происходит так как а2 уже упакован

WriteLine(a1.Value);// a1 = 1
WriteLine(((IA)a2).Value);// a2s = 2
public interface IA 
{
    int Value { get; set; }
}

public struct A : IA 
{
     public int Value { get; set; }
}




