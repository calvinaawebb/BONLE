using System.Collections;

public class GraphNode
{
    //The Future Update
    private string _name;
    private ArrayList _parents;
    private ArrayList _children;

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

    public void AddConnection(GraphNode node)
    {
        this._children.Add(node);
        node._children.Add(this);
    }
}