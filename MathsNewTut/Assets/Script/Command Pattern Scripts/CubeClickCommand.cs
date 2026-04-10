using UnityEngine;

//if you include interface type icommand now you have to implement the function included in 'Interface Icommand'
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
        this.newColor = newColor; // same for this 
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
}
