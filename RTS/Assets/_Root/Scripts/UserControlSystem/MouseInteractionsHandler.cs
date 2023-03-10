using Abstractions;
using System.Linq;
using UnityEngine;

namespace UserControlSystem
{
    public class MouseInteractionsHandler : MonoBehaviour
    {
        [SerializeField] private Camera _camera;


        private void Update()
        {
            if (!Input.GetMouseButtonUp(0))
                return;

            var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));

            if (hits.Length == 0)
                return;

            var mainBuilding = hits
                .Select(hit => hit.collider.GetComponentInParent<IUnitProducer>())
                .Where(c => c != null)
                .FirstOrDefault();

            if (mainBuilding == default)
                return;

            mainBuilding.ProduceUnit();
        }
    }
}