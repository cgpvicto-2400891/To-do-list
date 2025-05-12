using Bibliotheque.model;
using Bibliotheque.gestionnaire;
using System;
using System.Windows.Forms;

namespace ToDoList
{
    /// <summary>
    /// Formulaire principal de l'application ToDoList
    /// Gère l'affichage et l'interaction avec les tâches
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly GetsionDesTache _controller = GetsionDesTache.Instance;

        /// <summary>
        /// Initialise une nouvelle instance du formulaire principal
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            ConfigureUI();
            ChargerTaches();
        }

        /// <summary>
        /// Configure l'interface utilisateur au chargement du formulaire
        /// </summary>
        private void ConfigureUI()
        {
            // Config ComboBox
            comboBoxPriorite.DataSource = Enum.GetValues(typeof(Priorite));
            comboBoxPriorite.SelectedIndex = 0;

            // Config DataGridView
            dataGridViewTaches.AutoGenerateColumns = false;
            dataGridViewTaches.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Colonnes
            dataGridViewTaches.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTitre",
                DataPropertyName = "Titre",
                HeaderText = "Tâche",
                Width = 150
            });

            dataGridViewTaches.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDescription",
                DataPropertyName = "Description",
                HeaderText = "Description",
                Width = 400
            });

            dataGridViewTaches.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPriorite",
                DataPropertyName = "Priorites",
                HeaderText = "Priorité",
                Width = 100
            });
            dataGridViewTaches.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCreatedAt",
                DataPropertyName = "CreatedAt",
                HeaderText = "created at",
                Width = 123
            });

            // CheckBox pour le statut
            var colStatus = new DataGridViewCheckBoxColumn
            {
                Name = "colStatus",
                DataPropertyName = "Status",
                HeaderText = "Terminé",
                Width = 120
            };
            dataGridViewTaches.Columns.Add(colStatus);

            // Boutons d'action
            var colModifier = new DataGridViewButtonColumn
            {
                Name = "colModifier",
                Text = "Modifier",
                UseColumnTextForButtonValue = true,
                Width = 120
            };
            dataGridViewTaches.Columns.Add(colModifier);

            var colSupprimer = new DataGridViewButtonColumn
            {
                Name = "colSupprimer",
                Text = "Supprimer",
                UseColumnTextForButtonValue = true,
                Width = 120
            };
            dataGridViewTaches.Columns.Add(colSupprimer);

            // Événements
            dataGridViewTaches.CellContentClick += DataGridViewTaches_CellContentClick;
            dataGridViewTaches.CurrentCellDirtyStateChanged += DataGridViewTaches_CurrentCellDirtyStateChanged;
        }

        /// <summary>
        /// Gère le changement d'état des cellules du DataGridView
        /// </summary>
        private void DataGridViewTaches_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewTaches.CurrentCell is DataGridViewCheckBoxCell)
            {
                dataGridViewTaches.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// Gère les clics sur les cellules du DataGridView
        /// </summary>
        private void DataGridViewTaches_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var tache = (Tachdata)dataGridViewTaches.Rows[e.RowIndex].DataBoundItem;
            var columnName = dataGridViewTaches.Columns[e.ColumnIndex].Name;

            switch (columnName)
            {
                case "colSupprimer":
                    SupprimerTache(tache);
                    break;

                case "colModifier":
                    ModifierTache(tache);
                    break;
            }
        }

        /// <summary>
        /// Charge la liste des tâches dans le DataGridView
        /// </summary>
        private void ChargerTaches()
        {
            dataGridViewTaches.DataSource = null;
            dataGridViewTaches.DataSource = _controller.AfficherTaches();
        }

        /// <summary>
        /// Supprime une tâche après confirmation
        /// </summary>
        /// <param name="tache">Tâche à supprimer</param>
        private void SupprimerTache(Tachdata tache)
        {
            if (MessageBox.Show($"Supprimer la tâche '{tache.Titre}' ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_controller.RetirerTache(tache))
                {
                    ChargerTaches();
                }
            }
        }

        /// <summary>
        /// Active le mode modification d'une tâche
        /// </summary>
        /// <param name="tache">Tâche à modifier</param>
        private void ModifierTache(Tachdata tache)
        {
            // Utiliser les contrôles existants du formulaire principal
            textBoxTitre.Text = tache.Titre;
            textBoxDescription.Text = tache.Description;
            comboBoxPriorite.SelectedItem = tache.Priorites;

            // Activer le mode édition
            Ajouter.Visible = false;
            var btnValiderModif = new Button
            {
                Text = "Valider",
                Top = Ajouter.Top,
                Left = Ajouter.Left,
                Height = Ajouter.Height
            };

            btnValiderModif.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBoxTitre.Text))
                {
                    MessageBox.Show("Le titre ne peut pas être vide", "Erreur",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_controller.UpdateTache(
                    textBoxTitre.Text,
                    textBoxDescription.Text,
                    false,
                    (Priorite)comboBoxPriorite.SelectedItem,
                    tache))
                {
                    ChargerTaches();
                    btnValiderModif.Dispose();
                    Ajouter.Visible = true;
                }
            };

            this.Controls.Add(btnValiderModif);
        }

        /// <summary>
        /// Ajoute une nouvelle tâche à la liste
        /// </summary>
        private void Ajouter_Click(object sender, EventArgs e)
        {
            try
            {
                var nouvelleTache = new Tachdata(
                    textBoxTitre.Text,
                    textBoxDescription.Text,
                    DateOnly.FromDateTime(DateTime.Now),
                    (Priorite)comboBoxPriorite.SelectedItem
                );

                if (_controller.AjouterTache(nouvelleTache))
                {
                    ChargerTaches();
                    textBoxTitre.Clear();
                    textBoxDescription.Clear();
                    textBoxTitre.Focus();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}