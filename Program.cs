using System;
using System.Collections;

namespace iterator
{
  internal class Program
  {
    static void Main(string[] args)
    {
      MyCollection collection = new MyCollection();
      collection.Add("Первый");
      collection.Add("Второй");
      collection.Add("Третий");

      IIterator iterator = collection.GetIterator();

      while (iterator.HasNext())
      {
        Console.WriteLine(iterator.Next());
      }
    }
  }

  public interface IIterator
  {
    bool HasNext();
    object Next();
  }

  public interface IAggregate
  {
    IIterator GetIterator();
  }

  public class MyCollection : IAggregate
  {
    private ArrayList items = new ArrayList();

    public void Add(object item)
    {
      items.Add(item);
    }

    public IIterator GetIterator()
    {
      return new MyIterator(this);
    }

    public int Count()
    {
      return items.Count;
    }

    public object Get(int index)
    {
      return items[index];
    }
  }
  public class MyIterator : IIterator
  {
    private MyCollection collection;
    private int position = 0;

    public MyIterator(MyCollection collection)
    {
      this.collection = collection;
    }

    public bool HasNext()
    {
      return position < collection.Count();
    }

    public object Next()
    {
      return collection.Get(position++);
    }
  }
}
