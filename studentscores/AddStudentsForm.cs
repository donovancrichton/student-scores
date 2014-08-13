using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Text;

public class AddStudentForm : Form {
	private int formHeight = 400;
	private int formWidth = 400;
	private Student newStudent;
	
	//labels	
	private Label lblName;
	private Label lblScore;
	private Label lblScoreList;
	
	//buttons
	private Button btnAddScore;
	private Button btnClearScores;
	private Button btnOk;
	private Button btnCancel;
	
	//text boxes
	private TextBox txtbxName;
	private TextBox txtbxScore;
	private TextBox txtbxScoreList;
	
	public AddStudentForm() {
		initComponents();
	}
	
	private void initComponents() {
		//size and position variables to avoid magic numbers
		int lblHeight = (int) (formHeight * 0.055);
		int lblWidth = (int) (formWidth * 0.2);
		int btnWidth = (int) (formWidth * 0.3);
		int btnHeight = (int) (formHeight * 0.10);
		int xPos = 0;
		int yPos = 0;
		int xPadding = 10;
		int yPadding = 5;
		
		//other shared variables
		Font lblFont = new Font(FontFamily.GenericSansSerif, 12);
		Size lblSize = new Size(lblWidth, lblHeight);		
		Size btnSize = new Size(btnWidth, btnHeight);
		
		//-----------------INSTANTIATE PANEL CONTROLS---------------
		
		//text labels
		this.lblName = new Label();
		this.lblScore = new Label();
		this.lblScoreList = new Label();
		
		//buttons
		this.btnAddScore = new Button();
		this.btnCancel = new Button();
		this.btnClearScores = new Button();
		this.btnOk = new Button();
		
		//text boxes
		this.txtbxName = new TextBox();
		this.txtbxScore = new TextBox();
		this.txtbxScoreList = new TextBox();
		
		//---------------SET CONTROL PROPERTIES----------------
		
		//name label
		xPos = xPadding;
		yPos = yPadding;
		this.lblName.Location = new Point(xPos, yPos);
		this.lblName.Size = lblSize;
		this.lblName.Font = lblFont;
		this.lblName.Text = "Name:";
		
		//score label
		yPos += this.lblName.Height * 2;
		this.lblScore.Location = new Point(xPos, yPos);
		this.lblScore.Size = lblSize;
		this.lblScore.Font = lblFont;
		this.lblScore.Text = "Score:";
		
		//scores label
		yPos += this.lblScore.Height * 2;
		this.lblScoreList.Location = new Point(xPos, yPos);
		this.lblScoreList.Size = lblSize;
		this.lblScoreList.Font = lblFont;
		this.lblScoreList.Text = "Scores:";
		
		//name textbox
		yPos = this.lblName.Top;
		xPos = this.lblName.Right + xPadding;
		this.txtbxName.Location = new Point(xPos, yPos);
		this.txtbxName.Size = new Size(formWidth - this.txtbxName.Left 
			- xPadding, lblSize.Height);
		this.txtbxName.Font = lblFont;
		this.txtbxName.ReadOnly = false;
		
		//score textbox
		yPos = this.lblScore.Top;
		xPos = this.lblScore.Right + xPadding;
		this.txtbxScore.Location = new Point(xPos, yPos);
		this.txtbxScore.Size = new Size((formWidth - this.txtbxScore.Left) / 2 
			- xPadding, lblSize.Height);
		this.txtbxScore.Font = lblFont;
		this.txtbxScore.ReadOnly = false;		
		
		//scores textbox
		yPos = this.lblScoreList.Top;
		xPos = this.lblScoreList.Right + xPadding;
		this.txtbxScoreList.Location = new Point(xPos, yPos);
		this.txtbxScoreList.Size = new Size(formWidth - this.txtbxScoreList.Left 
			- xPadding, lblSize.Height);
		this.txtbxScoreList.Font = lblFont;
		this.txtbxScoreList.ReadOnly = true;
	
		//add score button
		xPos = formWidth - xPadding - btnSize.Width;
		yPos = this.txtbxScore.Top - Math.Abs(this.txtbxScore.Height 
			- btnSize.Height) / 2;
		this.btnAddScore.Location = new Point(xPos, yPos);
		this.btnAddScore.Size = btnSize;
		this.btnAddScore.Font = lblFont;
		this.btnAddScore.Text = "Add Score";
		this.btnAddScore.Click += new EventHandler(this.btnAddScore_Click);
		
		//clear scores button
		xPos = this.btnAddScore.Left;
		yPos = this.lblScoreList.Bottom + btnSize.Height;
		this.btnClearScores.Location = new Point(xPos, yPos);
		this.btnClearScores.Size = btnSize;
		this.btnClearScores.Font = lblFont;
		this.btnClearScores.Text = "Clear Scores";
		this.btnClearScores.Click += new EventHandler(this.btnClearScores_Click);
		
		//cancel button
		xPos = this.btnClearScores.Left;
		yPos = formHeight - btnSize.Height - yPadding;
		this.btnCancel.Location = new Point(xPos, yPos);
		this.btnCancel.Size = btnSize;
		this.btnCancel.Font = lblFont;
		this.btnCancel.Text = "Cancel";
		this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
		
		//ok button
		xPos = this.txtbxScore.Right - btnSize.Width;
		yPos = this.btnCancel.Top;
		this.btnOk.Location = new Point(xPos, yPos);
		this.btnOk.Size = btnSize;
		this.btnOk.Font = lblFont;
		this.btnOk.Text = "Ok";
		this.btnOk.Click += new EventHandler(this.btnOk_Click);
		
		//form properties
		this.ClientSize = new System.Drawing.Size(formWidth, formHeight);
		this.Text = "Add Student";

		//---------------------ADD CONTROLS-------------------------------
		
		//labels
		this.Controls.Add(this.lblName);
		this.Controls.Add(this.lblScore);
		this.Controls.Add(this.lblScoreList);
		
		//buttons
		this.Controls.Add(this.btnAddScore);
		this.Controls.Add(this.btnCancel);
		this.Controls.Add(this.btnClearScores);
		this.Controls.Add(this.btnOk);
		
		//text boxes
		this.Controls.Add(this.txtbxName);
		this.Controls.Add(this.txtbxScore);
		this.Controls.Add(this.txtbxScoreList);
		
		//------------------------END INIT-----------------------------
	}	
	
