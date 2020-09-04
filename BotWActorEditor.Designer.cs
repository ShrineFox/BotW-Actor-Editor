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
            this.btn_OriginalActor = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_RebuildActor = new System.Windows.Forms.Button();
            this.btn_ReplaceActor = new System.Windows.Forms.Button();
            this.chkBox_Waterfall = new System.Windows.Forms.CheckBox();
            this.lbl_OriginalActor = new System.Windows.Forms.Label();
            this.lbl_ReplaceActor = new System.Windows.Forms.Label();
            this.txtBox_Output = new System.Windows.Forms.RichTextBox();
            this.chkBox_SpinAttack = new System.Windows.Forms.CheckBox();
            this.chkBox_KeepYML = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkBox_KeepSARC = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_OriginalActor
            // 
            this.btn_OriginalActor.AllowDrop = true;
            this.btn_OriginalActor.Location = new System.Drawing.Point(16, 15);
            this.btn_OriginalActor.Margin = new System.Windows.Forms.Padding(4);
            this.btn_OriginalActor.Name = "btn_OriginalActor";
            this.btn_OriginalActor.Size = new System.Drawing.Size(181, 74);
            this.btn_OriginalActor.TabIndex = 0;
            this.btn_OriginalActor.Text = "Drag original .sbactorpack\r\nor folder w/ multiple\r\n";
            this.btn_OriginalActor.UseVisualStyleBackColor = true;
            this.btn_OriginalActor.DragDrop += new System.Windows.Forms.DragEventHandler(this.Original_DragDrop);
            this.btn_OriginalActor.DragEnter += new System.Windows.Forms.DragEventHandler(this.Original_DragEnter);
            // 
            // btn_RebuildActor
            // 
            this.btn_RebuildActor.Enabled = false;
            this.btn_RebuildActor.Location = new System.Drawing.Point(17, 117);
            this.btn_RebuildActor.Margin = new System.Windows.Forms.Padding(4);
            this.btn_RebuildActor.Name = "btn_RebuildActor";
            this.btn_RebuildActor.Size = new System.Drawing.Size(371, 50);
            this.btn_RebuildActor.TabIndex = 4;
            this.btn_RebuildActor.Text = "Rebuild .sbactorpack\r\nwith edits";
            this.btn_RebuildActor.UseVisualStyleBackColor = true;
            this.btn_RebuildActor.Click += new System.EventHandler(this.Rebuild_Click);
            // 
            // btn_ReplaceActor
            // 
            this.btn_ReplaceActor.AllowDrop = true;
            this.btn_ReplaceActor.Location = new System.Drawing.Point(205, 15);
            this.btn_ReplaceActor.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ReplaceActor.Name = "btn_ReplaceActor";
            this.btn_ReplaceActor.Size = new System.Drawing.Size(181, 74);
            this.btn_ReplaceActor.TabIndex = 1;
            this.btn_ReplaceActor.Text = "Drag .sbactorpack with physics you want to use (optional)\r\n";
            this.btn_ReplaceActor.UseVisualStyleBackColor = true;
            this.btn_ReplaceActor.DragDrop += new System.Windows.Forms.DragEventHandler(this.Replace_DragDrop);
            this.btn_ReplaceActor.DragEnter += new System.Windows.Forms.DragEventHandler(this.Replace_DragEnter);
            // 
            // chkBox_Waterfall
            // 
            this.chkBox_Waterfall.AutoSize = true;
            this.chkBox_Waterfall.Checked = true;
            this.chkBox_Waterfall.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox_Waterfall.Location = new System.Drawing.Point(394, 30);
            this.chkBox_Waterfall.Margin = new System.Windows.Forms.Padding(4);
            this.chkBox_Waterfall.Name = "chkBox_Waterfall";
            this.chkBox_Waterfall.Size = new System.Drawing.Size(172, 21);
            this.chkBox_Waterfall.TabIndex = 7;
            this.chkBox_Waterfall.Text = "Enable Waterfall Climb";
            this.chkBox_Waterfall.UseVisualStyleBackColor = true;
            // 
            // lbl_OriginalActor
            // 
            this.lbl_OriginalActor.AutoSize = true;
            this.lbl_OriginalActor.Location = new System.Drawing.Point(21, 91);
            this.lbl_OriginalActor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_OriginalActor.Name = "lbl_OriginalActor";
            this.lbl_OriginalActor.Size = new System.Drawing.Size(0, 17);
            this.lbl_OriginalActor.TabIndex = 2;
            // 
            // lbl_ReplaceActor
            // 
            this.lbl_ReplaceActor.AutoSize = true;
            this.lbl_ReplaceActor.Location = new System.Drawing.Point(212, 91);
            this.lbl_ReplaceActor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ReplaceActor.Name = "lbl_ReplaceActor";
            this.lbl_ReplaceActor.Size = new System.Drawing.Size(0, 17);
            this.lbl_ReplaceActor.TabIndex = 3;
            // 
            // txtBox_Output
            // 
            this.txtBox_Output.Location = new System.Drawing.Point(17, 175);
            this.txtBox_Output.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_Output.Name = "txtBox_Output";
            this.txtBox_Output.ReadOnly = true;
            this.txtBox_Output.Size = new System.Drawing.Size(369, 222);
            this.txtBox_Output.TabIndex = 5;
            this.txtBox_Output.Text = "";
            // 
            // chkBox_SpinAttack
            // 
            this.chkBox_SpinAttack.AutoSize = true;
            this.chkBox_SpinAttack.Checked = true;
            this.chkBox_SpinAttack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox_SpinAttack.Location = new System.Drawing.Point(394, 53);
            this.chkBox_SpinAttack.Margin = new System.Windows.Forms.Padding(4);
            this.chkBox_SpinAttack.Name = "chkBox_SpinAttack";
            this.chkBox_SpinAttack.Size = new System.Drawing.Size(149, 21);
            this.chkBox_SpinAttack.TabIndex = 8;
            this.chkBox_SpinAttack.Text = "Enable Spin Attack";
            this.chkBox_SpinAttack.UseVisualStyleBackColor = true;
            // 
            // chkBox_KeepYML
            // 
            this.chkBox_KeepYML.AutoSize = true;
            this.chkBox_KeepYML.Checked = true;
            this.chkBox_KeepYML.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox_KeepYML.Location = new System.Drawing.Point(394, 353);
            this.chkBox_KeepYML.Margin = new System.Windows.Forms.Padding(4);
            this.chkBox_KeepYML.Name = "chkBox_KeepYML";
            this.chkBox_KeepYML.Size = new System.Drawing.Size(185, 21);
            this.chkBox_KeepYML.TabIndex = 9;
            this.chkBox_KeepYML.Text = "Keep Modified YML Files";
            this.chkBox_KeepYML.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(393, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = ".bgparamlist";
            // 
            // chkBox_KeepSARC
            // 
            this.chkBox_KeepSARC.AutoSize = true;
            this.chkBox_KeepSARC.Location = new System.Drawing.Point(394, 376);
            this.chkBox_KeepSARC.Margin = new System.Windows.Forms.Padding(4);
            this.chkBox_KeepSARC.Name = "chkBox_KeepSARC";
            this.chkBox_KeepSARC.Size = new System.Drawing.Size(179, 21);
            this.chkBox_KeepSARC.TabIndex = 10;
            this.chkBox_KeepSARC.Text = "Keep Unpacked SARCs";
            this.chkBox_KeepSARC.UseVisualStyleBackColor = true;
            // 
            // BotWActorEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 410);
            this.Controls.Add(this.chkBox_KeepSARC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkBox_KeepYML);
            this.Controls.Add(this.chkBox_SpinAttack);
            this.Controls.Add(this.txtBox_Output);
            this.Controls.Add(this.chkBox_Waterfall);
            this.Controls.Add(this.lbl_ReplaceActor);
            this.Controls.Add(this.lbl_OriginalActor);
            this.Controls.Add(this.btn_ReplaceActor);
            this.Controls.Add(this.btn_RebuildActor);
            this.Controls.Add(this.btn_OriginalActor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BotWActorEditor";
            this.Text = "BotW Actor Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OriginalActor;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_RebuildActor;
        private System.Windows.Forms.Button btn_ReplaceActor;
        private System.Windows.Forms.CheckBox chkBox_Waterfall;
        private System.Windows.Forms.Label lbl_OriginalActor;
        private System.Windows.Forms.Label lbl_ReplaceActor;
        private System.Windows.Forms.RichTextBox txtBox_Output;
        private System.Windows.Forms.CheckBox chkBox_SpinAttack;
        private System.Windows.Forms.CheckBox chkBox_KeepYML;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkBox_KeepSARC;
    }
}

