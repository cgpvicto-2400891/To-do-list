using Bibliotheque.model;
using Bibliotheque.sourceData;
using System.Collections.Generic;

namespace Bibliotheque.gestionnaire
{
    public class GetsionDesTache
    {
        private static GetsionDesTache? _instance;
        private readonly TacheSource _source = new TacheSource();

        private GetsionDesTache() { }

        public static GetsionDesTache Instance => _instance ??= new GetsionDesTache();

        public bool AjouterTache(Tachdata tache)
        {
            if (tache == null) return false;
            return _source.Ajouter(tache);
        }

        public bool RetirerTache(Tachdata tache)
        {
            return tache != null && _source.Supprimer(tache.Id);
        }

        public List<Tachdata> AfficherTaches()
        {
            return _source.ListDeTask;
        }

        public bool UpdateTache(string titre, string description, bool? status, Priorite? priorite, Tachdata task)
        {
            return _source.Update(titre, description, status, priorite, task.Id);
        }
    }
}