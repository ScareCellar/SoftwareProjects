using UnityEngine;

namespace RealAssets.InventorySystem
{
    public class CurrentlySelected : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }

        public void Move(Vector3 newPosition)
        {
            transform.position = newPosition;
        }
    }
}
