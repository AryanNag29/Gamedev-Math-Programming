using UnityEngine;

public class CubeClickCommand : Icommand
{
    //object of class gameObject and mesh renderer
    private GameObject _cube;
    private MeshRenderer _renderer;
    
    //these are variable of type color
    private Color newColor;
    private Color prevColor;
    
    
    public CubeClickCommand(GameObject cube, Color newColor)
    {
        //assigns the input parameter 'Cube' to the instance property 'This.cube'
        this._cube = cube;
        _renderer = cube.GetComponent<MeshRenderer>();

        prevColor = _renderer.material.color;
        this.newColor = newColor;
    }

    public void Execute()
    {
        _renderer.material.color = newColor;
    }

    public void Undo()
    {
        _renderer.material.color = prevColor;
    }
}
