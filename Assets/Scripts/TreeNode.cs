using UnityEngine;
using System.Collections;

public class TreeNode {

    private Vector3 Position;
    private int maxTrees;

    private GameObject[] Trees;

    private WorldVegetationManager manager;

    public TreeNode(WorldVegetationManager manager, Vector3 _Position, int _maxTrees)
    {
        this.manager = manager;
        this.Position = _Position;
        this.maxTrees = _maxTrees;
    }

    public void CreateTrees(GameObject _tree)
    {
        Trees = new GameObject[this.maxTrees];

        for (int treecount = 0; treecount < this.maxTrees; treecount++)
        {
            float tree_scale = Random.Range(0.8f, 1.5f);

            GameObject t = (GameObject)GameObject.Instantiate(_tree, randomPosition(), randomRotation());

            t.transform.localScale = new Vector3(tree_scale, tree_scale, tree_scale);
            t.transform.parent = manager.transform;

            Trees[treecount] = t;
        }
    }

    public float distance(GameObject finder)
    {
        return Vector3.Distance(Position,finder.transform.position);
    }

    public GameObject findClosestTree(GameObject finder)
    {
        GameObject closest = null;

        foreach (GameObject Tree in Trees)
        {
            if(
                closest == null || 
                Vector3.Distance(Tree.transform.position, finder.transform.position) < Vector3.Distance(closest.transform.position, finder.transform.position))
            {
                closest = Tree;
            }
        }

        return closest;
    }

    private Vector3 randomPosition()
    {
        float pos_x = Position.x + Random.Range(-25f, 25f);

        if (pos_x > manager.Width)
            pos_x = manager.Width;
        else if (pos_x < 0)
            pos_x = 0;

        float pos_z = Position.z + Random.Range(-25f, 25f);

        if (pos_z > manager.Height)
            pos_z = manager.Height;
        else if (pos_z < 0)
            pos_z = 0;

        return new Vector3(pos_x, 0f, pos_z);
    }

    private Quaternion randomRotation()
    {
        return Quaternion.Euler(new Vector3(0f, Random.Range(0f,360f), 0f));
    }

}
