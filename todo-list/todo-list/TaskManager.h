#ifndef TASKMANAGER_H_
#define TASKMANAGER_H_

#include <vector>
#include <fstream>
#include <filesystem>
#include "Task.h"
#include "PrivateTask.h"
#include "HomeTask.h"
#include "TaskBase.h"
#include "TodoList.h"

using namespace std;

class TaskManager : public TaskBase {
	
public:
	TaskManager()
	{
	}
	void createTodoList()
	{
		TodoList tdl;
		int time_available;
		int command;
		tdl.printMenu(time_available, command);
		if (command == 1)
		{
			tdl.makeList(home_tasks, time_available);
		}
		else if (command == 2)
		{
			tdl.makeList(outside_tasks, time_available);
		}
		else if (command == 3)
		{
			tdl.makeList(work_tasks, time_available);
		}
	}
	void saveToFile(string file_name)
	{
		ofstream output_file;
		output_file.open(file_name);
		
		for (int i = 0; i < home_tasks.size(); i++)
		{
			output_file << endl << 0; //category: home task
			output_file << endl << home_tasks[i]->name;
			output_file << endl << home_tasks[i]->priority;
			output_file << endl << home_tasks[i]->due_date;
			output_file << endl << home_tasks[i]->time_needed;
		}
		for (int i = 0; i < outside_tasks.size(); i++)
		{
			output_file << endl << 1; //category: outside task
			output_file << endl << outside_tasks[i]->name;
			output_file << endl << outside_tasks[i]->priority;
			output_file << endl << outside_tasks[i]->due_date;
			output_file << endl << outside_tasks[i]->time_needed;
		}
		for (int i = 0; i < work_tasks.size(); i++)
		{
			output_file << endl << 2; //category: work task
			output_file << endl << work_tasks[i]->name;
			output_file << endl << work_tasks[i]->priority;
			output_file << endl << work_tasks[i]->due_date;
			output_file << endl << work_tasks[i]->time_needed;
		}

		output_file.close();
	}
	void loadFromFile(string file_name)
	{
		ifstream input_file;
		input_file.open(file_name, ios::in);
		
		if (input_file)
		{
			string buffer;
			getline(input_file, buffer); //get the first endl

			while (!input_file.eof())
			{
				getline(input_file, buffer);
				int category = std::stoi(buffer); 
				string name;
				getline(input_file, name);
				getline(input_file, buffer);
				int priority = std::stoi(buffer);
				string due_date;
				getline(input_file, due_date);
				getline(input_file, buffer);
				int time_needed = std::stoi(buffer);

				if (category == 0) //category: home task
				{
					addTask(category::home_task, time_needed, priority, name, due_date);
				}
				else if (category == 1) //category: outside task
				{
					addTask(category::outside_task, time_needed, priority, name, due_date);
				}
				else if (category == 2) //category: work task
				{
					addTask(category::work_task, time_needed, priority, name, due_date);
				}
				else
				{
					string e = "Error: incorrect file contents, cannot load from file";
					throw e;
				}
			}
		}
		else
		{
			string e = "Error: cannot open file";
			throw e;
		}
	}
	~TaskManager()
	{
	}
};

#endif