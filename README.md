# AutoFact

**AutoFact** est une application Windows Forms développée en C# (.NET 8) destinée aux **autoentrepreneurs**. Elle permet de générer facilement des **factures pré-remplies** et de gérer l’ensemble de leur activité administrative.

---

## 🧾 Fonctionnalités

- 💼 **Génération automatique de factures** personnalisées et prêtes à l’envoi
- 📇 **Gestion des clients, fournisseurs, articles et services**
- 🏢 **Paramétrage complet de votre société** depuis l’interface (nom, SIRET, coordonnées…)
- 🧪 **Base de données de test** fournie à l’installation pour essayer immédiatement l'application *(supprimable à tout moment)*

---

## 🛠️ Installation

L’application est fournie avec un **installateur `.msi`** via un projet *Windows Setup Project* sous Visual Studio.

👉 [Télécharger AutoFactSetup.msi](./AutoFactSetup.msi)

Cliquez sur le lien ci-dessus pour télécharger l'installateur officiel de l'application.

### Étapes :

1. Ouvrez le dossier contenant le fichier `AutoFact.msi`
2. Double-cliquez sur `AutoFact.msi` pour lancer l’installation
3. Suivez les instructions de l’assistant

> 📁 Un raccourci sera ajouté dans le menu Démarrer et au Bureau une fois l'installation terminée.

---

## 📂 Structure de l'installation

- `AutoFact.exe` : Application principale
- `DBAutoFact.db` : Base de données SQLite intégrée avec des **données de démonstration**
- `.dll` : Dépendances (Xceed, Newtonsoft, SQLite…)

---

## 💡 Conseils d'utilisation

- Accédez aux paramètres de votre société via le bouton **"Paramètres"** dans le menu principal.
- Supprimez ou modifiez les données de test à tout moment.
- L’application fonctionne en local, aucune connexion internet n’est requise.

---

## 📝 Licence

Ce projet est sous licence **MIT**. Vous êtes libre de l’utiliser, le modifier et le distribuer.

---

## 👤 Auteur

Développé par TwinTech