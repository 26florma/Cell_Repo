using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime;

public class GameManager : MonoBehaviour
{
    public bool mutations = false;
    public int mutationCount = 3;
    public List<GameObject> AllPathogens = new List<GameObject>();
    void Update()
    {
        AllPathogens = GameObject.FindGameObjectsWithTag("germ").ToList();
        for (int i = mutationCount; mutationCount > 0; mutationCount-= 1)
        {
            int mutation = UnityEngine.Random.Range(0, AllPathogens[]);
            int MutationBuff = UnityEngine.Random.Range(1, 4);
            if (AllPathogens != null)
            {
                GermMovement MutationTarget = AllPathogens[mutation].GetComponent<GermMovement>();

                Switch(MutationTarget)
               {
                case 1:
                MutationTarget.germHP += 1;
                    break;
                case 2:
                MutationTarget.germD += 1;
                    break;
                case 3:
                MutationTarget.movementSpeed += 1;
                    break;
                case 4:
                MutationTarget.germAttackSpeed += 1;
                    break;
                    default:
                Debug.Log("error");
                    break;
                }
            }
        }


    }
}