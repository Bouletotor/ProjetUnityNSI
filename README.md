# ProjetUnityNSI


## A Propos du Projet : 

Le but était d'apprendre les bases de Unity et du C# en créant une ébauche de platformer 2D. Il est composé d'un seul niveau tutoriel qui navigue entre plusieurs scènes.
Vous y trouverez des ennemis, un système de saut où l'on peut modifier le nombre de saut, un système permettant de replacer le joueur lorsqu'il fait une chute, un système de points de vie, un système de changement de scène ainsi que de nombreuses animations et de petits tutoriels.
Le projet est une sorte de démo, cela implique qu'il n'y a pas de système de sauvegarde, pas de menu d'accueil et de pause et qu'il n'y a pas grand chose à faire. C'est plus une démonstration de ce que l'on a pu faire qu'un jeu à proprement parler.


## A Propos de Unity : 

Dans les scripts, vous trouverez beaucoup de variables de type "components" mais aussi des lignes de codes du type "collision.gameObject" par exemple.
Les components sont des élements de Unity permettant d'associer des fonctionnalités à des objets. Par exemple, ils permettent d'appliquer un rendu et des animations à un objet ou encore de lier un script à un objet.

#### Différents components que vous pourrez retrouver :

- Transform : propriétés de l'objet relatives à sa position, sa rotation et son échelle
- SpriteRenderer : propriétés de l'objet relatives à son redu (sa couleur, ses sprites, etc...)
- RigidBody : propriétés de l'objet relatives à sa physique (gravité, masse, etc...)
- Animator : propriétés de l'objet relatives à ses sprites et ses animations
- Slider : propriétés de l'objet relatives au remplissage d'un rectangle (permet de modifier le remplissage de la barre de vie)
- Text : propriétés de l'objet relatives au texte à afficher (sa couleur, sa police, sa taille, etc...)
- Collider : propriétés de l'objet relatives au boîte de collisions

#### Aussi, pour récuperer des données d'autres objets que celui lié au script, plusieurs méthode existe. Ici, on en a utilisé trois : 

- GameObject.FindGameObjectWithTag("Tag") : permettant de récupérer l'objet ayant le tag indiqué
- GameObject.FindGameObjectWithName("Name") : permettant de récupérer l'objet ayant le nom indiqué
- method.GameObject : permettant de récupérer l'objet en lien avec l'objet actuel via une méthod, par exemple "collision.GameObject" ou "parent.GameObject"

#### Enfin, il y a différents types de fonction, voici celle que nous avons utilisé :

- Update() : fonction appelée chaque frame
- FixedUpdate() : fonction appelée tout les 50èmes de secondes (calibrée sur la fréquence de test des physiques dans Unity)
- Start() : fonction appelée au lancement du programme
- Awake() : fonction appelée quand le script est utilisé
- IEnumerator "Coroutine"() : fonction particulière qui n'est pas interrompue mais mise en pause contrairement à une routine qui elle, se termine

Un ScriptableObject est un conteneur de données qui est utilisé pour enregistrer de grandes quantités de données, indépendamment des instances de classe. L’un des principaux cas d’utilisation de ScriptableObjects est de réduire l’utilisation de la mémoire de votre projet en évitant les copies de valeurs.


## Quelques indications en jeu : 

Le PNJ vous donne un objet qui est bien présent dans l'inventaire du Joueur et qui ajoute un saut après son obtention mais qui n'est pas visible à travers le jeu. Par manque de temps, nous n'avons pas eu le temps de faire une interface permettant d'afficher l'inventaire. 
Pour ce qui est du système de points de vie, nous n'avons pas non plus eu le temps de faire mourir le joueur car cela venait poser problème au niveau de la mort des ennemis, en effet, nous les faisons mourir d'une manière peu orthodoxe : nous les détruisons ! Cela rend donc leur réapparition compliquée si le joueur venait à mourir même si en soi, le faire mourir n'est pas très complique, il suffirait de tester si le joueur à moins de 0 ou 0 PV.


## A propos des fichiers :

Ci-joint, vous trouverez une première version du jeu en .exe, l'executable qui vous permettra de jouer au jeu comfortablement, dans le fichier "Projet", vous trouverez la version que nous avons développé sous la forme du projet Unity, pour voir nos scripts, il vous faudra aller dans Assets > Scripts, seul les fichier .cs sont importants et non les .cs.meta. 


## Liens et autres :

Pour ce qui est des graphismes, Gabin a cree une sprite (et animations) : le PNJ. Pour ce qui est du reste, nous avons surtout pris cette tilesheet :
https://opengameart.org/content/a-platformer-in-the-forest


Merci d'avoir lu ce README et à bientôt !