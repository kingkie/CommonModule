// Camera Vision
//
// Copyright ?Andrew Kirillov, 2005-2006
// andrew.kirillov@gmail.com
//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CameraViewer
{
	// Check group delegate
	public delegate bool CheckGroupHandler(Group group);

	/// <summary>
	/// Summary description for AddGroupForm.
	/// </summary>
	public class GroupForm : System.Windows.Forms.Form
	{
		private Group group = new Group("");
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox nameBox;
		private System.Windows.Forms.TextBox descriptionBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		// Check camera function
		private CheckGroupHandler checkGroupFunction;

		// CheckGroupFunction property
		public CheckGroupHandler CheckGroupFunction
		{
			set { checkGroupFunction = value; }
		}

		public GroupForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		// Group property
		public Group Group
		{
			get { return group; }
			set
			{
				if (value != null)
				{
					group = value;

					nameBox.Text = group.Name;
					descriptionBox.Text = group.Description;
				}
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group &name:";
            // 
            // nameBox
            // 
            this.nameBox.BackColor = System.Drawing.SystemColors.Window;
            this.nameBox.Location = new System.Drawing.Point(108, 16);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(270, 21);
            this.nameBox.TabIndex = 1;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(18, 70);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(360, 86);
            this.descriptionBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(18, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Description:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(18, 162);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(360, 2);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // okButton
            // 
            this.okButton.Enabled = false;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(186, 178);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(90, 24);
            this.okButton.TabIndex = 4;
            this.okButton.TabStop = false;
            this.okButton.Text = "Ok";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(288, 178);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(90, 24);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            // 
            // GroupForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(393, 217);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GroupForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add group";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		// Name changed
		private void nameBox_TextChanged(object sender, System.EventArgs e)
		{
			this.okButton.Enabled = (this.nameBox.Text.Length != 0);
		}

		// On "Ok" button click
		private void okButton_Click(object sender, System.EventArgs e)
		{
			string	name = nameBox.Text.Replace('\\', ' ');

			if (checkGroupFunction != null)
			{
				Group tmpGroup = new Group(name);

				tmpGroup.ID = group.ID;
				tmpGroup.Parent = group.Parent;

				// check group
				if (checkGroupFunction(tmpGroup) == false)
				{
					Color	tmp = this.nameBox.BackColor;

					// highligh name edit box
					this.nameBox.BackColor = Color.LightCoral;
					// error message
					MessageBox.Show(this, "A group with such name is already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					// restore & focus name edit box
					this.nameBox.BackColor = tmp;
					this.nameBox.Focus();

					return;
				}
			}

			// update groups name and description
			group.Name = name;
			group.Description = descriptionBox.Text;

			// close the dialog
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
