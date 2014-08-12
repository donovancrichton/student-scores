using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

public class StudentScoresForm : Form {
	private int formHeight = 500;
	private int formWidth = 500;
	
	//collections
	private ArrayList studentList;
	
	//dialog boxes
	private AddStudentForm diagAddStudents;
	private UpdateScoresForm diagUpdateScores;
	
	//labels
	private Label lblStudents;
	private Label lblScoreTotal;
	private Label lblScoreCount;
	private Label lblScoreAvg;
	
	//buttons
	private Button btnAddStudent;
	private Button btnDeleteStudent;
	private Button btnUpdate;
	private Button btnExit;
	
	//list boxes
	private ListBox lstbxStudents;
		
	//text boxes
	private TextBox txtbxScoreTotal;
	private TextBox txtbxScoreCount;
	private TextBox txtbxScoreAvg;
	
	//constructor	
	public StudentScoresForm() {
		initComponents();
	}
		
	private void initComponents() {
		//size and position variables to avoid magic numbers		
		int lblHeight = (int) (formHeight * 0.055);
		int lblWidth = (int) (formWidth * 0.2);
		int lstbxHeight = (int) (formHeight * 0.66);
		int lstbxWidth = (int) (formWidth * 0.66);
		int btnWidth = (int) (formWidth * 0.24);
		int btnHeight = (int) (formHeight * 0.10);
		int xPos = 0;
		int yPos = 0;
		int xPadding = 10;
		int yPadding = 5;
	
		//other shared variables
		Font lblFont = new Font(FontFamily.GenericSansSerif, 12);
		Size lblSize = new Size(lblWidth, lblHeight);		
		Size btnSize = new Size(btnWidth, btnHeight);
		
		//instantiate dialog boxes
		diagAddStudents = new AddStudentForm();
		diagUpdateScores = new UpdateScoresForm();
		
		//instantiate panel controls
		
		this.lblStudents = new System.Windows.Forms.Label();
		this.lblScoreTotal = new System.Windows.Forms.Label();
		this.lblScoreCount = new System.Windows.Forms.Label();
		this.lblScoreAvg = new System.Windows.Forms.Label();
		
		this.btnAddStudent = new System.Windows.Forms.Button();
		this.btnDeleteStudent = new System.Windows.Forms.Button();
		this.btnUpdate = new System.Windows.Forms.Button();
		this.btnExit = new System.Windows.Forms.Button();
		
		this.txtbxScoreAvg = new System.Windows.Forms.TextBox();
		this.txtbxScoreCount = new System.Windows.Forms.TextBox();
		this.txtbxScoreTotal = new System.Windows.Forms.TextBox();
	
		this.lstbxStudents = new System.Windows.Forms.ListBox();
		
		//----------SET OBJECT PROPERTIES--------------------
			
		//students label
		xPos = (int) (formWidth - (formWidth * 0.95));
		yPos = (int) (formHeight - (formHeight * 0.95));
		this.lblStudents.Location = new Point(xPos, yPos);
		this.lblStudents.Size = lblSize;
		this.lblStudents.Font = lblFont;
		this.lblStudents.Text = "Students:";
			
		//list box
		yPos += this.lblStudents.Height + yPadding;
		this.lstbxStudents.DataSource = null;
		this.lstbxStudents.Location = new Point(xPos, yPos);
		this.lstbxStudents.Font = lblFont;
		this.lstbxStudents.Size = new Size(lstbxWidth, lstbxHeight);
		this.lstbxStudents.SelectedIndexChanged += new EventHandler(
			lstbxStudents_ChangeSelection);

		
		//score total label
		yPos += this.lstbxStudents.Height + yPadding;
		xPos += (this.lstbxStudents.Width / 2) - xPadding;
		this.lblScoreTotal.Location = new Point(xPos, yPos);
		this.lblScoreTotal.Size = lblSize;
		this.lblScoreTotal.Font = lblFont;
		this.lblScoreTotal.Text = "Score Total:";
		this.lblScoreTotal.TextAlign = ContentAlignment.MiddleRight;
		
		//score count label
		yPos += this.lblScoreTotal.Height + yPadding;
		this.lblScoreCount.Location = new Point(xPos, yPos);
		this.lblScoreCount.Size = lblSize;
		this.lblScoreCount.Font = lblFont;
		this.lblScoreCount.Text = "Score Count:";
		this.lblScoreCount.TextAlign = ContentAlignment.MiddleRight;
		
		//score average label
		yPos += this.lblScoreCount.Height + yPadding;
		this.lblScoreAvg.Location = new Point(xPos, yPos);
		this.lblScoreAvg.Size = lblSize;
		this.lblScoreAvg.Font = lblFont;
		this.lblScoreAvg.Text = "Average:";
		this.lblScoreAvg.TextAlign = ContentAlignment.MiddleRight;
		
		//add students button
		yPos = this.lstbxStudents.Top;
		xPos = this.lstbxStudents.Right + xPadding;
		this.btnAddStudent.Location = new Point(xPos, yPos);
		this.btnAddStudent.Size = btnSize;
		this.btnAddStudent.Font = lblFont;
		this.btnAddStudent.Text = "Add New...";
		this.btnAddStudent.Click += new EventHandler(this.btnAddStudent_Click);
					
		//update button
		yPos += btnAddStudent.Height + (3 * yPadding);
		this.btnUpdate.Location = new Point(xPos, yPos);
		this.btnUpdate.Size = btnSize;
		this.btnUpdate.Font = lblFont;
		this.btnUpdate.Text = "Update...";
		this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);
		
