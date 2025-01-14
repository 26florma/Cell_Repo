using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> AllSpawners = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        AllSpawners = GameObject.FindGameObjectsWithTag("spawner").ToList();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < AllSpawners.Count; i++)
        {
            Spawner Spawner = AllSpawners[i].GetComponent<Spawner>();
            if (AllSpawners != null)
            {
                Spawner.waveEnd = false;
            }
        }
    }
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime;

public class SpawnManager : MonoBehaviour
{
   public bool mutations = false;
   public int mutationCount = 3;
   public list<AllPathogens>
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
     AllPathogens = GameObject.FindGameObjectsWithTag("germ").ToList();
     for(mutationCount > 0, mutationCount--)
        {
            int mutaion = UnityEngine.Random.Range(0,AllPathogens)
            int MutationBuff = UnityEngine.Random.Range(1,4)
            if (AllPathogens != null)
            {
                GermMovement MutationTarget = AllPathogens[mutation].GetComponent<GermMovement>();
            }
            Switch(MutationTarget)
            {
                case 1:
                MutationTarget.germHP +=1
                break;
                case 2:
                MutationTarget.germD +=1;
                break 3;
                case
                MutationTarget.movementSpeed +=1;
                break;
                case 4:
                MutationTarget.germAttackSpeed +=1;
                break;
                defualt:
                Debug.Log("error");
                break; 
            }
        }
       
        
    }
 }
    */
}
