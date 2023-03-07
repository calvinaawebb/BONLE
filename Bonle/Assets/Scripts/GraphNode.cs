using System.Collections;

public class GraphNode
{
    private string _name;
    private ArrayList _parents;
    private ArrayList _children;

    // Basis for my node system that allows me to tell the program which bones are connected and how far they are apart.
    public GraphNode(string name)
    {
        this._name = name;
        this._children = new ArrayList();
    }

    public string Name
    {
        get => this._name;
    }

    public ArrayList Children
    {
        get => this._children;
    }

    // Adding connections between bones.
    public void AddConnection(GraphNode node)
    {
        this._children.Add(node);
        node._children.Add(this);
    }
}