using System;
using System.Drawing;
using System.Windows.Forms;

public class UpdateScorePopupForm : Form {
		//these should be constants
		private const int FORM_HEIGHT = 100;
		private const int FORM_WIDTH = 200;
		int score = -1;	

		Label lblScore;
		TextBox txtbxScore;
		Button btnUpdate;
		Button btnCancel;
		
		public UpdateScorePopupForm() {
			initComponents();
		}
		
		private void initComponents() {
			//-------------------START INIT-----------------------
			
			//size and postion variables to avoid magic numbers
			int xPadding = 15;
			int yPadding = 10;
			int btnHeight = (int) (FORM_HEIGHT / 3);
			int btnWidth = (int) FORM_WIDTH / 3;
			int lblHeight = btnHeight;
			int lblWidth = btnWidth;
			int xPos = xPadding;
			int yPos = yPadding;
			
			Size btnSize = new Size(btnWidth, btnHeight);
			Size lblSize = new Size(lblWidth, lblHeight);
			Font lblFont = new Font(FontFamily.GenericSansSerif, 12);
			
			//instantiate form controls
			this.lblScore = new Label();
			this.txtbxScore = new TextBox();
			this.btnUpdate = new Button();
			this.btnCancel = new Button();
			
			//set form control properties
			
			//score label;
			this.lblScore.Location = new Point(xPos, yPos);
			this.lblScore.Size = lblSize;
			this.lblScore.Font = lblFont;
			this.lblScore.Text = "Score:";
			
			//score textbox
			xPos = this.lblScore.Right + xPadding;
			yPadding = this.lblScore.Top;
			this.txtbxScore.Location = new Point(xPos, yPos);
			this.txtbxScore.Font = lblFont;
			this.txtbxScore.Size = lblSize; 
			this.txtbxScore.Text = "";
			
			//add button
			xPos = xPadding;
			yPos = FORM_HEIGHT - btnSize.Height - yPadding;
			this.btnUpdate.Location = new Point(xPos, yPos);
			this.btnUpdate.Font = lblFont;
			this.btnUpdate.Size = btnSize;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);
			
			//cancel button
			xPos = FORM_WIDTH - btnSize.Width - xPadding;
			yPos = FORM_HEIGHT - btnSize.Height - yPadding;
			this.btnCancel.Location = new Point(xPos, yPos);
			this.btnCancel.Font = lblFont;
			this.btnCancel.Size = btnSize;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
			
			//form properties
			this.ClientSize = new System.Drawing.Size(FORM_WIDTH, FORM_HEIGHT);
			this.Text = "Update Score";
			
			//add controls
			this.Controls.Add(this.lblScore);
			this.Controls.Add(this.txtbxScore);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.btnCancel);
		}
		
		//-------------------------EVENT HANDLERS------------------
		
		private void btnCancel_Click(object sender, EventArgs e) {
			this.txtbxScore.Text = "";
			this.score = -1;
			this.Close();
		}

		private void btnUpdate_Click(object sender, EventArgs e) {
			int i;	
			try {
				i = int.Parse(this.txtbxScore.Text);
				if (isValidInt(i)) {
					score = i;
					this.txtbxScore.Text = "";
					this.Close();
				}
				else {
					this.txtbxScore.Text = "0 <= score <= 100";
				}
			}
			catch (System.FormatException) {
				this.txtbxScore.Text = "Must be a number!";
			}
		}

		//-----------------------HELPERS-------------------

		private bool isValidInt(int s) {
			return (s >= 0 && s <= 100);
		}

		//----------------------GETTERS--------------------
		public int getScore() {
			return this.score;
		}

		//----------------------SETTERS---------------------
		public void setScore(int s) {
			this.score = s;
		}
}

