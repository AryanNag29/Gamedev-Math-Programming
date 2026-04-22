using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

public class CommandManager : MonoBehaviour
{
    private Stack<Icommand> undoStack = new();
    private Stack<Icommand> redoStack = new();
    
    public static CommandManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCommand(Icommand command)
    {
        if (redoStack.Count > 0)
            redoStack.Clear();
        //add to undo Stack
        undoStack.Push(command);
        
        //execute newest command
        command.Execute();
    }

    //undo function store data in stack
    public void UndoCommand()
    {
        //return if ther isn't least 1 command
        if(undoStack.Count <= 0)
            return;
        
        //add the command begin undo to the redo stack
        redoStack.Push(undoStack.Peek());
        
        //undo current command and remove from the undo stack
        undoStack.Pop().Undo();
    }
    //redo funcition store data in stack
    public void RedoCommand()
    {
        if (redoStack.Count <= 0)
            return;
        
        undoStack.Push(redoStack.Peek());
        
        redoStack.Pop().Execute();
    }
    //clear function is to clear undo and redo function stack
    public void ClearCommand()
    {
        undoStack.Clear();
        redoStack.Clear();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
