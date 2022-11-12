using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            HealthManager.health--;
            if(HealthManager.health <=0){
                PlayerManager.isGameOver = true;
                AudioManager.instance.Play("GameOver");
                gameObject.SetActive(false);
            }else{
                StartCoroutine(GetHurt());
            }
        }if(collision.transform.tag == "Spikes")
        {
            HealthManager.health=0;
            if(HealthManager.health <=0){
                PlayerManager.isGameOver = true;
                AudioManager.instance.Play("GameOver");
                gameObject.SetActive(false);
            }else{
                StartCoroutine(GetHurt());
            }
        }if(collision.gameObject.CompareTag("LoadGame"))
        {
            SceneManager.LoadScene(1);
        }
    }
    IEnumerator GetHurt(){ 
        Physics2D.IgnoreLayerCollision(6,8);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(4);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6,8, false);
    }
}
