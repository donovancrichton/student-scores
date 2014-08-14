using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

public class UpdateScoresForm : Form {
	private int formHeight = 400;
	private int formWidth = 400;
	private bool usedBtnOk = false;
	Student s;

	//parent forms


	//dialog popups
	private AddScorePopupForm diagPopupAddScore;
	private UpdateScorePopupForm diagPopupUpdateScore;
	
	//labels
	private Label lblName;
	private Label lblScores;
	
	//text boxes
	private TextBox txtbxName;
	
	//list boxes
	private ListBox lstbxScores;
	
	//buttons
	private Button btnAdd;
	private Button btnUpdate;
	private Button btnRemove;
	private Button btnClearScores;
	private Button btnOk;
	private Button btnCancel;
	
	//constructor
	public UpdateScoresForm() {
		initComponents();
	}
	
	private void initComponents() {
		//-------------------START INIT-----------------------
		
		//size and position variables to avoid magic numbers
		int lblHeight = (int) (formHeight * 0.055);
		int lblWidth = (int) (formWidth * 0.2);
		int btnWidth = (int) (formWidth * 0.3);
		int btnHeight = (int) (formHeight * 0.10);
		int lstbxHeight = 0;
		int lstbxWidth = 0;
		int xPos = 0;
		int yPos = 0;
		int xPadding = 10;
		int yPadding = 10;
		
		//other shared variables
		Font lblFont = new Font(FontFamily.GenericSansSerif, 12);
		Size lblSize = new Size(lblWidth, lblHeight);		
		Size btnSize = new Size(btnWidth, btnHeight);
		
		//instantiate form controls
		
		//labels
		this.lblName = new Label();
		this.lblScores = new Label();
		
		//text boxes
		this.txtbxName = new TextBox();
		
		//list boxes
		this.lstbxScores = new ListBox();
		
		//buttons
		this.btnAdd = new Button();
		this.btnCancel = new Button();
		this.btnClearScores = new Button();
		this.btnOk = new Button();
		this.btnRemove = new Button();
		this.btnUpdate = new Button();
		
		//dialog popups
		this.diagPopupAddScore = new AddScorePopupForm();
		this.diagPopupUpdateScore = new UpdateScorePopupForm();
		
		//-------------------SET CONTROL PROPERTIES----------------
		
		//name label
		xPos = xPadding;
		yPos = yPadding;
		this.lblName.Location = new Point(xPos, yPos);
		this.lblName.Size = lblSize;
		this.lblName.Font = lblFont;
		this.lblName.Text = "Name:";
		
		//scores label
		yPos = lblName.Bottom + lblName.Height;
		this.lblScores.Location = new Point(xPos, yPos);
		this.lblScores.Size = lblSize;
		this.lblScores.Font = lblFont;
		this.lblScores.Text = "Scores:";
		
		//name textbox
		xPos = lblName.Right + xPadding;
		yPos = lblName.Top;
		this.txtbxName.Location = new Point(xPos, yPos);
		this.txtbxName.Size = new Size(formWidth - this.txtbxName.Left 
			- xPadding, lblSize.Height);
		this.txtbxName.Font = lblFont;
		this.txtbxName.ReadOnly = true;
		
		//add button
		xPos = this.txtbxName.Right - (this.txtbxName.Width / 2) + xPadding;
		yPos = this.lblScores.Top;
		this.btnAdd.Location = new Point(xPos, yPos);
		this.btnAdd.Size = btnSize;
		this.btnAdd.Font = lblFont;
		this.btnAdd.Text = "Add";
		this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
		
		//update button
		yPos = this.btnAdd.Bottom + (3 * yPadding);
		this.btnUpdate.Location = new Point(xPos, yPos);
		this.btnUpdate.Size = btnSize;
		this.btnUpdate.Font = lblFont;
		this.btnUpdate.Text = "Update";
		this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);
		
		//remove button
		yPos = this.btnUpdate.Bottom + (3 * yPadding);
		this.btnRemove.Location = new Point(xPos, yPos);
		this.btnRemove.Size = btnSize;
		this.btnRemove.Font = lblFont;
		this.btnRemove.Text = "Remove";
		this.btnRemove.Click += new EventHandler(this.btnRemove_Click);
		
		//clear scores button
		yPos = this.btnRemove.Bottom + (3 * yPadding);
		this.btnClearScores.Location = new Point(xPos, yPos);
		this.btnClearScores.Size = btnSize;
		this.btnClearScores.Font = lblFont;
		this.btnClearScores.Text = "Clear Scores";
		this.btnClearScores.Click += new EventHandler(this.btnClearScores_Click);
		
