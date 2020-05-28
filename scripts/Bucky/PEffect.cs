
using UnityEngine;
[System.Serializable]
public class PEffect
{
    public string name;
    public ParticleSystem particle;
    public Transform spawnPoint;

    public void play(float direction = 0)
    {
        var p =  MonoBehaviour.Instantiate(particle, spawnPoint.position, Quaternion.identity);
        if (direction == 1)
        {
            p.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
    
}
