namespace BotWPhysicsReplacer
{
    partial class BotWActorEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BotWActorEditor));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_RebuildActor = new System.Windows.Forms.Button();
            this.chkBox_Waterfall = new System.Windows.Forms.CheckBox();
            this.txtBox_Output = new System.Windows.Forms.RichTextBox();
            this.chkBox_SpinAttack = new System.Windows.Forms.CheckBox();
            this.chkBox_KeepYML = new System.Windows.Forms.CheckBox();
            this.chkBox_KeepSARC = new System.Windows.Forms.CheckBox();
            this.numUpDwn_WaitTime = new System.Windows.Forms.NumericUpDown();
            this.lbl_WaitTime = new System.Windows.Forms.Label();
            this.chkBox_KeepOriginalSARC = new System.Windows.Forms.CheckBox();
            this.chkBox_CMD = new System.Windows.Forms.CheckBox();
            this.txt_SourceActor = new System.Windows.Forms.TextBox();
            this.txt_TargetActor = new System.Windows.Forms.TextBox();
            this.btn_SourceActorBrowse = new System.Windows.Forms.Button();
            this.btn_TargetActorBrowse = new System.Windows.Forms.Button();
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage_ActorPacks = new System.Windows.Forms.TabPage();
            this.tabPage_Models = new System.Windows.Forms.TabPage();
            this.groupBox_bgparamlist = new System.Windows.Forms.GroupBox();
            this.btn_RebuildBFRES = new System.Windows.Forms.Button();
            this.btn_TargetBFRESBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SourceBFRESBrowse = new System.Windows.Forms.Button();
            this.txt_SourceBFRES = new System.Windows.Forms.TextBox();
            this.txt_TargetBFRES = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwn_WaitTime)).BeginInit();
            this.tabControl_Main.SuspendLayout();
            this.tabPage_ActorPacks.SuspendLayout();
            this.tabPage_Models.SuspendLayout();
            this.groupBox_bgparamlist.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_RebuildActor
            // 
            this.btn_RebuildActor.Enabled = false;
            this.btn_RebuildActor.Location = new System.Drawing.Point(116, 68);
            this.btn_RebuildActor.Margin = new System.Windows.Forms.Padding(4);
            this.btn_RebuildActor.Name = "btn_RebuildActor";
            this.btn_RebuildActor.Size = new System.Drawing.Size(192, 74);
            this.btn_RebuildActor.TabIndex = 4;
            this.btn_RebuildActor.Text = "Rebuild .sbactorpack\r\nfiles with edits";
            this.btn_RebuildActor.UseVisualStyleBackColor = true;
            this.btn_RebuildActor.Click += new System.EventHandler(this.Rebuild_Click);
            // 
            // chkBox_Waterfall
            // 
            this.chkBox_Waterfall.AutoSize = true;
            this.chkBox_Waterfall.Checked = true;
            this.chkBox_Waterfall.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox_Waterfall.Location = new System.Drawing.Point(7, 30);
            this.chkBox_Waterfall.Margin = new System.Windows.Forms.Padding(4);
            this.chkBox_Waterfall.Name = "chkBox_Waterfall";
            this.chkBox_Waterfall.Size = new System.Drawing.Size(172, 21);
            this.chkBox_Waterfall.TabIndex = 9;
            this.chkBox_Waterfall.Text = "Enable Waterfall Climb";
            this.chkBox_Waterfall.UseVisualStyleBackColor = true;
            // 
            // txtBox_Output
            // 
            this.txtBox_Output.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtBox_Output.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtBox_Output.Location = new System.Drawing.Point(7, 286);
            this.txtBox_Output.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_Output.Name = "txtBox_Output";
            this.txtBox_Output.ReadOnly = true;
            this.txtBox_Output.Size = new System.Drawing.Size(369, 123);
            this.txtBox_Output.TabIndex = 5;
            this.txtBox_Output.Text = "Thank you for using BotW Actor Editor!\nhttps://github.com/ShrineFox/BotW-Actor-Ed" +
    "itor\n\nUsing SARC/AAMP scripts by @leoetlino\nIcon generously provided by @greatse" +
    "npai";
            // 
            // chkBox_SpinAttack
            // 
            this.chkBox_SpinAttack.AutoSize = true;
            this.chkBox_SpinAttack.Checked = true;
            this.chkBox_SpinAttack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox_SpinAttack.Location = new System.Drawing.Point(7, 52);
            this.chkBox_SpinAttack.Margin = new System.Windows.Forms.Padding(4);
            this.chkBox_SpinAttack.Name = "chkBox_SpinAttack";
            this.chkBox_SpinAttack.Size = new System.Drawing.Size(149, 21);
            this.chkBox_SpinAttack.TabIndex = 10;
            this.chkBox_SpinAttack.Text = "Enable Spin Attack";
            this.chkBox_SpinAttack.UseVisualStyleBackColor = true;
            // 
            // chkBox_KeepYML
            // 
            this.chkBox_KeepYML.AutoSize = true;
            this.chkBox_KeepYML.Checked = true;
            this.chkBox_KeepYML.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox_KeepYML.Location = new System.Drawing.Point(384, 326);
            this.chkBox_KeepYML.Margin = new System.Windows.Forms.Padding(4);
            this.chkBox_KeepYML.Name = "chkBox_KeepYML";
            this.chkBox_KeepYML.Size = new System.Drawing.Size(185, 21);
            this.chkBox_KeepYML.TabIndex = 11;
            this.chkBox_KeepYML.Text = "Keep Modified YML Files";
            this.chkBox_KeepYML.UseVisualStyleBackColor = true;
            // 
            // chkBox_KeepSARC
            // 
            this.chkBox_KeepSARC.AutoSize = true;
            this.chkBox_KeepSARC.Location = new System.Drawing.Point(384, 346);
            this.chkBox_KeepSARC.Margin = new System.Windows.Forms.Padding(4);
            this.chkBox_KeepSARC.Name = "chkBox_KeepSARC";
            this.chkBox_KeepSARC.Size = new System.Drawing.Size(170, 21);
            this.chkBox_KeepSARC.TabIndex = 12;
            this.chkBox_KeepSARC.Text = "Keep Edited SARC Dir";
            this.chkBox_KeepSARC.UseVisualStyleBackColor = true;
            // 
            // numUpDwn_WaitTime
            // 
            this.numUpDwn_WaitTime.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numUpDwn_WaitTime.Location = new System.Drawing.Point(488, 283);
            this.numUpDwn_WaitTime.Margin = new System.Windows.Forms.Padding(4);
            this.numUpDwn_WaitTime.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numUpDwn_WaitTime.Name = "numUpDwn_WaitTime";
            this.numUpDwn_WaitTime.Size = new System.Drawing.Size(89, 22);
            this.numUpDwn_WaitTime.TabIndex = 13;
            this.numUpDwn_WaitTime.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lbl_WaitTime
            // 
            this.lbl_WaitTime.AutoSize = true;
            this.lbl_WaitTime.Location = new System.Drawing.Point(381, 286);
            this.lbl_WaitTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_WaitTime.Name = "lbl_WaitTime";
            this.lbl_WaitTime.Size = new System.Drawing.Size(96, 17);
            this.lbl_WaitTime.TabIndex = 14;
            this.lbl_WaitTime.Text = "FS Wait Time:";
            // 
            // chkBox_KeepOriginalSARC
            // 
            this.chkBox_KeepOriginalSARC.AutoSize = true;
            this.chkBox_KeepOriginalSARC.Location = new System.Drawing.Point(384, 366);
            this.chkBox_KeepOriginalSARC.Margin = new System.Windows.Forms.Padding(4);
            this.chkBox_KeepOriginalSARC.Name = "chkBox_KeepOriginalSARC";
            this.chkBox_KeepOriginalSARC.Size = new System.Drawing.Size(179, 21);
            this.chkBox_KeepOriginalSARC.TabIndex = 15;
            this.chkBox_KeepOriginalSARC.Text = "Keep Original SARC Dir";
            this.chkBox_KeepOriginalSARC.UseVisualStyleBackColor = true;
            // 
            // chkBox_CMD
            // 
            this.chkBox_CMD.AutoSize = true;
            this.chkBox_CMD.Location = new System.Drawing.Point(384, 385);
            this.chkBox_CMD.Margin = new System.Windows.Forms.Padding(4);
            this.chkBox_CMD.Name = "chkBox_CMD";
            this.chkBox_CMD.Size = new System.Drawing.Size(179, 21);
            this.chkBox_CMD.TabIndex = 16;
            this.chkBox_CMD.Text = "Show Console Windows";
            this.chkBox_CMD.UseVisualStyleBackColor = true;
            // 
            // txt_SourceActor
            // 
            this.txt_SourceActor.Location = new System.Drawing.Point(6, 6);
            this.txt_SourceActor.Name = "txt_SourceActor";
            this.txt_SourceActor.ReadOnly = true;
            this.txt_SourceActor.Size = new System.Drawing.Size(258, 22);
            this.txt_SourceActor.TabIndex = 17;
            this.txt_SourceActor.Text = "Source .sbactorpack file(s) to change";
            this.txt_SourceActor.Click += new System.EventHandler(this.OriginalActorPacks_Click);
            this.txt_SourceActor.DragDrop += new System.Windows.Forms.DragEventHandler(this.OriginalActorPacks_DragDrop);
            this.txt_SourceActor.DragEnter += new System.Windows.Forms.DragEventHandler(this.OriginalActorPacks_DragEnter);
            // 
            // txt_TargetActor
            // 
            this.txt_TargetActor.Location = new System.Drawing.Point(6, 34);
            this.txt_TargetActor.Name = "txt_TargetActor";
            this.txt_TargetActor.ReadOnly = true;
            this.txt_TargetActor.Size = new System.Drawing.Size(258, 22);
            this.txt_TargetActor.TabIndex = 18;
            this.txt_TargetActor.Text = ".sbactorpack to use for physics (optional)";
            this.txt_TargetActor.Click += new System.EventHandler(this.TargetActorPacks_Click);
            this.txt_TargetActor.DragDrop += new System.Windows.Forms.DragEventHandler(this.TargetActorPacks_DragDrop);
            this.txt_TargetActor.DragEnter += new System.Windows.Forms.DragEventHandler(this.TargetActorPacks_DragEnter);
            // 
            // btn_SourceActorBrowse
            // 
            this.btn_SourceActorBrowse.Location = new System.Drawing.Point(270, 6);
            this.btn_SourceActorBrowse.Name = "btn_SourceActorBrowse";
            this.btn_SourceActorBrowse.Size = new System.Drawing.Size(38, 23);
            this.btn_SourceActorBrowse.TabIndex = 19;
            this.btn_SourceActorBrowse.Text = "...";
            this.btn_SourceActorBrowse.UseVisualStyleBackColor = true;
            this.btn_SourceActorBrowse.Click += new System.EventHandler(this.OriginalActorPacks_BtnClick);
            // 
            // btn_TargetActorBrowse
            // 
            this.btn_TargetActorBrowse.Location = new System.Drawing.Point(270, 33);
            this.btn_TargetActorBrowse.Name = "btn_TargetActorBrowse";
            this.btn_TargetActorBrowse.Size = new System.Drawing.Size(38, 23);
            this.btn_TargetActorBrowse.TabIndex = 20;
            this.btn_TargetActorBrowse.Text = "...";
            this.btn_TargetActorBrowse.UseVisualStyleBackColor = true;
            this.btn_TargetActorBrowse.Click += new System.EventHandler(this.TargetActorPacks_BtnClick);
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Controls.Add(this.tabPage_ActorPacks);
            this.tabControl_Main.Controls.Add(this.tabPage_Models);
            this.tabControl_Main.Location = new System.Drawing.Point(3, 3);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(574, 280);
            this.tabControl_Main.TabIndex = 21;
            // 
            // tabPage_ActorPacks
            // 
            this.tabPage_ActorPacks.Controls.Add(this.groupBox_bgparamlist);
            this.tabPage_ActorPacks.Controls.Add(this.btn_RebuildActor);
            this.tabPage_ActorPacks.Controls.Add(this.btn_TargetActorBrowse);
            this.tabPage_ActorPacks.Controls.Add(this.btn_SourceActorBrowse);
            this.tabPage_ActorPacks.Controls.Add(this.txt_SourceActor);
            this.tabPage_ActorPacks.Controls.Add(this.txt_TargetActor);
            this.tabPage_ActorPacks.Location = new System.Drawing.Point(4, 25);
            this.tabPage_ActorPacks.Name = "tabPage_ActorPacks";
            this.tabPage_ActorPacks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ActorPacks.Size = new System.Drawing.Size(566, 251);
            this.tabPage_ActorPacks.TabIndex = 0;
            this.tabPage_ActorPacks.Text = "ActorPacks";
            this.tabPage_ActorPacks.UseVisualStyleBackColor = true;
            // 
            // tabPage_Models
            // 
            this.tabPage_Models.Controls.Add(this.btn_RebuildBFRES);
            this.tabPage_Models.Controls.Add(this.btn_TargetBFRESBrowse);
            this.tabPage_Models.Controls.Add(this.label1);
            this.tabPage_Models.Controls.Add(this.btn_SourceBFRESBrowse);
            this.tabPage_Models.Controls.Add(this.txt_SourceBFRES);
            this.tabPage_Models.Controls.Add(this.txt_TargetBFRES);
            this.tabPage_Models.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Models.Name = "tabPage_Models";
            this.tabPage_Models.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Models.Size = new System.Drawing.Size(566, 251);
            this.tabPage_Models.TabIndex = 1;
            this.tabPage_Models.Text = "Models";
            this.tabPage_Models.UseVisualStyleBackColor = true;
            // 
            // groupBox_bgparamlist
            // 
            this.groupBox_bgparamlist.Controls.Add(this.chkBox_Waterfall);
            this.groupBox_bgparamlist.Controls.Add(this.chkBox_SpinAttack);
            this.groupBox_bgparamlist.Location = new System.Drawing.Point(327, 6);
            this.groupBox_bgparamlist.Name = "groupBox_bgparamlist";
            this.groupBox_bgparamlist.Size = new System.Drawing.Size(216, 86);
            this.groupBox_bgparamlist.TabIndex = 21;
            this.groupBox_bgparamlist.TabStop = false;
            this.groupBox_bgparamlist.Text = ".bgparamlist";
            // 
            // btn_RebuildBFRES
            // 
            this.btn_RebuildBFRES.Enabled = false;
            this.btn_RebuildBFRES.Location = new System.Drawing.Point(116, 68);
            this.btn_RebuildBFRES.Margin = new System.Windows.Forms.Padding(4);
            this.btn_RebuildBFRES.Name = "btn_RebuildBFRES";
            this.btn_RebuildBFRES.Size = new System.Drawing.Size(192, 74);
            this.btn_RebuildBFRES.TabIndex = 22;
            this.btn_RebuildBFRES.Text = "Rebuild .sbfres files\r\nwith edits";
            this.btn_RebuildBFRES.UseVisualStyleBackColor = true;
            // 
            // btn_TargetBFRESBrowse
            // 
            this.btn_TargetBFRESBrowse.Location = new System.Drawing.Point(270, 33);
            this.btn_TargetBFRESBrowse.Name = "btn_TargetBFRESBrowse";
            this.btn_TargetBFRESBrowse.Size = new System.Drawing.Size(38, 23);
            this.btn_TargetBFRESBrowse.TabIndex = 26;
            this.btn_TargetBFRESBrowse.Text = "...";
            this.btn_TargetBFRESBrowse.UseVisualStyleBackColor = true;
            this.btn_TargetBFRESBrowse.Click += new System.EventHandler(this.TargetSbfres_BtnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 21;
            // 
            // btn_SourceBFRESBrowse
            // 
            this.btn_SourceBFRESBrowse.Location = new System.Drawing.Point(270, 6);
            this.btn_SourceBFRESBrowse.Name = "btn_SourceBFRESBrowse";
            this.btn_SourceBFRESBrowse.Size = new System.Drawing.Size(38, 23);
            this.btn_SourceBFRESBrowse.TabIndex = 25;
            this.btn_SourceBFRESBrowse.Text = "...";
            this.btn_SourceBFRESBrowse.UseVisualStyleBackColor = true;
            this.btn_SourceBFRESBrowse.Click += new System.EventHandler(this.OriginalSbfresFiles_BtnClick);
            // 
            // txt_SourceBFRES
            // 
            this.txt_SourceBFRES.Location = new System.Drawing.Point(6, 6);
            this.txt_SourceBFRES.Name = "txt_SourceBFRES";
            this.txt_SourceBFRES.ReadOnly = true;
            this.txt_SourceBFRES.Size = new System.Drawing.Size(258, 22);
            this.txt_SourceBFRES.TabIndex = 23;
            this.txt_SourceBFRES.Text = "Source .sbfres file(s) to change";
            this.txt_SourceBFRES.Click += new System.EventHandler(this.OriginalSbfresFiles_Click);
            this.txt_SourceBFRES.DragDrop += new System.Windows.Forms.DragEventHandler(this.OriginalSbfresFiles_DragDrop);
            this.txt_SourceBFRES.DragEnter += new System.Windows.Forms.DragEventHandler(this.OriginalSbfresFiles_DragEnter);
            // 
            // txt_TargetBFRES
            // 
            this.txt_TargetBFRES.Location = new System.Drawing.Point(6, 34);
            this.txt_TargetBFRES.Name = "txt_TargetBFRES";
            this.txt_TargetBFRES.ReadOnly = true;
            this.txt_TargetBFRES.Size = new System.Drawing.Size(258, 22);
            this.txt_TargetBFRES.TabIndex = 24;
            this.txt_TargetBFRES.Text = ".sbfres to use for bone position (optional)";
            this.txt_TargetBFRES.Click += new System.EventHandler(this.TargetSbfres_Click);
            this.txt_TargetBFRES.DragDrop += new System.Windows.Forms.DragEventHandler(this.TargetSbfres_DragDrop);
            this.txt_TargetBFRES.DragEnter += new System.Windows.Forms.DragEventHandler(this.TargetSbfres_DragEnter);
            // 
            // BotWActorEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(584, 410);
            this.Controls.Add(this.tabControl_Main);
            this.Controls.Add(this.chkBox_CMD);
            this.Controls.Add(this.chkBox_KeepOriginalSARC);
            this.Controls.Add(this.lbl_WaitTime);
            this.Controls.Add(this.numUpDwn_WaitTime);
            this.Controls.Add(this.chkBox_KeepSARC);
            this.Controls.Add(this.chkBox_KeepYML);
            this.Controls.Add(this.txtBox_Output);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BotWActorEditor";
            this.Text = "BotW Actor Editor";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwn_WaitTime)).EndInit();
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage_ActorPacks.ResumeLayout(false);
            this.tabPage_ActorPacks.PerformLayout();
            this.tabPage_Models.ResumeLayout(false);
            this.tabPage_Models.PerformLayout();
            this.groupBox_bgparamlist.ResumeLayout(false);
            this.groupBox_bgparamlist.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_RebuildActor;
        private System.Windows.Forms.CheckBox chkBox_Waterfall;
        private System.Windows.Forms.RichTextBox txtBox_Output;
        private System.Windows.Forms.CheckBox chkBox_SpinAttack;
        private System.Windows.Forms.CheckBox chkBox_KeepYML;
        private System.Windows.Forms.CheckBox chkBox_KeepSARC;
        private System.Windows.Forms.NumericUpDown numUpDwn_WaitTime;
        private System.Windows.Forms.Label lbl_WaitTime;
        private System.Windows.Forms.CheckBox chkBox_KeepOriginalSARC;
        private System.Windows.Forms.CheckBox chkBox_CMD;
        private System.Windows.Forms.TextBox txt_SourceActor;
        private System.Windows.Forms.TextBox txt_TargetActor;
        private System.Windows.Forms.Button btn_SourceActorBrowse;
        private System.Windows.Forms.Button btn_TargetActorBrowse;
        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tabPage_ActorPacks;
        private System.Windows.Forms.GroupBox groupBox_bgparamlist;
        private System.Windows.Forms.TabPage tabPage_Models;
        private System.Windows.Forms.Button btn_RebuildBFRES;
        private System.Windows.Forms.Button btn_TargetBFRESBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_SourceBFRESBrowse;
        private System.Windows.Forms.TextBox txt_SourceBFRES;
        private System.Windows.Forms.TextBox txt_TargetBFRES;
    }
}