		//cancel button
		yPos = formHeight - yPadding - btnSize.Height;
		xPos = this.btnClearScores.Left;
		this.btnCancel.Location = new Point(xPos, yPos);
		this.btnCancel.Size = btnSize;
		this.btnCancel.Font = lblFont;
		this.btnCancel.Text = "Cancel";
		this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
		
		//ok button
		
		yPos = this.btnCancel.Top;
		xPos = this.lstbxScores.Right - btnSize.Width;
		this.btnOk.Location = new Point(xPos, yPos);
		this.btnOk.Size = btnSize;
		this.btnOk.Font = lblFont;
		this.btnOk.Text = "Ok";
		this.btnOk.Click += new EventHandler(this.btnOk_Click);
		
		//scores listbox
		xPos = lblScores.Right + xPadding;
		yPos = lblScores.Top;
		lstbxWidth = this.btnAdd.Left - xPos - xPadding;
		lstbxHeight = (btnSize.Height * 4) + (10 * yPadding);
		this.lstbxScores.Location = new Point(xPos, yPos);
		this.lstbxScores.Size = new Size(lstbxWidth, lstbxHeight);
		this.lstbxScores.Font = lblFont;
		this.lstbxScores.DataSource = null;
		
		//form properties
		this.ClientSize = new System.Drawing.Size(formWidth, formHeight);
		this.Text = "Update Student Scores";
		this.Load += new EventHandler(this.this_Load);

		//dialog popup properties
		this.diagPopupAddScore.Closed += new EventHandler(diagPopupAddScore_Close);
		this.diagPopupUpdateScore.Closed += new EventHandler(diagPopupUpdateScore_Close);

		//add form controls
		
		//labels
		this.Controls.Add(lblName);
		this.Controls.Add(lblScores);
		//text box
		this.Controls.Add(txtbxName);
		//list box
		this.Controls.Add(lstbxScores);
		//buttons
		this.Controls.Add(btnAdd);
		this.Controls.Add(btnUpdate);
		this.Controls.Add(btnRemove);
		this.Controls.Add(btnClearScores);
		this.Controls.Add(btnCancel);
		this.Controls.Add(btnOk);	
		//---------------------END INIT---------------------------
	}

	//-----------------------EVENT HANDLERS----------------------
	
	private void btnCancel_Click(object sender, EventArgs e) {
		this.Close();
	}
	
	private void btnAdd_Click(object sender, EventArgs e) {
		diagPopupAddScore.ShowDialog();
	}
	
	private void btnUpdate_Click(object sender, EventArgs e) {
		int i = this.lstbxScores.SelectedIndex;
		if (i != -1) {
			diagPopupUpdateScore.ShowDialog();
		}
	}

	private void btnOk_Click(object sender, EventArgs e) {
		if (s != null || s.getScores() != null) {
			ArrayList scoreList = new ArrayList();
			foreach (int i in this.lstbxScores.Items) {
				scoreList.Add(i);
			}
			s.setAllScores(scoreList);
		}
		this.Close();
	}

	private void btnClearScores_Click(object sender, EventArgs e) {
		this.lstbxScores.Items.Clear();
	}

	private void btnRemove_Click(object sender, EventArgs e) {
		int i = this.lstbxScores.SelectedIndex;
		if (i != -1) {
			this.lstbxScores.Items.RemoveAt(i);
		}
	}

	private void this_Load(object sender, EventArgs e) {
		if (s != null) {
			this.txtbxName.Text = s.getName();
			this.lstbxScores.Items.Clear();
			foreach (int i in s.getScores()) {
				this.lstbxScores.Items.Add(i);
			}
		}
		else {
			Console.WriteLine("student = NULL!");	
		}
	}

	private void diagPopupAddScore_Close(object sender, EventArgs e) {
		int i = diagPopupAddScore.getScore();
		//reset the score once you've caught it.
		diagPopupAddScore.setScore(-1);
		this.lstbxScores.Items.Add(i);
	}

	private void diagPopupUpdateScore_Close(object sender, EventArgs e) {
		int i = this.lstbxScores.SelectedIndex;
		if (i != -1) {
			int s = diagPopupUpdateScore.getScore();
			if (s != -1) {
				this.lstbxScores.Items.RemoveAt(i);
				this.lstbxScores.Items.Insert(i, s);
				//reset the score once you've caught it.
				diagPopupUpdateScore.setScore(-1);
			}
		}
	}
	
	//---------------------------SETTERS------------------------

	public void setStudent(Student s) {
		this.s = s;
	}

	//---------------------------GETTERS---------------------------


}