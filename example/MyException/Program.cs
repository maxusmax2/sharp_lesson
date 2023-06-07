A b  = new B();
b.Do();
b.Do2();
b.Do3();
abstract class A
{
    public virtual void Do() { Console.WriteLine("A"); }
    public  void Do2() { Console.WriteLine("A"); }
    public abstract void Do3();

}
class B : A 
{
    public override void Do() { Console.WriteLine("B"); }
    public  void Do2() { Console.WriteLine("B"); }
    public  override void Do3() { Console.WriteLine("B"); }
}
