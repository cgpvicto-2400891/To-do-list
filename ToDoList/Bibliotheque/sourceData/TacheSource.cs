using Bibliotheque.model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bibliotheque.sourceData
{
    public class TacheSource
    {
        private readonly List<Tachdata> _listDeTask = new List<Tachdata>();

        public bool Ajouter(Tachdata task)
        {
            if (task == null) return false;
            _listDeTask.Add(task);
            return true;
        }

        public bool Supprimer(int id)
        {
            var task = _listDeTask.FirstOrDefault(t => t.Id == id);
            return task != null && _listDeTask.Remove(task);
        }

        public bool Update(string titre, string description, bool? status, Priorite? priorite, int id)
        {
            var task = _listDeTask.FirstOrDefault(t => t.Id == id);
            if (task == null) return false;

            if (!string.IsNullOrEmpty(titre)) task.Titre = titre;
            if (!string.IsNullOrEmpty(description)) task.Description = description;
            if (status != null) task.Status = status;
            if (priorite != null) task.Priorites = priorite;

            return true;
        }

        public List<Tachdata> ListDeTask => _listDeTask.OrderBy(t => t.CreatedAt).ToList();
    }
}