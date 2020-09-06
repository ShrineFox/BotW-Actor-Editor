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
            this.btn_SourceActor = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_RebuildActor = new System.Windows.Forms.Button();
            this.btn_TargetActor = new System.Windows.Forms.Button();
            this.chkBox_Waterfall = new System.Windows.Forms.CheckBox();
            this.lbl_SourceActor = new System.Windows.Forms.Label();
            this.lbl_TargetActor = new System.Windows.Forms.Label();
            this.txtBox_Output = new System.Windows.Forms.RichTextBox();
            this.chkBox_SpinAttack = new System.Windows.Forms.CheckBox();
            this.chkBox_KeepYML = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkBox_KeepSARC = new System.Windows.Forms.CheckBox();
            this.numUpDwn_WaitTime = new System.Windows.Forms.NumericUpDown();
            this.lbl_WaitTime = new System.Windows.Forms.Label();
            this.chkBox_KeepOriginalSARC = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwn_WaitTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_SourceActor
            // 
            this.btn_SourceActor.AllowDrop = true;
            this.btn_SourceActor.Location = new System.Drawing.Point(24, 23);
            this.btn_SourceActor.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_SourceActor.Name = "btn_SourceActor";
            this.btn_SourceActor.Size = new System.Drawing.Size(272, 115);
            this.btn_SourceActor.TabIndex = 0;
            this.btn_SourceActor.Text = "Drag source .sbactorpack\r\nor folder w/ multiple\r\n";
            this.btn_SourceActor.UseVisualStyleBackColor = true;
            this.btn_SourceActor.DragDrop += new System.Windows.Forms.DragEventHandler(this.Original_DragDrop);
            this.btn_SourceActor.DragEnter += new System.Windows.Forms.DragEventHandler(this.Original_DragEnter);
            // 
            // btn_RebuildActor
            // 
            this.btn_RebuildActor.Enabled = false;
            this.btn_RebuildActor.Location = new System.Drawing.Point(26, 183);
            this.btn_RebuildActor.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_RebuildActor.Name = "btn_RebuildActor";
            this.btn_RebuildActor.Size = new System.Drawing.Size(556, 79);
            this.btn_RebuildActor.TabIndex = 4;
            this.btn_RebuildActor.Text = "Rebuild .sbactorpack\r\nwith edits";
            this.btn_RebuildActor.UseVisualStyleBackColor = true;
            this.btn_RebuildActor.Click += new System.EventHandler(this.Rebuild_Click);
            // 
            // btn_TargetActor
            // 
            this.btn_TargetActor.AllowDrop = true;
            this.btn_TargetActor.Location = new System.Drawing.Point(308, 23);
            this.btn_TargetActor.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_TargetActor.Name = "btn_TargetActor";
            this.btn_TargetActor.Size = new System.Drawing.Size(272, 115);
            this.btn_TargetActor.TabIndex = 1;
            this.btn_TargetActor.Text = "Drag target .sbactorpack to use for physics\r\n(optional)";
            this.btn_TargetActor.UseVisualStyleBackColor = true;
            this.btn_TargetActor.DragDrop += new System.Windows.Forms.DragEventHandler(this.Replace_DragDrop);
            this.btn_TargetActor.DragEnter += new System.Windows.Forms.DragEventHandler(this.Replace_DragEnter);
            // 
            // chkBox_Waterfall
            // 
            this.chkBox_Waterfall.AutoSize = true;
            this.chkBox_Waterfall.Checked = true;
            this.chkBox_Waterfall.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox_Waterfall.Location = new System.Drawing.Point(592, 56);
            this.chkBox_Waterfall.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkBox_Waterfall.Name = "chkBox_Waterfall";
            this.chkBox_Waterfall.Size = new System.Drawing.Size(262, 29);
            this.chkBox_Waterfall.TabIndex = 9;
            this.chkBox_Waterfall.Text = "Enable Waterfall Climb";
            this.chkBox_Waterfall.UseVisualStyleBackColor = true;
            // 
            // lbl_SourceActor
            // 
            this.lbl_SourceActor.AutoSize = true;
            this.lbl_SourceActor.Location = new System.Drawing.Point(32, 142);
            this.lbl_SourceActor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_SourceActor.Name = "lbl_SourceActor";
            this.lbl_SourceActor.Size = new System.Drawing.Size(0, 25);
            this.lbl_SourceActor.TabIndex = 2;
            // 
            // lbl_TargetActor
            // 
            this.lbl_TargetActor.AutoSize = true;
            this.lbl_TargetActor.Location = new System.Drawing.Point(318, 142);
            this.lbl_TargetActor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_TargetActor.Name = "lbl_TargetActor";
            this.lbl_TargetActor.Size = new System.Drawing.Size(0, 25);
            this.lbl_TargetActor.TabIndex = 3;
            // 
            // txtBox_Output
            // 
            this.txtBox_Output.Location = new System.Drawing.Point(26, 273);
            this.txtBox_Output.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtBox_Output.Name = "txtBox_Output";
            this.txtBox_Output.ReadOnly = true;
            this.txtBox_Output.Size = new System.Drawing.Size(552, 344);
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
            this.chkBox_SpinAttack.Location = new System.Drawing.Point(592, 90);
            this.chkBox_SpinAttack.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkBox_SpinAttack.Name = "chkBox_SpinAttack";
            this.chkBox_SpinAttack.Size = new System.Drawing.Size(226, 29);
            this.chkBox_SpinAttack.TabIndex = 10;
            this.chkBox_SpinAttack.Text = "Enable Spin Attack";
            this.chkBox_SpinAttack.UseVisualStyleBackColor = true;
            // 
            // chkBox_KeepYML
            // 
            this.chkBox_KeepYML.AutoSize = true;
            this.chkBox_KeepYML.Checked = true;
            this.chkBox_KeepYML.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox_KeepYML.Location = new System.Drawing.Point(592, 519);
            this.chkBox_KeepYML.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkBox_KeepYML.Name = "chkBox_KeepYML";
            this.chkBox_KeepYML.Size = new System.Drawing.Size(285, 29);
            this.chkBox_KeepYML.TabIndex = 11;
            this.chkBox_KeepYML.Text = "Keep Modified YML Files";
            this.chkBox_KeepYML.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(590, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = ".bgparamlist";
            // 
            // chkBox_KeepSARC
            // 
            this.chkBox_KeepSARC.AutoSize = true;
            this.chkBox_KeepSARC.Location = new System.Drawing.Point(592, 550);
            this.chkBox_KeepSARC.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkBox_KeepSARC.Name = "chkBox_KeepSARC";
            this.chkBox_KeepSARC.Size = new System.Drawing.Size(258, 29);
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
            this.numUpDwn_WaitTime.Location = new System.Drawing.Point(746, 479);
            this.numUpDwn_WaitTime.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.numUpDwn_WaitTime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpDwn_WaitTime.Name = "numUpDwn_WaitTime";
            this.numUpDwn_WaitTime.Size = new System.Drawing.Size(110, 31);
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
            this.lbl_WaitTime.Location = new System.Drawing.Point(586, 483);
            this.lbl_WaitTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_WaitTime.Name = "lbl_WaitTime";
            this.lbl_WaitTime.Size = new System.Drawing.Size(147, 25);
            this.lbl_WaitTime.TabIndex = 14;
            this.lbl_WaitTime.Text = "FS Wait Time:";
            // 
            // chkBox_KeepOriginalSARC
            // 
            this.chkBox_KeepOriginalSARC.AutoSize = true;
            this.chkBox_KeepOriginalSARC.Location = new System.Drawing.Point(592, 581);
            this.chkBox_KeepOriginalSARC.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkBox_KeepOriginalSARC.Name = "chkBox_KeepOriginalSARC";
            this.chkBox_KeepOriginalSARC.Size = new System.Drawing.Size(271, 29);
            this.chkBox_KeepOriginalSARC.TabIndex = 15;
            this.chkBox_KeepOriginalSARC.Text = "Keep Original SARC Dir";
            this.chkBox_KeepOriginalSARC.UseVisualStyleBackColor = true;
            // 
            // BotWActorEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 640);
            this.Controls.Add(this.chkBox_KeepOriginalSARC);
            this.Controls.Add(this.lbl_WaitTime);
            this.Controls.Add(this.numUpDwn_WaitTime);
            this.Controls.Add(this.chkBox_KeepSARC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkBox_KeepYML);
            this.Controls.Add(this.chkBox_SpinAttack);
            this.Controls.Add(this.txtBox_Output);
            this.Controls.Add(this.chkBox_Waterfall);
            this.Controls.Add(this.lbl_TargetActor);
            this.Controls.Add(this.lbl_SourceActor);
            this.Controls.Add(this.btn_TargetActor);
            this.Controls.Add(this.btn_RebuildActor);
            this.Controls.Add(this.btn_SourceActor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "BotWActorEditor";
            this.Text = "BotW Actor Editor";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwn_WaitTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_SourceActor;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_RebuildActor;
        private System.Windows.Forms.Button btn_TargetActor;
        private System.Windows.Forms.CheckBox chkBox_Waterfall;
        private System.Windows.Forms.Label lbl_SourceActor;
        private System.Windows.Forms.Label lbl_TargetActor;
        private System.Windows.Forms.RichTextBox txtBox_Output;
        private System.Windows.Forms.CheckBox chkBox_SpinAttack;
        private System.Windows.Forms.CheckBox chkBox_KeepYML;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkBox_KeepSARC;
        private System.Windows.Forms.NumericUpDown numUpDwn_WaitTime;
        private System.Windows.Forms.Label lbl_WaitTime;
        private System.Windows.Forms.CheckBox chkBox_KeepOriginalSARC;
    }
}

