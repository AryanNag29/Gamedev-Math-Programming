using System;
using UnityEngine;

//if you include interface type icommand now you have to implement the function included in 'Interface Icommand'
public class CubeClickCommand : MonoBehaviour,Icommand
{
    //object of class gameObject and mesh renderer
    private GameObject _cube;
    private MeshRenderer _renderer;

    public CommandManager _CommandManager;
    //these are variable of type color
    private Color newColor;
    private Color prevColor;
    
    
    public CubeClickCommand(GameObject cube, Color newColor)
    {
        _renderer = cube.GetComponent<MeshRenderer>();
        newColor = newColor;

        if (_renderer != null)
        {
            prevColor = _renderer.material.color;
        
            // Only call the manager if it definitely exists
            if (CommandManager.Instance != null)
            {
                CommandManager.Instance.AddCommand(this);
            }
        }
    }

    public void Execute()
    {
        //assign new color to the material
        _renderer.material.color = newColor;
    }

    public void Undo()
    {
        //assign prev color to the material whenever undo is clicked
        _renderer.material.color = prevColor;
    }

    public void Start()
    {
        _CommandManager = GetComponent<CommandManager>();
    }
}
