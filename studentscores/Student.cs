using System;
using System.Collections;

public class Student {
	private string name;
	private ArrayList scores;

	public Student() {
		name = "";
		scores = null;
	}
	
	public Student(string name, ArrayList scores) {
		this.name = name;
		this.scores = scores;
	}
	
	//----------------------GETTERS------------------
	public string getName() {
		return this.name;
	}
	
	public ArrayList getScores() {
		return this.scores;
	}
	
	public string printScores() {
		string temp = null;
		for (int i = 0; i < scores.ToArray().Length; i++) {
			if (i == scores.ToArray().Length - 1) {
				temp += scores[i] + " ";
			}
			else {
				temp += scores[i];
			}
		}
		return temp;
	}
	
	public string printStudent() {
		string temp = null;
		temp = getName();
		foreach (int i in scores) {
			temp += "|" + i;
		}
		return temp;
	}
	
	public int getTotal() {		
		int temp = 0;
		foreach (int i in scores) {
			temp += i;
		}
		return temp;
	}
	
	public int getCount() {
		return scores.ToArray().Length;
	}
	
	public double getAvg() {
		int tempTotal;
		int tempCount;
		tempTotal = getTotal();
		tempCount = getCount();
		if (tempCount != 0) {
			return (tempTotal / tempCount);
		}
		else {
			return 0;
		}
	}
	
	public Student getStudent() {
		return this;
	}
	
	//------------------------SETTERS--------------------

	public void setAllScores(ArrayList s) {
		this.scores = s;
	}
	
	public void setName(string name) {
		this.name = name;
	}
	
	public void setScore(int i, int score) {
		this.scores.RemoveAt(i);
		this.scores.Insert(i, score);
	}

	//--------------------MODIFIERS----------------------

	public void addScore(int score) {
		this.scores.Add(score);
	}

	public void removeScore(int pos) {
		this.scores.RemoveAt(pos);
	}

	public bool equals(Student s2) {
		if (this.name.Equals(s2.getName()) &&
			this.scores.Equals(s2.getScores())) {
				return true;
		}
		else {
			return false;
		}
	}

}
