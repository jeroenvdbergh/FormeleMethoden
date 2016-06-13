namespace Eindopdracht
{
    partial class MainGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConvertButton = new System.Windows.Forms.Button();
            this.ToNDFA = new System.Windows.Forms.RadioButton();
            this.ToDFA = new System.Windows.Forms.RadioButton();
            this.ToReguliereGrammatica = new System.Windows.Forms.RadioButton();
            this.InputBox = new System.Windows.Forms.RichTextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.vanExpressie = new System.Windows.Forms.RadioButton();
            this.vanDFA = new System.Windows.Forms.RadioButton();
            this.gcOutput = new DevExpress.XtraEditors.GroupControl();
            this.peGraph = new DevExpress.XtraEditors.PictureEdit();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSluiten = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpslaan = new DevExpress.XtraBars.BarButtonItem();
            this.btnMinimaliseer = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpslaanAls = new DevExpress.XtraBars.BarButtonItem();
            this.btnTestDFA = new DevExpress.XtraBars.BarButtonItem();
            this.rpAlgemeen = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgClose = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgActies = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.OutputBox = new System.Windows.Forms.RichTextBox();
            this.gcInput = new DevExpress.XtraEditors.GroupControl();
            this.vanGrammatica = new System.Windows.Forms.RadioButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lcVan = new DevExpress.XtraEditors.LabelControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnGrafiek = new System.Windows.Forms.Button();
            this.btnAddGram = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.gcOutput)).BeginInit();
            this.gcOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peGraph.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInput)).BeginInit();
            this.gcInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConvertButton
            // 
            this.ConvertButton.Location = new System.Drawing.Point(321, 173);
            this.ConvertButton.Margin = new System.Windows.Forms.Padding(4);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(127, 45);
            this.ConvertButton.TabIndex = 0;
            this.ConvertButton.Text = "Omzetten";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // ToNDFA
            // 
            this.ToNDFA.AutoSize = true;
            this.ToNDFA.Checked = true;
            this.ToNDFA.Location = new System.Drawing.Point(9, 28);
            this.ToNDFA.Margin = new System.Windows.Forms.Padding(4);
            this.ToNDFA.Name = "ToNDFA";
            this.ToNDFA.Size = new System.Drawing.Size(63, 21);
            this.ToNDFA.TabIndex = 2;
            this.ToNDFA.TabStop = true;
            this.ToNDFA.Text = "NDFA";
            this.ToNDFA.UseVisualStyleBackColor = true;
            // 
            // ToDFA
            // 
            this.ToDFA.AutoSize = true;
            this.ToDFA.Location = new System.Drawing.Point(109, 28);
            this.ToDFA.Margin = new System.Windows.Forms.Padding(4);
            this.ToDFA.Name = "ToDFA";
            this.ToDFA.Size = new System.Drawing.Size(54, 21);
            this.ToDFA.TabIndex = 3;
            this.ToDFA.Text = "DFA";
            this.ToDFA.UseVisualStyleBackColor = true;
            this.ToDFA.CheckedChanged += new System.EventHandler(this.ToDFA_CheckedChanged);
            this.ToDFA.EnabledChanged += new System.EventHandler(this.ToDFA_EnabledChanged);
            // 
            // ToReguliereGrammatica
            // 
            this.ToReguliereGrammatica.AutoSize = true;
            this.ToReguliereGrammatica.Location = new System.Drawing.Point(197, 28);
            this.ToReguliereGrammatica.Margin = new System.Windows.Forms.Padding(4);
            this.ToReguliereGrammatica.Name = "ToReguliereGrammatica";
            this.ToReguliereGrammatica.Size = new System.Drawing.Size(160, 21);
            this.ToReguliereGrammatica.TabIndex = 4;
            this.ToReguliereGrammatica.Text = "Reguliere grammatica";
            this.ToReguliereGrammatica.UseVisualStyleBackColor = true;
            // 
            // InputBox
            // 
            this.InputBox.Location = new System.Drawing.Point(6, 33);
            this.InputBox.Margin = new System.Windows.Forms.Padding(4);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(276, 197);
            this.InputBox.TabIndex = 6;
            this.InputBox.Text = "(ab)*";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(321, 305);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(127, 45);
            this.clearButton.TabIndex = 13;
            this.clearButton.Text = "Leeg maken";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // vanExpressie
            // 
            this.vanExpressie.AutoSize = true;
            this.vanExpressie.Checked = true;
            this.vanExpressie.Location = new System.Drawing.Point(9, 32);
            this.vanExpressie.Margin = new System.Windows.Forms.Padding(4);
            this.vanExpressie.Name = "vanExpressie";
            this.vanExpressie.Size = new System.Drawing.Size(144, 21);
            this.vanExpressie.TabIndex = 14;
            this.vanExpressie.TabStop = true;
            this.vanExpressie.Text = "Reguliere expressie";
            this.vanExpressie.UseVisualStyleBackColor = true;
            // 
            // vanDFA
            // 
            this.vanDFA.AutoSize = true;
            this.vanDFA.Location = new System.Drawing.Point(173, 32);
            this.vanDFA.Margin = new System.Windows.Forms.Padding(4);
            this.vanDFA.Name = "vanDFA";
            this.vanDFA.Size = new System.Drawing.Size(73, 21);
            this.vanDFA.TabIndex = 15;
            this.vanDFA.Text = "(N)DFA";
            this.vanDFA.UseVisualStyleBackColor = true;
            // 
            // gcOutput
            // 
            this.gcOutput.Controls.Add(this.peGraph);
            this.gcOutput.Controls.Add(this.OutputBox);
            this.gcOutput.Location = new System.Drawing.Point(473, 140);
            this.gcOutput.Name = "gcOutput";
            this.gcOutput.Size = new System.Drawing.Size(864, 381);
            this.gcOutput.TabIndex = 18;
            this.gcOutput.Text = "Output";
            // 
            // peGraph
            // 
            this.peGraph.Location = new System.Drawing.Point(435, 29);
            this.peGraph.MenuManager = this.ribbonControl1;
            this.peGraph.Name = "peGraph";
            this.peGraph.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.peGraph.Size = new System.Drawing.Size(424, 348);
            this.peGraph.TabIndex = 1;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnSluiten,
            this.btnOpen,
            this.btnOpslaan,
            this.btnMinimaliseer,
            this.btnOpslaanAls,
            this.btnTestDFA,
            this.btnAddGram});
            this.ribbonControl1.ItemsVertAlign = DevExpress.Utils.VertAlignment.Top;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 8;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpAlgemeen});
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Show;
            this.ribbonControl1.ShowQatLocationSelector = false;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(1349, 134);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnSluiten
            // 
            this.btnSluiten.Caption = "Sluiten";
            this.btnSluiten.Glyph = global::Eindopdracht.Properties.Resources.door_out;
            this.btnSluiten.Id = 1;
            this.btnSluiten.Name = "btnSluiten";
            this.btnSluiten.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSluiten_ItemClick);
            // 
            // btnOpen
            // 
            this.btnOpen.Caption = "Open";
            this.btnOpen.Glyph = global::Eindopdracht.Properties.Resources.open;
            this.btnOpen.Id = 2;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpen_ItemClick);
            // 
            // btnOpslaan
            // 
            this.btnOpslaan.Caption = "Opslaan";
            this.btnOpslaan.Glyph = global::Eindopdracht.Properties.Resources.save;
            this.btnOpslaan.Id = 3;
            this.btnOpslaan.Name = "btnOpslaan";
            this.btnOpslaan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpslaan_ItemClick);
            // 
            // btnMinimaliseer
            // 
            this.btnMinimaliseer.Caption = "Minimaliseer DFA";
            this.btnMinimaliseer.Enabled = false;
            this.btnMinimaliseer.Glyph = global::Eindopdracht.Properties.Resources.magic_wand;
            this.btnMinimaliseer.Id = 4;
            this.btnMinimaliseer.Name = "btnMinimaliseer";
            this.btnMinimaliseer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMinimaliseer_Click);
            // 
            // btnOpslaanAls
            // 
            this.btnOpslaanAls.Caption = "Opslaan als";
            this.btnOpslaanAls.Glyph = global::Eindopdracht.Properties.Resources.save_as;
            this.btnOpslaanAls.Id = 5;
            this.btnOpslaanAls.Name = "btnOpslaanAls";
            this.btnOpslaanAls.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpslaanAls_ItemClick);
            // 
            // btnTestDFA
            // 
            this.btnTestDFA.Caption = "Voeg test DFA toe";
            this.btnTestDFA.Glyph = global::Eindopdracht.Properties.Resources.add;
            this.btnTestDFA.Id = 6;
            this.btnTestDFA.Name = "btnTestDFA";
            this.btnTestDFA.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTestDFA_ItemClick);
            // 
            // rpAlgemeen
            // 
            this.rpAlgemeen.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgClose,
            this.rpgActies});
            this.rpAlgemeen.Name = "rpAlgemeen";
            this.rpAlgemeen.Text = "Algemeen";
            // 
            // rpgClose
            // 
            this.rpgClose.ItemLinks.Add(this.btnSluiten);
            this.rpgClose.Name = "rpgClose";
            this.rpgClose.Text = "Algemeen";
            // 
            // rpgActies
            // 
            this.rpgActies.ItemLinks.Add(this.btnOpen);
            this.rpgActies.ItemLinks.Add(this.btnOpslaan);
            this.rpgActies.ItemLinks.Add(this.btnOpslaanAls);
            this.rpgActies.ItemLinks.Add(this.btnTestDFA);
            this.rpgActies.ItemLinks.Add(this.btnAddGram);
            this.rpgActies.ItemLinks.Add(this.btnMinimaliseer);
            this.rpgActies.Name = "rpgActies";
            this.rpgActies.Text = "Acties";
            // 
            // OutputBox
            // 
            this.OutputBox.Location = new System.Drawing.Point(6, 29);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.Size = new System.Drawing.Size(423, 347);
            this.OutputBox.TabIndex = 0;
            this.OutputBox.Text = "";
            // 
            // gcInput
            // 
            this.gcInput.Controls.Add(this.InputBox);
            this.gcInput.Location = new System.Drawing.Point(12, 140);
            this.gcInput.Name = "gcInput";
            this.gcInput.Size = new System.Drawing.Size(290, 236);
            this.gcInput.TabIndex = 19;
            this.gcInput.Text = "Input";
            // 
            // vanGrammatica
            // 
            this.vanGrammatica.AutoSize = true;
            this.vanGrammatica.Location = new System.Drawing.Point(270, 32);
            this.vanGrammatica.Margin = new System.Windows.Forms.Padding(4);
            this.vanGrammatica.Name = "vanGrammatica";
            this.vanGrammatica.Size = new System.Drawing.Size(160, 21);
            this.vanGrammatica.TabIndex = 20;
            this.vanGrammatica.Text = "Reguliere grammatica";
            this.vanGrammatica.UseVisualStyleBackColor = true;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(9, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(32, 16);
            this.labelControl1.TabIndex = 19;
            this.labelControl1.Text = "Naar:";
            // 
            // lcVan
            // 
            this.lcVan.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcVan.Location = new System.Drawing.Point(9, 9);
            this.lcVan.Name = "lcVan";
            this.lcVan.Size = new System.Drawing.Size(27, 16);
            this.lcVan.TabIndex = 18;
            this.lcVan.Text = "Van:";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Opslaan";
            this.barButtonItem1.Glyph = global::Eindopdracht.Properties.Resources.save;
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.vanGrammatica);
            this.panelControl1.Controls.Add(this.lcVan);
            this.panelControl1.Controls.Add(this.vanDFA);
            this.panelControl1.Controls.Add(this.vanExpressie);
            this.panelControl1.Location = new System.Drawing.Point(18, 386);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(434, 66);
            this.panelControl1.TabIndex = 21;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.ToNDFA);
            this.panelControl2.Controls.Add(this.ToDFA);
            this.panelControl2.Controls.Add(this.ToReguliereGrammatica);
            this.panelControl2.Location = new System.Drawing.Point(18, 458);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(434, 63);
            this.panelControl2.TabIndex = 20;
            // 
            // btnGrafiek
            // 
            this.btnGrafiek.Location = new System.Drawing.Point(321, 240);
            this.btnGrafiek.Margin = new System.Windows.Forms.Padding(4);
            this.btnGrafiek.Name = "btnGrafiek";
            this.btnGrafiek.Size = new System.Drawing.Size(127, 45);
            this.btnGrafiek.TabIndex = 23;
            this.btnGrafiek.Text = "Grafiek tonen";
            this.btnGrafiek.UseVisualStyleBackColor = true;
            this.btnGrafiek.Click += new System.EventHandler(this.btnGrafiek_Click);
            // 
            // btnAddGram
            // 
            this.btnAddGram.Caption = "Voeg test grammatica toe";
            this.btnAddGram.Glyph = global::Eindopdracht.Properties.Resources.add;
            this.btnAddGram.Id = 7;
            this.btnAddGram.Name = "btnAddGram";
            this.btnAddGram.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddGram_ItemClick);
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1349, 529);
            this.Controls.Add(this.btnGrafiek);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.gcInput);
            this.Controls.Add(this.gcOutput);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.ConvertButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainGUI";
            this.Text = "Formele Methodes";
            ((System.ComponentModel.ISupportInitialize)(this.gcOutput)).EndInit();
            this.gcOutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.peGraph.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInput)).EndInit();
            this.gcInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.RadioButton ToNDFA;
        private System.Windows.Forms.RadioButton ToDFA;
        private System.Windows.Forms.RadioButton ToReguliereGrammatica;
        private System.Windows.Forms.RichTextBox InputBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.RadioButton vanExpressie;
        private System.Windows.Forms.RadioButton vanDFA;
        private DevExpress.XtraEditors.GroupControl gcOutput;
        private System.Windows.Forms.RichTextBox OutputBox;
        private DevExpress.XtraEditors.GroupControl gcInput;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpAlgemeen;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgClose;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lcVan;
        private DevExpress.XtraBars.BarButtonItem btnSluiten;
        private DevExpress.XtraBars.BarButtonItem btnOpen;
        private DevExpress.XtraBars.BarButtonItem btnOpslaan;
        private DevExpress.XtraBars.BarButtonItem btnMinimaliseer;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgActies;
        private System.Windows.Forms.RadioButton vanGrammatica;
        private DevExpress.XtraBars.BarButtonItem btnOpslaanAls;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraBars.BarButtonItem btnTestDFA;
        private System.Windows.Forms.Button btnGrafiek;
        private DevExpress.XtraEditors.PictureEdit peGraph;
        private DevExpress.XtraBars.BarButtonItem btnAddGram;
    }
}