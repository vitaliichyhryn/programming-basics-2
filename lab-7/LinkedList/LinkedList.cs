namespace LinkedList;

public class LinkedList
{
    internal LinkedListNode? Head;

    public LinkedListNode Add(float value)
    {
        var newNode = new LinkedListNode(value);
        if (Head is null)
        {
            Head = newNode;
        }
        else
        {
            var currentNode = Head;
            while (currentNode.Next is not null) currentNode = currentNode.Next;
            currentNode.Next = newNode;
        }
        return newNode;
    }

    public LinkedListNode? Find(float value)
    {
        var currentNode = Head;
        while (currentNode is not null)
        {
            if (currentNode.Value == value) return currentNode;
            currentNode = currentNode.Next;
        }
        return null;
    }

    public LinkedListNode? Find(Func<LinkedListNode, bool> comparator)
    {
        var currentNode = Head;
        while (currentNode is not null)
        {
            if (comparator(currentNode)) return currentNode;
            currentNode = currentNode.Next;
        }
        return null;
    }

    public bool Contains(float value)
    {
        return Find(value) is not null;
    }

    public LinkedList Where(Func<LinkedListNode, bool> comparator)
    {
        var list = new LinkedList();
        var currentNode = Head;
        while (currentNode is not null)
        {
            if (comparator(currentNode)) list.Add(currentNode.Value);
            currentNode = currentNode.Next;
        }
        return list;
    }

    public float Sum()
    {
        var sum = 0f;
        var currentNode = Head;
        while (currentNode is not null)
        {
            sum += currentNode.Value;
            currentNode = currentNode.Next;
        }
        return sum;
    }

    public void Remove(float value)
    {
        var currentNode = Head;
        if (currentNode?.Value == value)
        {
            Head = Head?.Next;
            return;
        }

        while (currentNode is not null)
        {
            if (currentNode.Next?.Value == value)
            {
                currentNode.Next = currentNode.Next.Next;
                return;
            }
            currentNode = currentNode.Next;
        }
    }

    public void RemoveAll(LinkedList list)
    {
        var currentNode = Head;
        while (currentNode is not null)
        {
            if (list.Contains(currentNode.Value))
            {
                Remove(currentNode.Value);
                currentNode = Head;
                continue;
            }
            currentNode = currentNode.Next;
        }
    }

    public static void Print(LinkedList list)
    {
        var currentNode = list.Head;
        Console.Write("{");
        while (currentNode is not null)
        {
            Console.Write(currentNode.Next is null ? $"{currentNode.Value}" : $"{currentNode.Value}, ");
            currentNode = currentNode.Next;
        }
        Console.Write("}\n");
    }
}

public class LinkedListNode
{
    internal LinkedListNode? Next;
    public float Value { get; }

    public LinkedListNode(float value)
    {
        Value = value;
        Next = null;
    }
}