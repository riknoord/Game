using UnityEngine;
using System.Collections;

public class WorldVegetationManager : MonoBehaviour {

    private float width = 250f;
    private float height = 250f;

    private int maxNodes = 20;

    private TreeNode[] treeNodes;

    public GameObject TreePrefab;

    public float Width
    {
        get
        {
            return width;
        }
    }

    public float Height
    {
        get
        {
            return height;
        }
    }

    // Use this for initialization
    void Start () {
        CreateTreeNodes();
	}

    private void CreateTreeNodes()
    {
        treeNodes = new TreeNode[maxNodes];

        for (int i = 0; i < maxNodes; i++)
        {
            treeNodes[i] = new TreeNode(this,new Vector3(Random.Range(0, width), 0f, Random.Range(0, height)),Random.Range(25,75));
            treeNodes[i].CreateTrees(TreePrefab);
        }
    }

    public GameObject findClosest(GameObject finder)
    {
        TreeNode closest = null;


        foreach (TreeNode node in treeNodes)
        {
            if(closest == null || node.distance(finder) < closest.distance(finder))
            {
                closest = node;
            }
        }

        if (closest == null) return null;

        return closest.findClosestTree(finder);
    }
}
