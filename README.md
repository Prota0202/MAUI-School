# MAUI-School

## Vue d'Ensemble
MAUI-School est une application MAUI conçue pour faciliter la gestion des écoles. Elle permet de suivre les activités, les évaluations, les étudiants et les enseignants à travers une interface utilisateur intuitive.

## Fonctionnalités
- **Gestion des Activités :** Créez et gérez les activités scolaires tout en attribuant des crédits ECTS.
- **Gestion des Bulletins :** Générez et consultez les bulletins des étudiants.
- **Gestion des Évaluations :** Saisissez et analysez les évaluations des étudiants pour différentes activités.
- **Gestion des Étudiants :** Ajoutez et gérez les informations des étudiants.
- **Gestion des Enseignants :** Enregistrez et gérez les détails des enseignants, y compris les salaires.

## Principe SOLID
Notre application respecte les principes SOLID pour assurer une architecture logicielle robuste et maintenable :
- **Single Responsibility (SRP) :** Ce principe stipule qu'une classe ne devrait avoir qu'une seule raison de changer, c'est-à-dire qu'elle devrait faire une seule chose. Dans notre application, chaque page (comme "TeachersPage", "ActivitiesPage", etc.) a sa propre responsabilité et n'interfère pas avec les responsabilités des autres pages.
- **Open/Closed (OCP) :** Ce principe stipule que les classes devraient être ouvertes à l'extension mais fermées à la modification. Dans notre application, on peut ajouter de nouvelles fonctionnalités ou modifier celles existantes en créant de nouvelles pages ou en modifiant celles existantes sans affecter la structure globale de l'application.
- **Liskov Substitution :** Les sous-classes peuvent être échangées sans perturber les fonctionnalités de l'application.
- **Interface Segregation :** Les interfaces sont spécifiquement définies pour les besoins des utilisateurs de l'API.
- **Dependency Inversion :** Les dépendances dans l'application s'appuient sur des abstractions plutôt que sur des concrétisations.

## Architecture et Conception

### Diagrammes de Séquences
Les diagrammes de séquences fournissent une vue dynamique de l'application, illustrant comment les objets interagissent en termes de séquence de messages. Voici les diagrammes de séquences pour les principales fonctionnalités de MAUI-School :

- **Diagramme de Séquence pour la Page des Activités** : Ce diagramme montre le flux d'interactions lors de la création d'une nouvelle activité scolaire.
- **Diagramme de Séquence pour la Page des Bulletins** : Ce diagramme détaille les étapes de génération des bulletins des étudiants.
- **Diagramme de Séquence pour la Page des Évaluations** : Il décrit la procédure d'ajout et de validation des évaluations des étudiants.
- **Diagramme de Séquence pour la Page des Étudiants** : Ce diagramme illustre le processus d'ajout d'un nouvel étudiant à la base de données.
- **Diagramme de Séquence pour la Page des Enseignants** : Il explique comment les détails d'un nouvel enseignant sont saisis et validés.

Ces diagrammes assurent que chaque action est bien définie et se déroule dans l'ordre prévu, en conformité avec les principes SOLID de notre architecture logicielle.