	//-----------------------EVENT HANDLER METHODS--------------------

	private void btnCancel_Click(object sender, EventArgs e) {
		this.Close();
	}
	
	private void btnOk_Click(object sender, EventArgs e) {
		if (validateStudent()) {
			newStudent = new Student(this.txtbxName.Text,
				convertToList(this.txtbxScoreList.Text));
			this.txtbxName.Text = "";
			this.txtbxScore.Text = "";
			this.txtbxScoreList.Text = "";
			this.Close();
		}
		else {
			this.txtbxName.Text = "Error! Could not create student";
			this.txtbxScore.Text = "";
			this.txtbxScoreList.Text = "Is the data correct?";
		}
	}	

	private void btnAddScore_Click(object sender, EventArgs e) {
		string error1 = "Is the data correct?";
		string error2 = "error: 0 <= score <= 100";
		if (this.txtbxScoreList.Text.Equals("") || 
		    	this.txtbxScoreList.Text.Equals(error1) ||
			    this.txtbxScoreList.Text.Equals(error2)) {
			this.txtbxScoreList.Text = this.txtbxScore.Text;
		}
		else {
			this.txtbxScoreList.Text += " " + this.txtbxScore.Text;
		}
	}
	
	private void btnClearScores_Click(object sender, EventArgs e) {
		this.txtbxScoreList.Text = "";
	}

	//------------------HELPER METHODS--------------------

	private bool validateStudent() {
		if (isValid(this.txtbxName.Text) &&
		    isValidInt(this.txtbxScore.Text)) {
			return true;
		}
		else {
			return false;
		}
	}

	private bool isValid(string s) {
		if (s.Equals("")) {
			return false;
		}
		foreach (char c in s) {
			if (!((c > 64 && c < 91) || (c > 96 && c < 123) || c == 32)) {
				return false;
			}
		}
		return true;
	}

	private bool isValidInt(string s) {
		try {
			int.Parse(this.txtbxScore.Text);
			return true;
		}
		catch (System.FormatException) {
			return false;
		}
	}

	private bool isValidScore(int s) {
		return (s >= 0 && s <= 100);
	}

	private ArrayList convertToList(string s) {
		ArrayList sList = new ArrayList();
		char[] delimiter = new char[] {' '};
		string[] sArray;
		sArray = s.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
		foreach (string g in sArray) {
			sList.Add(int.Parse(g));
		}
		return sList;
	}

	//-------------------------GETTERS-------------------

	public Student getNewStudent() {
		return newStudent;
	}
}
