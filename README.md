## MAUI-School

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

## Architecture et Conception
Les diagrammes de séquence ci-joints offrent une vue détaillée de l'interaction entre l'utilisateur, les différentes pages de l'application, et les composants backend. Ils illustrent également comment l'application respecte les principes SOLID pour une conception robuste et maintenable.

## Licence
Ce projet est sous licence MIT. Voir le fichier `LICENSE` pour plus d'informations.

## Contact
Pour toute question ou support, veuillez contacter Lababidi Abdelbadi.

## Discussion
Pour un chat direct depuis GitHub allez dans la section  `DISCUSSIONS`.
