using UnityEngine; //Importation de module unity

public class PlayerMovement : MonoBehaviour
{
    //Les variables de type public sont modifiables directement depuis unity (ce qui est pratique pour une variable de type sprite ou gameobject)
    public float moveSpeed;
    public float jumpForce;
    private int jumpLeft;
    public static int jumpNumber = 0; // On définit le saut à 0 car lorsque l'on commence à sauter, le test isGrounded est vrai donc le jeu nous redonne un saut

    //Si une variable n'est pas destinée à être ajustée alors on va la mettre en private
    private bool isJumping;
    public bool isGrounded;

    //Les variables de type Transform, RigidBody2D, Animator etc... sont des variables propres à unity. Elles sont ce qu'on appelle des component
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;//Définis une variable de type vecteur avec pour coordonnée(0;0;0)
    private float horizontalMovement;

    //La fonction Update se répète en boucle elle peut être comparée à la fonction FixedUpdate, la différence est subtile
    //mais ce qu'il faut retenir c'est qu'il faut utiliser FixedUpdate pour les éléments d'unity tels que des RigidBody
    void Update()
    {
        if (Input.GetButtonDown("Jump")) // "Jump" est définie de base sur la touche espace sur unity
        {
            if (jumpLeft > 0 || isGrounded)
            {
                isJumping = true;
                jumpLeft -= 1;
            }
            
        }

        if (isGrounded == true)
        {
            jumpLeft = jumpNumber;
        }

        Flip(rb.velocity.x);//Appelle la fonction flip

        float characterVelocity = Mathf.Abs(rb.velocity.x);/*Déclare une variable tel que la valeure absolue de la vélocité du rigibody sur l'axe x (l'utilité est d'avoir une valeur positive pour
        tester si elle est supérieure à 0.03 pour déclencher l'animation*/
        animator.SetFloat("Speed", characterVelocity);//Cette ligne à mettre la variable "Speed" dans l'animator à la valeure de "characterVelocity"
    }

    void FixedUpdate()
    {
        /*Physics2D.OverlapCircle renvoie une valeur true ou false en testant des collisions d'un cercle
        groundCheck.position: définis le point à partit duquel le cercle va se former
        groundCheckRadius: définis le rayon du cercle
        collisionLayers: définis quels layers vont être pris en compte, ici on va prendre en compte uniquement les layers "collisionLayers"
        */
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        
        /*
        Input sert à récupérer une valeur entrée par l'utilisateur
        la valeur récupérée est l'axe Horizontal: sur unity il y a plusieurs axes définis de base, ici on a choisis l'axe Horizontal qui retourne -1 pour q et 1 pour d
        la valeur est unitaire, elle est donc ensuite multipliée par la variable moveSpeed et pars l'interval de temps sur lequel les touches sont pressées
        */
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        //Appelle la fonction MovePlayer
        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        //@param: une variable float correspondant à la valeur du mouvement horizontal

        //Créer un vecteur targetVelocity de type Vector2(en 2D, avec deux coordonnées x et y) avec en coordonnée x la valeur du mouvement horizontal et en valeur y la valeur
        //actuelle du rigidbody du joueur (l'idée est de ne pas changer la hauteur du personnage puisqu'on effectue un mouvement uniquement horizontal)
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);

        //définis la vélocité du rigidbody avec une méthode SmoothDamp(qui sert à effectuer un "déplacement lisse" depuis un Vecteur qui a pour paramètre:
        //rb.velocity: la position actuelle du rigibbody
        //targetVelocity: la position ciblée définie la ligne d'au dessus
        //ref velocity: La vitesse actuelle
        //0.05f: le temps du déplacement
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);

        if (isJumping == true)
        {
            //AddForce sert à ajouter une force, en l'occurence à notre rigidbody sous un Vector2 (2D)
            //coordonnée x: 0 puisque l'on cherche à déplacer le joueur verticalement
            //coordonnée y: jumpForce(variable de type float qu'on définis depuis unity)
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocity)
    {
        //@param la vélocité x du joueur
        //Test si la vélocité est positive ou négative pour orienter le sprite du personnage à gauche ou à droite
        //positive: ne retourne pas le sprite du joueur sur l'axe x
        //negative: retourne le sprite du joueur sur l'axe x
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        //cette fonction sert uniquement à dessiner un cercle rouge visible depuis unity (cercle qui définis isGrouded
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}