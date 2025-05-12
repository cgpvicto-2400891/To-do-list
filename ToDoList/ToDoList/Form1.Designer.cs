namespace ToDoList
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxTitre = new TextBox();
            textBoxDescription = new TextBox();
            comboBoxPriorite = new ComboBox();
            Ajouter = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dataGridViewTaches = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTaches).BeginInit();
            SuspendLayout();
            // 
            // textBoxTitre
            // 
            textBoxTitre.Location = new Point(117, 21);
            textBoxTitre.Name = "textBoxTitre";
            textBoxTitre.Size = new Size(1065, 31);
            textBoxTitre.TabIndex = 0;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(117, 89);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(1065, 31);
            textBoxDescription.TabIndex = 1;
            // 
            // comboBoxPriorite
            // 
            comboBoxPriorite.FormattingEnabled = true;
            comboBoxPriorite.Location = new Point(117, 158);
            comboBoxPriorite.Name = "comboBoxPriorite";
            comboBoxPriorite.Size = new Size(1065, 33);
            comboBoxPriorite.TabIndex = 5;
            // 
            // Ajouter
            // 
            Ajouter.Location = new Point(501, 197);
            Ajouter.Name = "Ajouter";
            Ajouter.Size = new Size(112, 34);
            Ajouter.TabIndex = 6;
            Ajouter.Text = "ajouter";
            Ajouter.UseVisualStyleBackColor = true;
            Ajouter.Click += Ajouter_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 21);
            label1.Name = "label1";
            label1.Size = new Size(43, 25);
            label1.TabIndex = 7;
            label1.Text = "titre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 95);
            label2.Name = "label2";
            label2.Size = new Size(100, 25);
            label2.TabIndex = 8;
            label2.Text = "description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 166);
            label3.Name = "label3";
            label3.Size = new Size(69, 25);
            label3.TabIndex = 9;
            label3.Text = "priorite";
            // 
            // dataGridViewTaches
            // 
            dataGridViewTaches.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTaches.Location = new Point(3, 237);
            dataGridViewTaches.Name = "dataGridViewTaches";
            dataGridViewTaches.RowHeadersWidth = 62;
            dataGridViewTaches.Size = new Size(1189, 466);
            dataGridViewTaches.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 715);
            Controls.Add(dataGridViewTaches);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Ajouter);
            Controls.Add(comboBoxPriorite);
            Controls.Add(textBoxDescription);
            Controls.Add(textBoxTitre);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewTaches).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxTitre;
        private TextBox textBoxDescription;
        private ComboBox comboBoxPriorite;
        private Button Ajouter;
        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dataGridViewTaches;
    }
}