![activity](https://github.com/Prota0202/MAUI-School/assets/153845537/00d75c62-dc9b-446d-968c-488c1e36eaad)
![bulletin](https://github.com/Prota0202/MAUI-School/assets/153845537/9f32ff8c-fffd-4437-b259-cb009834b530)
![evaluation](https://github.com/Prota0202/MAUI-School/assets/153845537/e478cbd7-3884-4e22-8fd6-cdaead59e1b0)
![student](https://github.com/Prota0202/MAUI-School/assets/153845537/964e302a-b6cc-41a4-a36a-dfc4fe9c3428)
![teacher](https://github.com/Prota0202/MAUI-School/assets/153845537/d0e0a9d3-7d35-4d3d-806a-6492c0fce059)

### Diagrammes de Classes
Le diagramme de classes offre une vue statique de l'application, représentant les objets et les relations entre eux. Voici notre diagramme de classes :

- **Diagramme de Classes de MAUI-School** : Ce diagramme présente la structure des classes, y compris les attributs et les méthodes, ainsi que les relations d'héritage, d'association et d'agrégation.

Ces diagrammes de classes sont essentiels pour comprendre la structure sous-jacente de l'application et pour assurer que les principes de conception sont suivis de manière cohérente.

![diagramm class](https://github.com/Prota0202/MAUI-School/assets/153845537/ac445575-6822-407d-b2ad-abe81fc77dd6)

Pour visualiser les diagrammes de maniere plus claire, veuillez consulter les fichiers joints dans le répertoire du projet.

## Démarrage Rapide
### Prérequis
- .NET MAUI (version spécifique)
- IDE compatible (par exemple, Visual Studio, Rider,...)

### Installation
1. Clonez le dépôt GitHub.
2. Ouvrez le projet dans votre IDE.
3. Restaurez les packages NuGet nécessaires.
4. Exécutez l'application.

## Utilisation Détaillée

### Page des Activités
- **Accès :** Sélectionnez 'Activités' dans le menu principal.
- **Fonctionnalités :**
  - **Créer une activité :** Cliquez sur 'Créer une Activité', renseignez les informations requises, notamment les ECTS, et sélectionnez l'enseignant responsable.
  - **Validation :** L'application vérifie la validité des ECTS et si l'enseignant est sélectionné.
  - **Gestion des Erreurs :** Des alertes s'affichent pour guider l'utilisateur en cas de données invalides ou manquantes.
  - **Sauvegarde :** Les activités créées sont enregistrées dans la base de données.

### Page des Bulletins
- **Accès :** Allez sur la page 'Bulletins'.
- **Génération des Bulletins :** Cliquez sur 'Générer Bulletins'. L'application charge les évaluations des étudiants, vérifie les données, et génère des bulletins.
- **Vérification :** L'application contrôle si la liste des étudiants est vide avant de procéder.
- **Résultat :** Les bulletins générés sont sauvegardés et un message de confirmation est affiché.

### Page des Évaluations
- **Accès :** Choisissez 'Évaluations' depuis le menu.
- **Ajout d'Évaluations :** Remplissez les informations requises pour chaque évaluation. Sélectionnez l'étudiant, l'activité, et le type d'évaluation.
- **Validation :** L'application s'assure que toutes les informations sont remplies et correctes.
- **Sauvegarde :** Les évaluations sont ajoutées à la base de données après confirmation.

### Page des Étudiants
- **Accès :** Sélectionnez 'Étudiants' dans le menu.
- **Ajout d'Étudiants :** Utilisez le formulaire pour entrer les informations des étudiants.
- **Vérification et Erreurs :** L'application vérifie l'unicité des informations de l'étudiant avant de confirmer l'ajout.
- **Mise à Jour :** La liste des étudiants est mise à jour en temps réel.

### Page des Enseignants
- **Accès :** Cliquez sur 'Enseignants' dans le menu principal.
- **Ajout d'Enseignants :** Remplissez les champs nécessaires, y compris le salaire.
- **Validation :** L'application s'assure que le salaire est un nombre et que l'enseignant n'existe pas déjà.
- **Enregistrement :** Les informations sont sauvegardées dans la base de données.

### Génération de fichiers 
Bien vérifié où seront générer vos bulletins !

![Capture](https://github.com/Prota0202/MAUI-School/assets/153845537/71e9d47c-d877-4558-aff8-5ab4bc3f2b84)

## Architecture et Conception
Les diagrammes de séquence ci-joints offrent une vue détaillée de l'interaction entre l'utilisateur, les différentes pages de l'application, et les composants backend. Ils illustrent également comment l'application respecte les principes SOLID pour une conception robuste et maintenable.

## Licence
Ce projet est sous licence MIT. Voir le fichier `LICENSE` pour plus d'informations.

## Contact
Pour toute question ou support, veuillez contacter 20369@ecam.be (Lababidi).

## Discussion
Pour un chat direct depuis GitHub allez dans la section  `DISCUSSIONS`.
