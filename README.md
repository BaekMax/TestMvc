# Description des couches:  
### Core
Noyau en style fonctionnel, ne se connecte pas à une base de données récupère des données en dur
### Test
Les tests unitaires des commandes core
### Service
La fameuse couche "Helpers" ! Mais en réalité c'est là que l'on doit mettre les factory ou autre
### LegacyClient
Une application console qui vaut ce qu'elle vaut
### Web
La partie à implémenter

# Le test
1. Cloner ce repository
2. Effectuer la refonte du client Legacy en Web.

```
L'idée est de faire un formulaire en plusieurs étape à partir du résultat de la commande:
var fundraiser = new GetFundraiserCommand().GetFundraiser(organismReference, fundraiserReference);

Etape 1 sélection du montant:
Demander le choix du tarif parmis ceux du fundraiser: fundraiser.ActionOptionsList

Etape 2 coordonnés et information complémentaire:
Demander à minima le nom, prénom et si nécessaire pour le tarif choisi à l'étape suivante les informations supplémentaires: fundraiser.ActionOptionsList.DynamicInfos

Etape 3 récapitulatif:
Afficher à l'utilisateur le montant qu'il s'apprete à payer et pourquoi pas une proposition de pourboire !

Etape 4 validation:
Afficher une page avec tout ce que l'utilisateur à saisie
```

3. bonus:
* styler l'implémentation
* solution innovante pour gérer les étapes (one page, ...)

4. Pusher tout le travail sur une nouvelle branche et faire une pull-request



