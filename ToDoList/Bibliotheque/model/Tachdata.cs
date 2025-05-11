namespace Bibliotheque.model
{
    /// <summary>
    /// Classe représentant une tâche avec ses propriétés et méthodes associées
    /// Implémente IComparable pour permettre le tri des tâches
    /// </summary>
    public class Tachdata : IComparable<Tachdata>
    {
        private int _id;
        private string? _titre;
        private string? _description;
        private Priorite? _priorite;
        private bool? _status;
        private DateOnly? _createdAt;

        /// <summary>
        /// Constructeur pour créer une nouvelle tâche
        /// </summary>
        /// <param name="titre">Titre de la tâche (non null)</param>
        /// <param name="description">Description de la tâche</param>
        /// <param name="date">Date de création de la tâche</param>
        /// <param name="priorite">Priorité de la tâche (faible par défaut)</param>
        /// <param name="status">Statut d'accomplissement (false par défaut)</param>
        public Tachdata(string? titre, string? description, DateOnly? date,
                       Priorite? priorite = Priorite.faible, bool? status = false)
        {
            Titre = titre;
            Description = description;
            Status = status;
            Priorites = priorite;
            CreatedAt = date;
            _id = GetHashCode(); // Initialisation de l'ID
        }

        /// <summary>
        /// Génère un code de hachage basé sur la date de création et le titre
        /// </summary>
        /// <returns>Code de hachage entier</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(CreatedAt, Titre);
        }

        /// <summary>
        /// Retourne la date, le titre et la description
        /// </summary>
        /// <returns>un string</returns>
        public override string ToString()
        {
            return $"Créé le : {CreatedAt}\nTitre : {Titre}\nDescription : {Description}";
        }

        /// <summary>
        /// Compare deux tâches par leur date de création
        /// </summary>
        /// <param name="other">Autre tâche à comparer</param>
        /// <returns>
        /// -1 si other est null, 
        /// Résultat de la comparaison des dates sinon
        /// </returns>
        public int CompareTo(Tachdata? other)
        {
            if (other is null) return -1;
            return CreatedAt.Value.CompareTo(other.CreatedAt.Value);
        }

        /// <summary>
        /// Titre de la tâche (ne peut être null ou vide)
        /// </summary>
        public string? Titre
        {
            get => _titre;
            set => _titre = string.IsNullOrEmpty(value) ?
                throw new ArgumentException("Le titre ne peut pas être vide") : value;
        }

        /// <summary>
        /// Description de la tâche (retourne un message si null ou vide)
        /// </summary>
        public string? Description
        {
            get => _description;
            set => _description = string.IsNullOrEmpty(value) ?
                "Pas de description" : value;
        }

        /// <summary>
        /// Priorité de la tâche (faible par défaut si null)
        /// </summary>
        public Priorite? Priorites
        {
            get => _priorite;
            set => _priorite = value ?? Priorite.faible;
        }

        /// <summary>
        /// Statut d'accomplissement de la tâche (false par défaut si null)
        /// </summary>
        public bool? Status
        {
            get => _status;
            set => _status = value ?? false;
        }

        /// <summary>
        /// Date de création de la tâche (date actuelle par défaut si null)
        /// </summary>
        public DateOnly? CreatedAt
        {
            get => _createdAt;
            set => _createdAt = value ?? DateOnly.FromDateTime(DateTime.Now);
        }

        /// <summary>
        /// Identifiant unique de la tâche (généré à partir du hashcode)
        /// </summary>
        public int Id
        {
            get => _id;
            set => _id = value; // Permet une modification externe si nécessaire
        }
    }

    /// <summary>
    /// Enumération représentant les niveaux de priorité d'une tâche
    /// </summary>
    public enum Priorite
    {
        /// <summary>Priorité faible</summary>
        faible,
        /// <summary>Priorité moyenne</summary>
        moyenne,
        /// <summary>Priorité élevée</summary>
        eleve
    }
}