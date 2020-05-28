using UnityEngine;

namespace Bucky
{
    public class PlayerDialogueHandler : MonoBehaviour
    {

        public ShootingSystem shootingSystem;

        public PlayerMechanic playerMechanic;

        private DialogueManager dm;

        // Start is called before the first frame update
        void Start()
        {
            shootingSystem = GetComponent<ShootingSystem>();
            playerMechanic = GetComponent<PlayerMechanic>();
            dm = FindObjectOfType<DialogueManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (dm.started)
            {
                setStateForComponents(false);
            }
            else
            {
                setStateForComponents(true);
            }
        }

        void setStateForComponents(bool state)
        {
            shootingSystem.enabled = state;
            playerMechanic.enabled = state;
        }
    }
}