		//delete button
		yPos += btnUpdate.Height + (3 * yPadding);
		this.btnDeleteStudent.Location = new Point(xPos, yPos);
		this.btnDeleteStudent.Size = btnSize;
		this.btnDeleteStudent.Font = lblFont;
		this.btnDeleteStudent.Text = "Delete";
		this.btnDeleteStudent.Click += new EventHandler(this.btnDelete_Click);
			
		//exit button
		xPos = this.lstbxStudents.Right + xPadding;
		yPos = formHeight - yPadding - btnSize.Height;
		this.btnExit.Location = new Point(xPos, yPos);
		this.btnExit.Size = btnSize;
		this.btnExit.Font = lblFont;
		this.btnExit.Text = "Exit";
		this.btnExit.Click += new EventHandler(this.btnExit_Click);
		
		//score total textbox
		xPos = this.lblScoreTotal.Right + xPadding;
		yPos = this.lblScoreTotal.Top;
		this.txtbxScoreTotal.Location = new Point(xPos, yPos);
		this.txtbxScoreTotal.Size = new Size(
			this.lstbxStudents.Right - xPos, lblHeight - (2 * yPadding)); 
		this.txtbxScoreTotal.Font = lblFont;
		this.txtbxScoreTotal.Text = "";
		this.txtbxScoreTotal.Name = "txtbxScoreTotal";
		this.txtbxScoreTotal.ReadOnly = true;
			
		//score count textbox
		yPos = this.lblScoreCount.Top;
		this.txtbxScoreCount.Location = new Point(xPos, yPos);
		this.txtbxScoreCount.Size = new Size(
			this.lstbxStudents.Right - xPos, lblHeight - (4 * yPadding)); 
		this.txtbxScoreCount.Font = lblFont;
		this.txtbxScoreCount.Text = "";
		this.txtbxScoreCount.Name = "txtbxScoreCount";
		this.txtbxScoreCount.ReadOnly = true;
			
		//score average textbox
		yPos = this.lblScoreAvg.Top;
		this.txtbxScoreAvg.Location = new Point(xPos, yPos);
		this.txtbxScoreAvg.Size = new Size(
			this.lstbxStudents.Right - xPos, lblHeight - (4 * yPadding)); 
		this.txtbxScoreAvg.Font = lblFont;
		this.txtbxScoreAvg.Text = "";
		this.txtbxScoreAvg.Name = "txtbxScoreAvg";
		this.txtbxScoreAvg.ReadOnly = true;
				
		//dialog properties
		this.diagAddStudents.Closed += new EventHandler(this.diagAddStudents_Closed);

		//form properties
		this.ClientSize = new System.Drawing.Size(formWidth, formHeight);
		this.Text = "Student Scores";
		this.Load += new EventHandler(this_Load);
		
		//add labels
		this.Controls.Add(this.lblStudents);
		this.Controls.Add(this.lblScoreTotal);
		this.Controls.Add(this.lblScoreCount);
		this.Controls.Add(this.lblScoreAvg);
		//add listbox
		this.Controls.Add(this.lstbxStudents);
		//add buttons
		this.Controls.Add(this.btnAddStudent);
		this.Controls.Add(this.btnUpdate);
		this.Controls.Add(this.btnDeleteStudent);
		this.Controls.Add(this.btnExit);
		//add textboxes
		this.Controls.Add(this.txtbxScoreTotal);
		this.Controls.Add(this.txtbxScoreCount);
		this.Controls.Add(this.txtbxScoreAvg);
		//-----------------------END INIT------------------------
	}
		
		
	//panel events
	private void btnExit_Click(object sender, EventArgs e) {
		Application.Exit();
	}
		
	private void btnAddStudent_Click(object sender, EventArgs e) {
		diagAddStudents.ShowDialog();			
	}
		
	private void btnUpdate_Click(object sender, EventArgs e) {
		diagUpdateScores.ShowDialog();	
	}
		
	private void btnDelete_Click(object sender, EventArgs e) {
		
	}
	
	private void this_Load(object sender, EventArgs e) {
		studentList = popDefaultList();
		this.lstbxStudents.Items.Clear();
		foreach (Student s in studentList) {
			this.lstbxStudents.Items.Add(s.printStudent());
		}		
	}
	
	private void lstbxStudents_ChangeSelection(object sender, EventArgs e) {
		Student temp;
		int index;
		index = this.lstbxStudents.SelectedIndex;
		temp = studentList[index] as Student;
		this.txtbxScoreTotal.Text = temp.getTotal().ToString();
		this.txtbxScoreCount.Text = temp.getCount().ToString();
		this.txtbxScoreAvg.Text = temp.getAvg().ToString();
	}

	private void diagAddStudents_Closed(object sender, EventArgs e) {
		Student temp;
		//try {
			temp = diagAddStudents.getStudent();
			studentList.Add(temp);
			this.lstbxStudents.Items.Add(temp.printStudent());
		//}

		
	}

	//------------------------HELPER METHODS-------------------------------

	private ArrayList popDefaultList() {
		ArrayList studentList = new ArrayList();
		Student default1 = new Student();
		Student default2 = new Student();
		Student default3 = new Student();
		ArrayList tempScores = new ArrayList {97, 71, 83};
		
		default1.setName("Joel Murach");
		default1.setAllScores(tempScores);
		
		default2.setName("Doug Lowe");
		tempScores = new ArrayList {99, 93, 97};
		default2.setAllScores(tempScores);
		
		default3.setName("Anne Boehm");
		tempScores = new ArrayList {100, 100, 100};
		default3.setAllScores(tempScores); 
		
		studentList.Add(default1);
		studentList.Add(default2);
		studentList.Add(default3);
		
		return studentList;
	}
	
	
}
