namespace BotWPhysicsReplacer
{
    partial class BotwPhysicsReplacerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BotwPhysicsReplacerForm));
            this.btn_OriginalActor = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_RebuildActor = new System.Windows.Forms.Button();
            this.btn_ReplaceActor = new System.Windows.Forms.Button();
            this.chkBox_Waterfall = new System.Windows.Forms.CheckBox();
            this.lbl_OriginalActor = new System.Windows.Forms.Label();
            this.lbl_ReplaceActor = new System.Windows.Forms.Label();
            this.txtBox_Output = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btn_OriginalActor
            // 
            this.btn_OriginalActor.AllowDrop = true;
            this.btn_OriginalActor.Location = new System.Drawing.Point(12, 12);
            this.btn_OriginalActor.Name = "btn_OriginalActor";
            this.btn_OriginalActor.Size = new System.Drawing.Size(136, 60);
            this.btn_OriginalActor.TabIndex = 0;
            this.btn_OriginalActor.Text = "Drag original .sbactorpack";
            this.btn_OriginalActor.UseVisualStyleBackColor = true;
            this.btn_OriginalActor.DragDrop += new System.Windows.Forms.DragEventHandler(this.Original_DragDrop);
            this.btn_OriginalActor.DragEnter += new System.Windows.Forms.DragEventHandler(this.Original_DragEnter);
            // 
            // btn_RebuildActor
            // 
            this.btn_RebuildActor.Enabled = false;
            this.btn_RebuildActor.Location = new System.Drawing.Point(12, 113);
            this.btn_RebuildActor.Name = "btn_RebuildActor";
            this.btn_RebuildActor.Size = new System.Drawing.Size(278, 41);
            this.btn_RebuildActor.TabIndex = 3;
            this.btn_RebuildActor.Text = "Rebuild .sbactorpack\r\nwith edits";
            this.btn_RebuildActor.UseVisualStyleBackColor = true;
            this.btn_RebuildActor.Click += new System.EventHandler(this.Rebuild_Click);
            // 
            // btn_ReplaceActor
            // 
            this.btn_ReplaceActor.AllowDrop = true;
            this.btn_ReplaceActor.Location = new System.Drawing.Point(154, 12);
            this.btn_ReplaceActor.Name = "btn_ReplaceActor";
            this.btn_ReplaceActor.Size = new System.Drawing.Size(136, 60);
            this.btn_ReplaceActor.TabIndex = 4;
            this.btn_ReplaceActor.Text = "Drag .sbactorpack with physics you want to use";
            this.btn_ReplaceActor.UseVisualStyleBackColor = true;
            this.btn_ReplaceActor.DragDrop += new System.Windows.Forms.DragEventHandler(this.Replace_DragDrop);
            this.btn_ReplaceActor.DragEnter += new System.Windows.Forms.DragEventHandler(this.Replace_DragEnter);
            // 
            // chkBox_Waterfall
            // 
            this.chkBox_Waterfall.AutoSize = true;
            this.chkBox_Waterfall.Checked = true;
            this.chkBox_Waterfall.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox_Waterfall.Location = new System.Drawing.Point(12, 90);
            this.chkBox_Waterfall.Name = "chkBox_Waterfall";
            this.chkBox_Waterfall.Size = new System.Drawing.Size(198, 17);
            this.chkBox_Waterfall.TabIndex = 0;
            this.chkBox_Waterfall.Text = "Enable Waterfall Climb / Spin Attack";
            this.chkBox_Waterfall.UseVisualStyleBackColor = true;
            // 
            // lbl_OriginalActor
            // 
            this.lbl_OriginalActor.AutoSize = true;
            this.lbl_OriginalActor.Location = new System.Drawing.Point(16, 74);
            this.lbl_OriginalActor.Name = "lbl_OriginalActor";
            this.lbl_OriginalActor.Size = new System.Drawing.Size(0, 13);
            this.lbl_OriginalActor.TabIndex = 6;
            // 
            // lbl_ReplaceActor
            // 
            this.lbl_ReplaceActor.AutoSize = true;
            this.lbl_ReplaceActor.Location = new System.Drawing.Point(159, 74);
            this.lbl_ReplaceActor.Name = "lbl_ReplaceActor";
            this.lbl_ReplaceActor.Size = new System.Drawing.Size(0, 13);
            this.lbl_ReplaceActor.TabIndex = 7;
            // 
            // txtBox_Output
            // 
            this.txtBox_Output.Location = new System.Drawing.Point(12, 160);
            this.txtBox_Output.Name = "txtBox_Output";
            this.txtBox_Output.ReadOnly = true;
            this.txtBox_Output.Size = new System.Drawing.Size(278, 161);
            this.txtBox_Output.TabIndex = 8;
            this.txtBox_Output.Text = "";
            // 
            // BotwPhysicsReplacerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 333);
            this.Controls.Add(this.txtBox_Output);
            this.Controls.Add(this.chkBox_Waterfall);
            this.Controls.Add(this.lbl_ReplaceActor);
            this.Controls.Add(this.lbl_OriginalActor);
            this.Controls.Add(this.btn_ReplaceActor);
            this.Controls.Add(this.btn_RebuildActor);
            this.Controls.Add(this.btn_OriginalActor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BotwPhysicsReplacerForm";
            this.Text = "BotW Physics Replacer";
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
    }
}

