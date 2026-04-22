using UnityEngine;

public class TestCommandPattern : MonoBehaviour
{

    public void MouseInterface()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Color RandomColor = new(Random.value, Random.value, Random.value);

                new CubeClickCommand(hit.transform.gameObject, RandomColor);
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MouseInterface();
    }
}