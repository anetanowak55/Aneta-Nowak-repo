#ifndef TASK_H_
#define TASK_H_

#include <sstream>
#include <vector>

using namespace std;

class Task
{
public:
	int time_needed = 0; //in minutes
	int priority = 0;
	string name = "empty"; //max 50 characters
	string due_date = "1-1-1970";
	int day = 1;
	int month = 1;
	int year = 1970;
	Task()
	{
	}
	void printTask()
	{
		if (priority == 3)
			cout << "!!! ";
		cout << "task: " << name << " | to do by: " << day << "-" << month << "-" << year
			<< " | priority: " << priority << " | time needed [miutes]: " << time_needed << endl;
	}
	void readDate(string date)
	{
		stringstream d;
		string sday, smonth, syear;
		d << date;
		char delimeter('-');
		getline(d, sday, delimeter);
		getline(d, smonth, delimeter);
		getline(d, syear);
		day = stoi(sday); //EXCEPTION - JESLI SIE NIE DA ZAMIENIC NA INT
		month = stoi(smonth);
		year = stoi(syear);
	}
	~Task()
	{
	}
};

#endif