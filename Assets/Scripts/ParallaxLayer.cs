using UnityEngine;
public class ParallaxLayer : MonoBehaviour
{
    [SerializeField] private float baseSpeed = 0.5f;
    [SerializeField] private float depthSensitivity = 0.1f;

    private Material material;
    private float offset;
    private Vector3 posInicial;

    void Start()
    {

        // cria instancia de material
        Renderer renderer = GetComponent<Renderer>(); //pega renderer e material do gameobj (quad)
        material = new Material(renderer.material);
        renderer.material = material;
        posInicial = transform.position; //pos inicial do quad para referencia
    }

    void FixedUpdate()
    {
        UpdateParallaxMovement();
    }

    void UpdateParallaxMovement()
    {
        // calcula distância baseada na posição z do squad
        float zDepth = Mathf.Abs(posInicial.z);
        float depthFactor = 1 / (zDepth * depthSensitivity); // distancia de z influencia no offset 

        // Update texture offset
        offset += baseSpeed * depthFactor * Time.deltaTime;
        material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
} //ideia para possível pesquisa  : pai background controlar baseSpeed e depthSensitivity por inspector, 
  // e o pai ter acesso ao array dos quads com os materials , nao necessitando de que cada quad tenha o script